using DTO.Request.GradeComponent;
using DTO.Request.Subject;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Subject
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient client;
        private string SubjectApiUrl = "";
        public SubjectUpdateDTO SubjectUpdate { get; set; } = default!;

        public UpdateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SubjectApiUrl = $"{Configuration.ApiURL}/Subjects";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage responseMessage = await client.GetAsync(SubjectApiUrl + $"?$filter=Id eq {id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<SubjectUpdateDTO>>(strData, options);
                SubjectUpdate = (resultList != null && resultList.Count > 0) ? resultList[0] : null;
                GradeComponentUpdateDTO? finalResit = SubjectUpdate.GradeComponents.FirstOrDefault(gc => gc.GradeItem == "Final Exam Resit");
                if (finalResit != null)
                {
                    SubjectUpdate.GradeComponents.Remove(finalResit);
                }
            }

            return Page();
        }

        public IActionResult OnPost(SubjectUpdateDTO SubjectUpdate)
        {
            {
                SubjectUpdate.UpdatedAt = DateTime.Now;
                SubjectApiUrl = $"{Configuration.ApiURL}/Subjects/{SubjectUpdate.Id}";
                var response = client.PutAsJsonAsync(SubjectApiUrl, SubjectUpdate).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Update subject successfully!";
                    //return RedirectToPage("SubjectView");
                    return RedirectToPage("Update");
                }
                else
                {
                    TempData["error"] = "Update subject fail!";
                    return Page();
                }
            }
        }
    }
}
