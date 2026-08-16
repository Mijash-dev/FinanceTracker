namespace FinanceTracker.Entities;

public class user
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Email {  get; set; }
    public int CreatedAt { get; set; }
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    public ICollection<Category> Category { get; set; } = new List<Category>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}