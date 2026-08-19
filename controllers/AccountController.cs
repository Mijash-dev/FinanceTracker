using FinanceTracker.DTO.Account;
using FinanceTracker.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;
    public AccountController( IAccountService _service)
    {
        _service = _service;
    }
    [HttpGet]
    public async Task<ActionResult<List<ResponseAccountRequest>>> GetAccounts()
    {
        var UserId = 1;
        var accounts = await _service.GetAccountsByUserIdAsync(UserId);
        var response = accounts.Select(account => new ResponseAccountRequest(account.Id, account.Name, account.Balance));
        return ok(response);
    }
    [HttpGet("{Id:int}")]
    public async Task<ActionResult<List<ResponseAccountRequest>>> GetAccount(int Id)
    {
        var UserId = 1;
        var account = awit _service.GetAccountAsync(UserId, Id);
        if (account == null)
        {
            return NotFound();
        }
        var response = account.Select(account => new ResponseAccountRequest(account.Id, Account.Name, account.Balance));
        return ok(response); 
    }
    [HttpPost]
    public async Task<ActionResult<List<ResponseAccountRequest>>> CreateAccount (CreateAccountRequest request)

}

