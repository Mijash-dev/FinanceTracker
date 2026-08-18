namespace FinanceTracker.Service.Interface;

using FinanceTracker.Entities;
using FinanceTracker.Repository.Interface;
using FinanceTracker.Service.Interface;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<List<Account>> GetAccountsByUserIdAsync(int UserId)
    {
        return await _accountRepository.GetAccountsByUserIdAsync(UserId);
    }
    public async Task<Account?> GetAccountAsync(int UserId, int AccountId)
    {
        var account = await _accountRepository.GetAccountByIdAsync(AccountId);
        if (account == null || account.UserId != UserId)
        {
            return null;
        }
        return account;
    }
    public async Task<Account> CreateAccountAsync(int UserId, string Name, decimal Balance)
    {
        var account = new Account
        {
            UserId = UserId,
            Name = Name,
            Balance = Balance
        };
        await _accountRepository.AddAccountAsync(account);
        return account;
    }
    public async Task<bool> UpdateAccountAsync(int UserId, int AccountId, string Name, decimal Balance)
    {
        var account = await _accountRepository.GetAccountByIdAsync(AccountId);
        if (account == null || account.UserId != UserId)
        {
            return false;
        }
        account.Name = Name;
        account.Balance = Balance;
        await _accountRepository.UpdateAccountAsync(account);
        return true;
    }
    public async Task<bool> DeleteAccountAsync(int UserId, int AccountId)
    {
        var account = await _accountRepository.GetAccountByIdAsync(AccountId);
        if (account == null || account.UserId != UserId)
        {
            return false;
        }
        await _accountRepository.DeleteAccountAsync(AccountId);
        return true;
    }
}