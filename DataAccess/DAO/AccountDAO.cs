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

        public List<Account> GetAccounts()
        {
            return _context.Accounts
                .ToList();
        }

        public Account? GetAccount(int id)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.Id == id);
        }

        public int AddAccount(Account account)
        {
            if (account != null)
            {
                _context.Accounts.Add(account);
                return 1;
            }
            return 0;
        }

        public int DeleteAccount(int accountId)
        {
            Account? account = _context.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                return 1;
            }
            return 0;
        }

        public int UpdateAccount(Account _account)
        {
            Account? account = _context.Accounts
                .FirstOrDefault(a => a.Id == _account.Id);
            if (account != null)
            {
                account.Email = _account.Email;
                account.Password = _account.Password;
                account.Phonenumber = _account.Phonenumber;
                account.Gender = _account.Gender;
                account.IdCard = _account.IdCard;
                account.Dob = _account.Dob;
                account.Firstname = _account.Firstname;
                account.Lastname = _account.Lastname;
                account.Address = _account.Middlename;
                account.Image = _account.Middlename;
                account.Status = _account.Status;
                account.UpdatedAt = _account.UpdatedAt;
                account.UpdatedBy = _account.UpdatedBy;
                account.IsDelete = _account.IsDelete;
                return 1;
            }
            return 0;
        }
    }
}
