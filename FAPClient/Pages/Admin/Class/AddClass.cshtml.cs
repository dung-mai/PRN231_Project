using DTO.Request.Student;
using DTO.Response.Class;
using DTO.Response.Curricolum;
using DTO.Response.Major;
using DTO.Response.Semester;
using DTO.Response.Student;
using DTO.Response.SubjectOfClass;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Class
{
    public class AddClassModel : PageModel
    {
        private readonly HttpClient client;
        private string SemesterApiUrl = "";
        private string CurricolumnApiUrl = "";
        private string ClassessApiUrl = "";

        public List<SemesterResponseDTO> Semesters { get; set; }
        public List<CurricolumResponseDTO> Curricolums { get; set; }
        [BindProperty]
        public List<ClassReponseAddDTO> ClassReponseAddDTOs { get; set; }
        public AddClassModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SemesterApiUrl = $"{Configuration.ApiURL}/Semesters";
            CurricolumnApiUrl = $"{Configuration.ApiURL}/Curricolums";
            ClassessApiUrl = $"{Configuration.ApiURL}/Classes";
            Semesters = new List<SemesterResponseDTO>();
            Curricolums = new List<CurricolumResponseDTO>();
        }


        private async Task GetData()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(SemesterApiUrl);
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

            responseMessage = await client.GetAsync(CurricolumnApiUrl);
            strData = await responseMessage.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<CurricolumResponseDTO>>(strData, options);
                Curricolums = resultList ?? new List<CurricolumResponseDTO>();
            }
        }

        private async Task GetListClass(int semesterId, int curricolumnId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"{ClassessApiUrl}/CreateClassOfSubject?semesterId={semesterId}&curricolumnId={curricolumnId}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<ClassReponseAddDTO>>(strData, options);
                ClassReponseAddDTOs = resultList ?? new List<ClassReponseAddDTO>();
            }
        }

        public async Task OnGet(int? semesterId, int? curricolumnId)
        {
            await GetData();
            if(semesterId.HasValue && curricolumnId.HasValue)
            {
                await GetListClass((int)semesterId, (int)curricolumnId);
            }
        }

        public async Task OnPostAddClass()
        {
            string classReponseAddDTOsJson = Request.Form["ClassReponseAddDTOsJson"];

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            // Deserialize the JSON string into a list of objects
            List<ClassReponseAddDTO> classReponseAddDTOs = JsonSerializer.Deserialize<List<ClassReponseAddDTO>>(classReponseAddDTOsJson, options);
            var response = await client.PostAsJsonAsync($"{ClassessApiUrl}/CreateClassOfSubject", classReponseAddDTOs);
            var check = response.Content;
            await GetData();

            // Takeback data ClassReponseAddDTOs.
        }

    }
}
