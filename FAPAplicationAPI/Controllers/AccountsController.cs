using DTO.Request.Account;
using DTO.Response.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Repository.IRepository;

namespace FAPAplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: api/Accounts
        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<AccountResponseDTO>> GetAccounts()
        {
            return Ok(_accountRepository.GetAccounts());
        }

        //// GET: api/Accounts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Account>> GetAccount(int id)
        //{

        //    var account = await _context.Accounts.FindAsync(id);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return account;
        //}

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public IActionResult PutAccount(int id, AccountUpdateDTO account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            if (_accountRepository.UpdateAccount(account))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Account");
            }
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAccount(AccountCreateDTO account)
        {
            if (_accountRepository.SaveAccount(account))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Account");
            }
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var account = _accountRepository.GetAccount(id);
            if (account == null)
            {
                return NotFound();
            }

            if (_accountRepository.DeleteAccount(id))
            {
                return NoContent();
            }
            else
            {
                return Problem("Problem when Adding Account");
            }
        }
    }
}
