using DTO.Request.DetailScore;
using DTO.Response.Class;
using DTO.Response.ClassGrade;
using DTO.Response.Subject;
using DTO.Response.SubjectResult;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FAPClient.Pages.Teacher.Class
{
    [Authorize(Roles = "2")]
    public class ViewClassSubjectResultModel : PageModel
    {
        private readonly HttpClient client;
        private string ClassGradetApiUrl = "";
        private string SubjectApiUrl = "";
        private string SubjectResultApiUrl = "";

        [BindProperty]
        public List<AllClassGradeDTO> AllClassGrades { get; set; }
        public SubjectResponseDTO SubjectResponse { get; set; }
        public int ClassSubjectId { get; set; }
        public int SubjectId { get; set; }
        public ViewClassSubjectResultModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ClassGradetApiUrl = $"{Configuration.ApiURL}/ClassGrade";
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";
            SubjectResultApiUrl = $"{Configuration.ApiURL}/SubjectResults";
            ClassSubjectId = 0;
            SubjectId = 0;
            AllClassGrades = new List<AllClassGradeDTO>();
        }

        public async Task GetData(int classSubjectId, int subjectId)
        {
            ClassSubjectId = classSubjectId;
            SubjectId = subjectId;

            HttpResponseMessage responseMessage = await client.GetAsync($"{ClassGradetApiUrl}/GetClassAllSubjectResult?classSubjectId={classSubjectId}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<AllClassGradeDTO>>(strData, options);
                AllClassGrades = resultList ?? new List<AllClassGradeDTO>();
            }

            responseMessage = await client.GetAsync($"{SubjectApiUrl}/{subjectId}");
            strData = await responseMessage.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<SubjectResponseDTO>(strData, options);
                SubjectResponse = resultList ?? new SubjectResponseDTO();
            }
            //classTranscriptDTOs = _classTranscriptRepository.GetList(classSubjectId);
            //subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
            //classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
        }

        public async Task OnGet(int classSubjectId, int subjectId)
        {
            await GetData(classSubjectId, subjectId);
        }

        public async Task OnPostUpdateFinalScoore(int classSubjectId, int subjectId)
        {
            string classReponseAddDTOsJson = Request.Form["AllClassGrades"];
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            AllClassGrades = JsonSerializer.Deserialize<List<AllClassGradeDTO>>(classReponseAddDTOsJson, options);
            List<SubjectResultResponseDTO> subjectResults = new List<SubjectResultResponseDTO>();
            foreach (var allClassGrade in AllClassGrades)
            {
                if (allClassGrade.status)
                {
                    allClassGrade.SubjectResult.Status = 1;
                }
                else
                {
                    allClassGrade.SubjectResult.Status = 0;

                }
                subjectResults.Add(allClassGrade.SubjectResult);
            }
            // Deserialize the JSON string into a list of objects
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync($"{SubjectResultApiUrl}/UpdateListSubjectResult", subjectResults);
            await GetData(classSubjectId, subjectId);

        }
    }
}
