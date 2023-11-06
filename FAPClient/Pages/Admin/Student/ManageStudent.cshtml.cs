using Bussiness.DTO;
using DTO.Request.Account;
using DTO.Request.Student;
using DTO.Response.Major;
using DTO.Response.Student;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProjectPRN_FAP.Pages.Admin.Student
{
    public class ManageStudentModel : PageModel
    {
        private readonly HttpClient client;
        private string StudentApiUrl = "";
        private string MajorApiUrl = "";

        public List<StudentResponseDTO> Students { get; set; }
        public List<MajorResponseDTO> Majors { get; set; }
        [BindProperty]
        public StudentAddDTO StudentAdd { get; set; } = default!;
        
        public StudentUpdateDTO StudentUpdate { get; set; } = default!;
        public ManageStudentModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            StudentApiUrl = $"{Configuration.ApiURL}/Students";
            MajorApiUrl = $"{Configuration.ApiURL}/Majors";
            Students = new List<StudentResponseDTO>();
            Majors = new List<MajorResponseDTO>();
        }


        private async Task GetData()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(StudentApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<StudentResponseDTO>>(strData, options);
                Students = resultList ?? new List<StudentResponseDTO>();
            }

            responseMessage = await client.GetAsync(MajorApiUrl);
            strData = await responseMessage.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<MajorResponseDTO>>(strData, options);
                Majors = resultList ?? new List<MajorResponseDTO>();
            }
        }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPostAdd(StudentAddDTO StudentAdd)
        {
            
            var response = await client.PostAsJsonAsync(StudentApiUrl, StudentAdd);
            var check = response.Content;
            await GetData();
            return Page();
        }

        public async Task OnPostUpdate(StudentUpdateDTO StudentUpdate)
        {
            var response = await client.PutAsJsonAsync($"{StudentApiUrl}/{StudentUpdate.Rollnumber}", StudentUpdate);
            var check = response.IsSuccessStatusCode;
            await GetData();
        }

        public async Task OnPostDelete(string rollnumber)
        {
            var response = await client.DeleteAsync($"{StudentApiUrl}/{rollnumber}");
            var check = response.IsSuccessStatusCode;
            await GetData();

        }
    }
}
