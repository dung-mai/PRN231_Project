﻿using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

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
                                    .FirstOrDefault(a => a.Email == email && !a.IsDelete);
        }

        public Account? Login(string Email, string password)
        {
            return _context.Accounts.Include(a => a.Role)
                .FirstOrDefault(a => a.Email == Email && a.Password == password && !a.IsDelete);
        }
        public List<Account> GetAccounts()
        {
            return _context.Accounts
                .Where(a => !a.IsDelete)
                .ToList();
        }

        public Account? GetAccount(int id)
        {
            return _context.Accounts
                .FirstOrDefault(a => a.Id == id && !a.IsDelete);
        }

        public Account? GetAccountLastIndex()
        {
            return _context.Accounts.OrderBy(a => a.Id).LastOrDefault();
        }

        public bool AddAccount(Account account)
        {
            if (account != null)
            {
                _context.Accounts.Add(account);
                return true;
            }
            return false;
        }

        public bool DeleteAccount(int accountId)
        {
            Account? account = _context.Accounts.FirstOrDefault(a => a.Id == accountId && !a.IsDelete);
            if (account != null)
            {
                account.IsDelete = true;
                account.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool UpdateAccount(Account _account)
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
                account.Address = _account.Address;
                account.Image = _account.Image;
                account.Status = _account.Status;
                account.UpdatedAt = DateTime.Now;
                account.UpdatedBy = _account.UpdatedBy;
                account.IsDelete = _account.IsDelete;
                return true;
            }
            return false;
        }

        public bool UpdateAccountStudent(Account _account)
        {
            Account? account = _context.Accounts
                .FirstOrDefault(a => a.Id == _account.Id);
            if (account != null)
            {
                account.Phonenumber = _account.Phonenumber;
                account.Gender = _account.Gender;
                account.Address = _account.Address;
                account.Image = _account.Image;
                account.Status = _account.Status;
                account.UpdatedAt = DateTime.Now;
                return true;
            }
            return false;
        }
    }
}
