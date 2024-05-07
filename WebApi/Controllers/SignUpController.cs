using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/auth/[controller]")]
[ApiController]
public class SignUpController(UserManager<UserEntity> userManager) : ControllerBase
{
    
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUp model)
    {
        if (ModelState.IsValid)
        {
            var userEntity = new UserEntity
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            var result = await _userManager.CreateAsync(userEntity, model.Password);
            if (result.Succeeded)
            {
                return Created("", null);
            }

        }
        return BadRequest();
    }
}
