using BusinessObject.Models;
using Bussiness.DTO;
using DTO.Response.ClassGrade;
using DTO.Response.StudyCourse;
using DTO.Response.Subject;
using DTO.Response.SubjectResult;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace FAPClient.Pages.Student
{
    public class ViewClassModel : PageModel
    {
        private readonly HttpClient client;
        private string ClassGradetApiUrl = "";
        private string SubjectApiUrl = "";
        private string SubjectResultApiUrl = "";
        private string StudyCourseApiUrl = "";
        public SubjectResultResponseDTO SubjectResults { get; set; }
        public List<StudyCourseResponseAllDTO> StudyCourses { get; set; }
        public List<SubjectResponseDTO> SubjectResponses { get; set; }
        public int SubjectId { get; set; }  
        public int SubjectGradeId { get; set; }

        public ViewClassModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ClassGradetApiUrl = $"{Configuration.ApiURL}/ClassGrade";
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";
            SubjectResultApiUrl = $"{Configuration.ApiURL}/SubjectResults";
            StudyCourseApiUrl = $"{Configuration.ApiURL}/StudyCourses";
            SubjectGradeId = 0;
            SubjectId = 0;
            SubjectResults = new SubjectResultResponseDTO();
            SubjectResponses = new List<SubjectResponseDTO>();
        }

        public async Task GetData()
        {
            String rollNumber = "HE161396";
            HttpResponseMessage responseMessage = await client.GetAsync($"{StudyCourseApiUrl}/GetStudyCoursesByRollnumber?rollnumber={rollNumber}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<StudyCourseResponseAllDTO>>(strData, options);
                StudyCourses = resultList ?? new List<StudyCourseResponseAllDTO>();
            }
        }

        public async Task OnGet(int subjectResultId)
        {
            if (subjectResultId != 0)
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"{StudyCourseApiUrl}/SubjectResults/{subjectResultId}");
                string strData = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                if (!string.IsNullOrEmpty(strData))
                {
                    var resultList = JsonSerializer.Deserialize<SubjectResultResponseDTO>(strData, options);
                    SubjectResults = resultList ?? new SubjectResultResponseDTO();
                }
            }
            await GetData();
        }
    }
}
