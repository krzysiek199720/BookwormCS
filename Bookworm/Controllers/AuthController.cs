using Bookworm.Data;
using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers;

public class AuthController : ApiBaseController
{
    private readonly ITokenService _tokenService;
    private readonly DataContext _dataContext;
    private readonly UserManager<AppUser> _userManager;

    public AuthController(ITokenService tokenService, DataContext dataContext, UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _dataContext = dataContext;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginDto>> Login(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        if (user == null)
            return Unauthorized("Invalid credentials");
        var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
        if(!result) 
            return Unauthorized("Invalid credentials");

        var token = await _tokenService.CreateToken(user);
        
        return user.ToLoginDto(token);
    }
}