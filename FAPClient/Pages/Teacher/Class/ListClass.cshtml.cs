using DTO.Request.Student;
using DTO.Response.Major;
using DTO.Response.Student;
using DTO.Response.SubjectOfClass;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Teacher.Class
{
    public class ListClassModel : PageModel
    {
        private readonly HttpClient client;
        private string ClassOfSubjectApiUrl = "";
        private string TeacherApiUrl = "";

        public List<SubjectOfClassResponseDTO> SubjectOfClasses { get; set; }
        public ListClassModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ClassOfSubjectApiUrl = $"{Configuration.ApiURL}/SubjectOfClasses";
            SubjectOfClasses = new List<SubjectOfClassResponseDTO>();
        }


        private async Task GetData()
        {
            int teacherId = 1007;
            HttpResponseMessage responseMessage = await client.GetAsync($"{ClassOfSubjectApiUrl}/GetByTeacherId?teacherId={teacherId}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<SubjectOfClassResponseDTO>>(strData, options);
                SubjectOfClasses = resultList ?? new List<SubjectOfClassResponseDTO>();
            }
           
        }

        public async Task OnGet()
        {
            await GetData();
        }

        
    }
}
