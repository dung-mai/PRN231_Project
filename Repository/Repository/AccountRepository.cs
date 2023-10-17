using AutoMapper;
using BusinessObject.Models;
using DataAccess.Managers;
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

        public AccountDTO? GetAccountByEmail(string email)
        {
            AccountDAO manager = new AccountDAO(_context);
            Account? account = manager.GetAccountByEmail(email);
            return account is null ? null : _mapper.Map<AccountDTO>(account);
        }
    }
}
