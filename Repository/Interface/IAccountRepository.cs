namespace FinanceTracker.Repository.Interface;

using FinanceTracker.Entities;

public interface IAccountRepository
{
    Task<Account> GetAccountByIdAsync(int Id);
    Task<List<Account>> GetAccountsByUserIdAsync(int UserId);
    Task AddAccountAsync(Account account);
    Task UpdateAccountAsync(Account account);
    Task DeleteAccountAsync(int Id);
}