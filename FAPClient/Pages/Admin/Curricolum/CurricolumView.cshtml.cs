using DTO.Request.Curricolum;
using DTO.Request.SubjectCurricolum;
using DTO.Response.Curricolum;
using DTO.Response.Major;
using DTO.Response.Semester;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Curricolum
{
    public class CurricolumViewModel : PageModel
    {
        private readonly HttpClient client;
        private string CurricolumApiUrl = "";
        public CurricolumCreateDTO CurricolumCreate { get; set; } = default!;
        public CurricolumUpdateDTO CurricolumUpdate { get; set; } = default!;

        public CurricolumViewModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CurricolumApiUrl = $"{Configuration.ApiURL}/Curricolums";

            Curricolums = new List<CurricolumResponseDTO>();
        }

        public List<CurricolumResponseDTO> Curricolums { get; set; }

        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(CurricolumApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<CurricolumResponseDTO>>(strData, options);
                Curricolums = resultList ?? new List<CurricolumResponseDTO>();
            }

            ViewData["Majors"] = new SelectList(await GetMajors(client), "Id", "MajorName");
            List<SemesterResponseDTO> semesterResponses = await GetSemesters(client);
            ViewData["Semesters"] = new SelectList(semesterResponses.Select(s => new
            {
                Id = s.Id,
                Semester = s.SemesterName + " " + s.Year
            }), "Id", "Semester");
            return Page();
        }

        public async Task<IActionResult> OnPostCreate(CurricolumCreateDTO CurricolumCreate)
        {
            CurricolumCreate.UpdatedAt = DateTime.Now;
            CurricolumApiUrl = $"{Configuration.ApiURL}/Curricolums";
            var response = client.PostAsJsonAsync(CurricolumApiUrl, CurricolumCreate).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Add curricolum successfully!";
                return RedirectToPage("CurricolumView");
            }
            else
            {
                TempData["error"] = "Add curricolum fail!";
                return Page();
            }
        }

        public IActionResult OnPostDelete(int curricolumId)
        {
            CurricolumApiUrl = $"{Configuration.ApiURL}/Curricolums/{curricolumId}";
            var response = client.DeleteAsync(CurricolumApiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Delete curricolum successfully!";
                return RedirectToPage("CurricolumView");

            }
            else
            {
                TempData["error"] = "Delete curricolum fail!";
                return Page();
            }
        }

        public static async Task<List<MajorResponseDTO>> GetMajors(HttpClient client)
        {
            string MajorApiUrl = $"{Configuration.ApiURL}/Majors";

            HttpResponseMessage responseMessage = await client.GetAsync(MajorApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var resultList = JsonSerializer.Deserialize<List<MajorResponseDTO>>(strData, options);
            return resultList ?? new List<MajorResponseDTO>();
        }

        public static async Task<List<SemesterResponseDTO>> GetSemesters(HttpClient client)
        {
            string SemesterApiUrl = $"{Configuration.ApiURL}/Semesters";

            HttpResponseMessage responseMessage = await client.GetAsync(SemesterApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var resultList = JsonSerializer.Deserialize<List<SemesterResponseDTO>>(strData, options);
            return resultList ?? new List<SemesterResponseDTO>();
        }
    }
}
