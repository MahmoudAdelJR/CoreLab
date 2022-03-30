using IdentityLab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Repositories
{
    public interface IUserRepository
    {
        Task<string> SignUp(SignUpModel model);
    }
}
