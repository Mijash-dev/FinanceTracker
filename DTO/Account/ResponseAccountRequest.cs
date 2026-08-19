namespace FinanceTracker.DTO.Account;

public record ResponseAccountRequest(
    int Id,
    string Name,
    decimal Balance
    );