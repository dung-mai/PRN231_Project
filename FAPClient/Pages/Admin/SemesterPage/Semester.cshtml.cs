using BusinessObject.Models;
using DTO.Response.Major;
using DTO.Response.Semester;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProjectPRN_FAP.Pages.Admin
{
    //[Authorize(Roles = "1")]
    public class SemesterModel : PageModel
    {

        private readonly HttpClient client;
        private string MajorApiUrl = "";

        public List<SemesterResponseDTO> Semesters { get; set; }
        public SemesterModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MajorApiUrl = $"{Configuration.ApiURL}/Semesters";
            Semesters = new List<SemesterResponseDTO>();
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
                var resultList = JsonSerializer.Deserialize<List<SemesterResponseDTO>>(strData, options);
                Semesters = resultList ?? new List<SemesterResponseDTO>();
            }
        }

        public async Task<IActionResult> OnGet()
        {
            await GetData();
            return Page();
        }

        public void OnPost(String semesterName, DateTime semesterStartDate, DateTime semesterEndDate)
        {
            //SemesterDTO semester = new SemesterDTO()
            //{
            //    SemesterName = semesterName,
            //    StartDate = semesterStartDate,
            //    EndDate = semesterEndDate,
            //};
            //_semesterRepository.Create(semester);
            //GetData();
        }

        public void OnPostUpdate(String semesterName, DateTime semesterStartDate, DateTime semesterEndDate, int semesterId)
        {
            //SemesterDTO semester = _semesterRepository.GetById(semesterId);
            //semester.SemesterName = semesterName;
            //semester.StartDate = semesterStartDate;
            //semester.EndDate = semesterEndDate;
            //_semesterRepository.Update(semester);
            //GetData();

        }

        public void OnPostDelete(int semesterId)
        {
            //SemesterDTO semester = _semesterRepository.GetById(semesterId);
            //_semesterRepository.Delete(semester);
            //GetData();

        }
    }
}
