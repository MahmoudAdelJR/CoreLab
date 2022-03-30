using IdentityLab.Repositories;
using IdentityLab.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost("Post")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            string token =await userRepository.SignUp(signUpModel);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            else return Ok(token);
        }
    }
}
