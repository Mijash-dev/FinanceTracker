namespace FinanceTracker.DTO.Account;

public record UpdateAccountRequest(
    string Name, decimal Balance
    );