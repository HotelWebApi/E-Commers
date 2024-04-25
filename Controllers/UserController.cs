using DataAccessLayer.AuthDTOs;
using Microsoft.AspNetCore.Mvc;
using Trainers.Interfaces;

namespace Trainers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterRequest userRegister)
    {
        try
        {
            var register = await _userService.UserRegister(userRegister);
            if (register.Success)
            {
                return Ok("Registered");
            }
            else
            {
                return BadRequest(register.Message);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
    {
        try
        {
            var login = await _userService.UserLogin(userLoginRequest);
            if (login.Success)
            {
                return Ok("Login successfull");
            }
            else { return BadRequest(login.Message); }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}