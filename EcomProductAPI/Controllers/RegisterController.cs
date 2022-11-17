using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EcomProductAPI.Models;
using EcomProductAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ProductDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterController(ProductDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterViewModel model)
        {
            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

        }

    }
}