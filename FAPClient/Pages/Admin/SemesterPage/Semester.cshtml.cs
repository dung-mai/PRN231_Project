using BusinessObject.Models;
using DTO.Request.Semester;
using DTO.Response.Semester;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectPRN_FAP.Pages.Admin
{
    //[Authorize(Roles = "1")]
    public class SemesterModel : PageModel
    {

        private readonly HttpClient client;
        private string SemesterApiUrl = "";

        public List<SemesterResponseDTO> Semesters { get; set; }
        public SemesterAddDTO SemesterAdd { get; set; } = default!;
        [BindProperty]
        public SemesterUpdateDTO SemesterUpdate { get; set; } = default!;
        public SemesterModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SemesterApiUrl = $"{Configuration.ApiURL}/Semesters";
            Semesters = new List<SemesterResponseDTO>();
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
        }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPost(SemesterAddDTO SemesterAdd)
        {

            if (!ModelState.IsValid || SemesterAdd == null)
            {
                return Page();
            }
            var response = client.PostAsJsonAsync(SemesterApiUrl, SemesterAdd).Result;
            var check = response.IsSuccessStatusCode;
            await GetData();
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate(SemesterUpdateDTO SemesterUpdate)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var response = client.PutAsJsonAsync($"{SemesterApiUrl}/{SemesterUpdate.Id}", SemesterUpdate).Result;
            var check = response.IsSuccessStatusCode;
            await GetData();
            return Page();

        }

        public async Task OnPostDelete(int semesterId)
        {
            var response = client.DeleteAsync($"{SemesterApiUrl}/{semesterId}").Result;
            var check = response.IsSuccessStatusCode;
            await GetData();

        }
    }
}
