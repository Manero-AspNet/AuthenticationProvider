using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/auth/[controller]")]
[ApiController]
public class SignInController(SignInManager<UserEntity> signInManager) : ControllerBase
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpPost]
    public async Task<IActionResult> SignIn (SignIn model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync (model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return Ok();
            }
        }
        return BadRequest();
    }
}
