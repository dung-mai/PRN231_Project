namespace Repository.IRepository
{
    public interface IAccountRepository
    {
        AccountDTO? GetAccountByEmail(string email);
    }
}
