using DTO.Request.Subject;
using DTO.Response.Major;
using DTO.Response.Subject;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Subject
{
    public class SubjectViewModel : PageModel
    {
        private readonly HttpClient client;
        private string SubjectApiUrl = "";
        public SubjectCreateDTO SubjectCreate { get; set; } = default!;
        public SubjectUpdateDTO SubjectUpdate { get; set; } = default!;

        public SubjectViewModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";

            Subjects = new List<SubjectResponseDTO>();
        }

        public List<SubjectResponseDTO> Subjects { get; set; }

        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(SubjectApiUrl);
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<SubjectResponseDTO>>(strData, options);
                Subjects = resultList ?? new List<SubjectResponseDTO>();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreate(SubjectResponseDTO SubjectCreate)
        {
            SubjectCreate.UpdatedAt = DateTime.Now;
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";
            var response = client.PostAsJsonAsync(SubjectApiUrl, SubjectCreate).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Add subject successfully!";
                return RedirectToPage("SubjectView");
            }
            else
            {
                TempData["error"] = "Add subject fail!";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostUpdate(SubjectUpdateDTO SubjectUpdate)
        {
            SubjectUpdate.UpdatedAt = DateTime.Now;
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects/{SubjectUpdate.Id}";
            var response = client.PutAsJsonAsync(SubjectApiUrl, SubjectUpdate).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Update subject successfully!";
                return RedirectToPage("SubjectView");
            }
            else
            {
                TempData["error"] = "Update subject fail!";
                return Page();
            }
        }

        public IActionResult OnPostDelete(int subjectId)
        {
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects/{subjectId}";
            var response = client.DeleteAsync(SubjectApiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Delete subject successfully!";
                return RedirectToPage("SubjectView");

            }
            else
            {
                TempData["error"] = "Delete subject fail!";
                return Page();
            }
        }

    }
}
