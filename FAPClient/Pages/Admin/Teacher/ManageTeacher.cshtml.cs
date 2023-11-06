using DTO.Request.Teacher;
using DTO.Response.Major;
using DTO.Response.Teacher;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Teacher
{
    public class ManageTeacherModel : PageModel
    {
        private readonly HttpClient client;
        private string TeacherApiUrl = "";
        private string MajorApiUrl = "";

        public List<TeacherResponseDTO> Teachers { get; set; }
        [BindProperty]
        public TeacherAddDTO TeacherAdd { get; set; } = default!;

        public TeacherUpdateDTO TeacherUpdate { get; set; } = default!;
        public ManageTeacherModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TeacherApiUrl = $"{Configuration.ApiURL}/Teachers";
            Teachers = new List<TeacherResponseDTO>();
        }


        private async Task GetData()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(TeacherApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<TeacherResponseDTO>>(strData, options);
                Teachers = resultList ?? new List<TeacherResponseDTO>();
            }
           
        }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPostAdd(TeacherAddDTO TeacherAdd)
        {

            var response = await client.PostAsJsonAsync(TeacherApiUrl, TeacherAdd);
            var check = response.Content;
            await GetData();
            return Page();
        }

        public async Task OnPostUpdate(TeacherUpdateDTO TeacherUpdate)
        {
            var response = await client.PutAsJsonAsync($"{TeacherApiUrl}/{TeacherUpdate.AccountId}", TeacherUpdate);
            var check = response.IsSuccessStatusCode;
            await GetData();
        }

        public async Task OnPostDelete(string accountId)
        {
            var response = await client.DeleteAsync($"{TeacherApiUrl}/{accountId}");
            var check = response.IsSuccessStatusCode;
            await GetData();

        }
    }
}
