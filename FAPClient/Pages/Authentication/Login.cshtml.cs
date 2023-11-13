using DTO.Request.Account;
using FAPAplicationAPI.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using DTO.Response.Account;
using BusinessObject.Models;

namespace FAPClient.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client = null;
        private string Authapi = "";

        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            Authapi = $"{Configuration.ApiURL}/Auth/Login";
        }
        public LoginRequest login { get; set; }
        public IActionResult OnGet()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            var role = claimUser.FindFirstValue(ClaimTypes.Role);
            if (claimUser.Identity.IsAuthenticated)
            {
                switch (role)
                {
                    case "1":
                        return RedirectToPage("/Admin/SemesterPage/Semester");
                    case "2":
                        return RedirectToPage("/Teacher/Class/ListClass");
                    case "3":
                        return RedirectToPage("/Student/ViewClass");
                    default:
                        break;
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string email, string password)
        {
            var jwt = await LoginAsync(email, password);
            if (!string.IsNullOrEmpty(jwt))
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddHours(1)
                };
                Response.Cookies.Append("jwt", jwt, cookieOptions);

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;
                if (jsonToken != null)
                {
                    var claims = jsonToken.Claims;
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);
                    return RedirectToPage("/Authentication/Login");
                }
            }
            return Page();

        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var loginRequest = new LoginRequest()
            {
                Email = email,
                Password = password
            };
            var response = await client.PostAsJsonAsync(Authapi, loginRequest);
            var strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var jwt = JsonSerializer.Deserialize<LoginResponse>(strData, options);
            return jwt.Token;
        }
    }
}
