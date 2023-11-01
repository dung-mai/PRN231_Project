using Bussiness.DTO;
using DTO.Request.Account;
using DTO.Request.Student;
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

        public List<StudentResponseDTO> Students { get; set; }
        public StudentAddDTO StudentAdd { get; set; } = default!;
        public AccountCreateDTO AccountCreate { get; set; } = default!;
        [BindProperty]
        public StudentUpdateDTO StudentUpdate { get; set; } = default!;
        public ManageStudentModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            StudentApiUrl = $"{Configuration.ApiURL}/Students";
            Students = new List<StudentResponseDTO>();
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
        }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPost(StudentAddDTO StudentAdd)
        {

            if (!ModelState.IsValid || StudentAdd == null)
            {
                return Page();
            }
            var response = client.PostAsJsonAsync(StudentApiUrl, StudentAdd).Result;
            var check = response.IsSuccessStatusCode;
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate(StudentUpdateDTO StudentUpdate)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var response = client.PutAsJsonAsync($"{StudentApiUrl}/{StudentUpdate.Rollnumber}", StudentUpdate).Result;
            var check = response.IsSuccessStatusCode;
            await GetData();
            return Page();

        }

        public async Task OnPostDelete(int semesterId)
        {
            var response = client.DeleteAsync($"{StudentApiUrl}/{semesterId}").Result;
            var check = response.IsSuccessStatusCode;
            await GetData();

        }
    }
}
