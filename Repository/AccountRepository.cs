namespace FinanceTracker.Repository;

using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Repository.Interface;
using Microsoft.EntityFrameworkCore;

public class AccountRepository : IAccountRepository
{
    private readonly FinanceDbContext _context;
    public AccountRepository(FinanceDbContext context)
    {
        _context = context;
    }
    public async Task<Account> GetAccountByIdAsync(int Id)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(a => a.Id == Id);
    }

    public async Task<List<Account>> GetAccountsByUserIdAsync(int UserId)
    {
        return await _context.Accounts
            .Where(a => a.UserId == UserId)
            .ToListAsync();
    }

    public async Task AddAccountAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAccountAsync(int Id)
    {
        var account = await _context.Accounts.FindAsync(Id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}