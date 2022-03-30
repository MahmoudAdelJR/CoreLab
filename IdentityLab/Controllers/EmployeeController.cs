using IdentityLab.Data;
using IdentityLab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        userContext context;
        public EmployeeController(userContext context)
        {
            this.context = context;
        }
        public IEnumerable<Employee> get()
        {
            return context.employees.ToList();
        }
        [HttpPost]
        public IEnumerable<Employee> post(Employee e)
        {
            context.employees.Add(e);
            context.SaveChanges();
            return context.employees.ToList();
        }
    }
}
