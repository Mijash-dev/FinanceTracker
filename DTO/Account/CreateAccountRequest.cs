namespace FinanceTracker.DTO.Account;

public record CreateAccountRequest(
    string Name, decimal Balance
    );