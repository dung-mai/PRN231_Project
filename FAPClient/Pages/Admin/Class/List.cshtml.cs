using DTO.Response.Class;
using DTO.Response.Semester;
using DTO.Response.Subject;
using DTO.Response.SubjectOfClass;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Class
{
    public class ListModel : PageModel
    {
        private readonly HttpClient client;
        private string ClassApiUrl = "";

        public ListModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ClassApiUrl = $"{Configuration.ApiURL}/Classes";

            Classes = new List<ClassResponseDTO>();
            Semesters = new List<SemesterResponseDTO>();
            SubjectList = new List<SubjectResponseDTO>();
            ClassSubjectList = new List<SubjectOfClassResponseDTO>();
        }

        public int TermId { get; set; }
        public int SubjectId { get; set; }
        public int ClassSubjectId { get; set; }
        public SubjectOfClassResponseDTO? SelectedClassSubject { get; set; } 

        public List<ClassResponseDTO> Classes { get; set; }
        public List<SemesterResponseDTO> Semesters { get; set; }
        public List<SubjectResponseDTO> SubjectList { get; set; }
        public List<SubjectOfClassResponseDTO> ClassSubjectList { get; set; }

        public async Task<IActionResult> OnGet(int term, int courseId, int group)
        {
            //HttpResponseMessage responseMessage = await client.GetAsync(ClassApiUrl);
            //string strData = await responseMessage.Content.ReadAsStringAsync();
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //};
            //if (!string.IsNullOrEmpty(strData))
            //{
            //    var resultList = JsonSerializer.Deserialize<List<ClassResponseDTO>>(strData, options);
            //    Classes = resultList ?? new List<ClassResponseDTO>();
            //}
            await GetData();

            return Page();
        }

        private async Task GetData()
        {
            await GetSubjects();
            await GetSemesters();
        }

        private async Task GetSemesters()
        {
            string semesterAPI = $"{Configuration.ApiURL}/Semesters";
            HttpResponseMessage responseMessage = await client.GetAsync(semesterAPI);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<SemesterResponseDTO>>(strData, options);
                Semesters = resultList ?? new List<SemesterResponseDTO>();
            }
        }

        private async Task GetSubjects()
        {
            string subjectApiUrl = $"{Configuration.ApiURL}/Subjects";
            HttpResponseMessage responseMessage = await client.GetAsync(subjectApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(strData, options);
                SubjectList = resultList ?? new List<SubjectResponseDTO>();
            }
        }

    }
}
