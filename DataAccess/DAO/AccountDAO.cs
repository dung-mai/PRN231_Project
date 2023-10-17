using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Managers
{
    public class AccountDAO
    {
        FAPDbContext _context;
        public AccountDAO(FAPDbContext context)
        { 
            _context = context;
        }

        public Account? GetAccountByEmail(string email)
        {
            return _context.Accounts.Include(a => a.Role)
                                    .FirstOrDefault(a => a.Email == email);
        }
    }
}
