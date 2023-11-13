using BusinessObject.Models;
using Bussiness.DTO;
using DTO.Request.DetailScore;
using DTO.Response.ClassGrade;
using DTO.Response.DetailScore;
using DTO.Response.Subject;
using DTO.Response.SubjectOfClass;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Teacher.Class
{
    public class ViewDetailScoreModel : PageModel
    {
        private readonly HttpClient client;
        private string ClassGradetApiUrl = "";
        private string SubjectApiUrl = "";
        private string DetailScoreApiUrl = "";

        public SubjectResponseDTO SubjectResponse { get; set; }
        [BindProperty]
        public ClassGradeDTO ClassGradeDTO { get; set; }
        public int GradeId { get; set; }
        public int ClassSubjectId { get; set; }
        public int SubjectId { get; set; }
        public ViewDetailScoreModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ClassGradetApiUrl = $"{Configuration.ApiURL}/ClassGrade";
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";
            DetailScoreApiUrl = $"{Configuration.ApiURL}/DetailScores";
            ClassSubjectId = 0;
            SubjectId = 0;
            SubjectResponse = new SubjectResponseDTO();
        }


        private async Task GetData(int classSubjectId, int subjectId)
        {
            ClassSubjectId = classSubjectId;
            SubjectId = subjectId;
            HttpResponseMessage responseMessage = await client.GetAsync($"{SubjectApiUrl}/{subjectId}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<SubjectResponseDTO>(strData, options);
                SubjectResponse = resultList ?? new SubjectResponseDTO();
            }

        }

        private async Task GetDataClassGrade(int classSubjectId, int gradeId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{ClassGradetApiUrl}?classSubjectId={classSubjectId}&gradeId={gradeId}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<ClassGradeDTO>(strData, options);
                ClassGradeDTO = resultList ?? new ClassGradeDTO();
            }
            //ClassGradeDTO = _classGradeRepository.GetData(classSubjectId, gradeId);
            GradeId = gradeId;

        }

        public async Task OnGet(int classSubjectId, int subjectId, int gradeId)
        {
            if (gradeId != 0)
            {
                await GetDataClassGrade(classSubjectId, gradeId);
            }
            await GetData(classSubjectId, subjectId);
        }

        public async Task OnPost(int classSubjectId, int subjectId, int gradeId)
        {
            List<DetailScoreUpdateMarkDTO> DetailScoreUpdateDTO = new List<DetailScoreUpdateMarkDTO>();
            foreach(var dSUpdate in ClassGradeDTO.DetailScores)
            {
                DetailScoreUpdateMarkDTO d = new DetailScoreUpdateMarkDTO()
                {
                    Id = dSUpdate.Id,
                    Mark = dSUpdate.Mark,
                    Comment = dSUpdate.Comment,
                };
                DetailScoreUpdateDTO.Add(d);
            }
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync($"{DetailScoreApiUrl}/UpdateListDetailScore", DetailScoreUpdateDTO);
            await GetData(classSubjectId, subjectId);
            GradeId = gradeId;
            await GetDataClassGrade(classSubjectId, gradeId);
        }
    }
}
