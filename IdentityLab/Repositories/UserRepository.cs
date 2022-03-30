using IdentityLab.Models;
using IdentityLab.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityLab.Repositories
{
    public class UserRepository : IUserRepository
    {
        UserManager<User> manager;
        IConfiguration configuration;
        public UserRepository(UserManager<User> _manager, IConfiguration _configuration)
        {
            manager = _manager;
            configuration = _configuration;
        }
        public async Task<string> SignUp(SignUpModel model)
        {
            User user = model.ToUserModel();
            var createdUser = await manager.CreateAsync(user,model.Password);
            if (!createdUser.Succeeded)
            {
                return null;
            }
            var signkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(20),
                signingCredentials: new SigningCredentials(signkey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
