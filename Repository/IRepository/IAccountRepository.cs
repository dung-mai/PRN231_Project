﻿using DTO.Request.Account;
using DTO.Response.Account;

namespace Repository.IRepository
{
    public interface IAccountRepository
    {
        AccountResponseDTO? GetAccountByEmail(string email);
        IQueryable<AccountResponseDTO> GetAccounts();
        AccountResponseDTO? GetAccount(int id);
        AccountResponseDTO? GetAccountLastIndex();
        bool UpdateAccount(AccountUpdateDTO account);
        bool SaveAccount(AccountCreateDTO account);
        bool CreateAccountStudent(AccountCreateStudentDTO account);
        bool DeleteAccount(int id);
    }
}
