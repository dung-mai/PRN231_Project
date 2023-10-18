using AutoMapper;
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
                int result = accountDAO.AddAccount(_mapper.Map<Account>(account));
                if (result > 0)
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

        public void UpdateAccount(AccountUpdateDTO account)
        {
            AccountDAO accountDAO = new(_context);
            accountDAO.UpdateAccount(_mapper.Map<Account>(account));
            _context.SaveChanges();
        }
    }
}
