using DTO.Request.Account;
using DTO.Response.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAccountRepository accountRepository, IStudentRepository studentRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _studentRepository = studentRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest login)
        {
            var account = _accountRepository.Login(login.Email, login.Password);
            if (account != null)
            {
                var authenClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Sid, account.Id.ToString()),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, account.Roleid.ToString())
                };
                switch (account.Roleid)
                {
                    case 1:
                        authenClaims.Add(new Claim(ClaimTypes.SerialNumber, account.Id.ToString()));
                        break;
                    case 2:
                        authenClaims.Add(new Claim(ClaimTypes.SerialNumber, account.Id.ToString()));
                        break;
                    case 3:
                        var student = _studentRepository.GetStudentByAccountId(account.Id);
                        authenClaims.Add(new Claim(ClaimTypes.SerialNumber, student.Rollnumber));
                        break;
                    default:
                        break;
                }

                var token = GetToken(authenClaims);

                return Ok(new LoginResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });

            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
