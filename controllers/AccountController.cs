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
        return Ok(response);
    }
    [HttpGet("{Id:int}")]
    public async Task<ActionResult<ResponseAccountRequest>> GetAccount(int Id)
    {
        var UserId = 1;
        var account = await _service.GetAccountAsync(UserId, Id);
        if (account == null)
        {
            return NotFound();
        }
        var response = new ResponseAccountRequest(account.Id, account.Name, account.Balance);
        return Ok(response); 
    }
    [HttpPost]
    public async Task<ActionResult<ResponseAccountRequest>> CreateAccount (CreateAccountRequest request)
    {
        var UserID = 1;
        var account = await _service.CreateAccountAsync(UserID,request.Name, request.Balance);
        var response = new ResponseAccountRequest(account.Id, account.Name, account.Balance);
        return CreatedAtAction ( nameof(GetAccount),new {Id = account.Id}, response);
    }
    [HttpPut("{Id:int}")]
    public async Task<ActionResult<ResponseAccountRequest>> UpdateAccount (UpdateAccountRequest request, int Id)
    {
        var UserID = 1;
        var update = await _service.UpdateAccountAsync(UserID,Id,request.Name, request.Balance);
        if (!update){ return NotFound(); }
        var account = await _service.GetAccountAsync(UserID,Id);
        if (account == null) { return NotFound(); }
        var response = new ResponseAccountRequest(account.Id, account.Name, account.Balance);
        return Ok(response);
    }
    [HttpDelete("{Id:int}")]
    public async Task<ActionResult> DeleteAccount(int Id) {
        var UserID = 1;
        var Delete = await _service.DeleteAccountAsync(UserID, Id);
        if (!Delete) { return NotFound(); }
        return NoContent();
    }
}

