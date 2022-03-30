using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController:ControllerBase
    {
        public string Get()
        {
            return "Returning from StudentController Get Method";
        }
    }
}
