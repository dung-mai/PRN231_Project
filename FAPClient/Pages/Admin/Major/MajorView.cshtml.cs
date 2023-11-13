using BusinessObject.Models;
using DTO.Response.Major;
using DTO.Response.Semester;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Major
{
    public class MajorViewModel : PageModel
    {
        private readonly HttpClient client;
        private string MajorApiUrl = "";

        public MajorViewModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MajorApiUrl = $"{Configuration.ApiURL}/Majors";

            Majors = new List<MajorResponseDTO>();
        }

        public List<MajorResponseDTO> Majors { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        private async Task GetData()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(MajorApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<MajorResponseDTO>>(strData, options);
                Majors = resultList ?? new List<MajorResponseDTO>();
            }
        }

        public async Task<IActionResult> OnPostCreate(MajorResponseDTO major)
        {
            major.UpdatedAt = DateTime.Now;
            MajorApiUrl = $"{Configuration.ApiURL}/Majors";
            var response = client.PostAsJsonAsync(MajorApiUrl, major).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Add major successfully!";
                await GetData();
                return Page();
            }
            else
            {
                TempData["error"] = "Add major fail!";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostUpdate(MajorResponseDTO major)
        {
            major.UpdatedAt = DateTime.Now;
            MajorApiUrl = $"{Configuration.ApiURL}/Majors/{major.Id}";
            var response = client.PutAsJsonAsync(MajorApiUrl, major).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Update major successfully!";
                await GetData();
                return RedirectToPage("MajorView");
            }
            else
            {
                TempData["error"] = "Update major fail!";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDelete(int majorId)
        {
            MajorApiUrl = $"{Configuration.ApiURL}/Majors/{majorId}";
            var response = client.DeleteAsync(MajorApiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Delete major successfully!";
                await GetData();
                return RedirectToPage("MajorView");

            }
            else
            {
                TempData["error"] = "Delete major fail!";
                return Page();
            }
        }
    }
}
