using DTO.Request.Curricolum;
using DTO.Request.SubjectCurricolum;
using DTO.Response.Curricolum;
using DTO.Response.Major;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FAPClient.Pages.Admin.Curricolum
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient client;
        private string CurricolumApiUrl = "";
        public CurricolumUpdateDTO CurricolumUpdate { get; set; } = default!;

        public UpdateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CurricolumApiUrl = $"{Configuration.ApiURL}/Curricolums";
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage responseMessage = await client.GetAsync(CurricolumApiUrl + $"?$filter=Id eq {id}");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            if (!string.IsNullOrEmpty(strData))
            {
                var resultList = JsonSerializer.Deserialize<List<CurricolumUpdateDTO>>(strData, options);
                CurricolumUpdate = (resultList != null && resultList.Count > 0) ? resultList[0] : null;
            }

            ViewData["Majors"] = new SelectList(await GetMajors(client), "Id", "MajorName");
            return Page();
        }

        public IActionResult OnPost(CurricolumUpdateDTO CurricolumUpdate)
        {
            {
                CurricolumUpdate.UpdatedAt = DateTime.Now;
                CurricolumApiUrl = $"{Configuration.ApiURL}/Curricolums/{CurricolumUpdate.Id}";
                var response = client.PutAsJsonAsync(CurricolumApiUrl, CurricolumUpdate).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Update curricolum successfully!";
                    //return RedirectToPage("CurricolumView");
                    return RedirectToPage("Update");
                }
                else
                {
                    TempData["error"] = "Update curricolum fail!";
                    return Page();
                }
            }
        }

            private async Task<List<MajorResponseDTO>> GetMajors(HttpClient client)
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

    }
}
