namespace FinanceTracker.Service.Interface;
using FinanceTracker.Entities;

public interface IAccountService
{
    Task<List<Account>> GetAccountsByUserIdAsync(int UserId);
    Task<Account?> GetAccountAsync(int UserId, int AccountId);
    Task <Account> CreateAccountAsync(int UserId, string Name, decimal Balance);
    Task <bool> UpdateAccountAsync(int UserId, int AccountId, string Name, decimal Balance);
    Task <bool> DeleteAccountAsync(int UserId, int AccountId);
}