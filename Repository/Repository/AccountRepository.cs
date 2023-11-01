﻿using AutoMapper;
using BusinessObject.Models;
using DataAccess.Managers;
using DTO.Request.Account;
using DTO.Response.Account;
using Repository.IRepository;

namespace Repository.Repository
{
    public class AccountRepository : IAccountRepository
    {
        FAPDbContext _context;
        IMapper _mapper;

        public AccountRepository(FAPDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AccountResponseDTO? GetAccountByEmail(string email)
        {
            AccountDAO manager = new AccountDAO(_context);
            Account? account = manager.GetAccountByEmail(email);
            return account is null ? null : _mapper.Map<AccountResponseDTO>(account);
        }

        public AccountResponseDTO? GetAccountLastIndex()
        {
            AccountDAO manager = new AccountDAO(_context);
            return _mapper.Map<AccountResponseDTO>(manager.GetAccountLastIndex());
        }

        public bool DeleteAccount(int id)
        {
            try
            {
                AccountDAO accountDAO = new AccountDAO(_context);
                accountDAO.DeleteAccount(id);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AccountResponseDTO? GetAccount(int id)
        {
            AccountDAO accountDAO = new AccountDAO(_context);
            return _mapper.Map<AccountResponseDTO>(accountDAO.GetAccount(id));
        }

        public IQueryable<AccountResponseDTO> GetAccounts()
        {
            AccountDAO accountDAO = new AccountDAO(_context);
            List<Account> accounts = accountDAO.GetAccounts();
            return accounts.Select(a => _mapper.Map<AccountResponseDTO>(a)).AsQueryable();
        }

        public bool SaveAccount(AccountCreateDTO account)
        {
            try
            {
                AccountDAO accountDAO = new AccountDAO(_context);
                bool result = accountDAO.AddAccount(_mapper.Map<Account>(account));
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAccount(AccountUpdateDTO account)
        {
            try
            {
                AccountDAO accountDAO = new AccountDAO(_context);
                bool result = accountDAO.UpdateAccount(_mapper.Map<Account>(account));
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateAccountStudent(AccountCreateStudentDTO account)
        {
            try
            {
                AccountDAO accountDAO = new AccountDAO(_context);
                Account accStudent = _mapper.Map<Account>(account);
                accStudent.Email = "abc@fpt.edu.vn";
                accStudent.Password = "123";
                accStudent.Roleid = 3;
                accStudent.Status = 1;
                accStudent.IsDelete = false;
                bool result = accountDAO.AddAccount(accStudent);
                if (result)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
