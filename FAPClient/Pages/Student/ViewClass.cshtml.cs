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
        private string SubjectResultApiUrl = "";
        private string StudyCourseApiUrl = "";
        public SubjectResultStudentResponseDTO SubjectResults { get; set; }
        public List<StudyCourseResponseAllDTO> StudyCourses { get; set; }
        public int SubjectId { get; set; }  
        public int SubjectGradeId { get; set; }

        public ViewClassModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SubjectResultApiUrl = $"{Configuration.ApiURL}/SubjectResults";
            StudyCourseApiUrl = $"{Configuration.ApiURL}/StudyCourses";
            SubjectGradeId = 0;
            SubjectId = 0;
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
                HttpResponseMessage responseMessage = await client.GetAsync($"{SubjectResultApiUrl}/{subjectResultId}");
                string strData = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                if (!string.IsNullOrEmpty(strData))
                {
                    var resultList = JsonSerializer.Deserialize<SubjectResultStudentResponseDTO>(strData, options);
                    SubjectResults = resultList ?? new SubjectResultStudentResponseDTO();
                }
            }
            await GetData();
        }
    }
}
