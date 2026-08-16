using Microsoft.EntityFrameworkCore;
namespace FinanceTracker.Data;

public class FinanceDbContext : Dbcontext
{
    public FinanceDbContext(
        DbContextoptions<FinanceDbContext> options) : base(options)
    {

    }

}