using Day9App.Models;
using Day9App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day9App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepo repo;
        public StudentController(IStudentRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet("get")]
        public IEnumerable<Student> getAll()
        {
           return repo.GetAll();
        }
        [HttpGet("getAll")]
        public Student getById(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public string add(Student stu)
        {
            repo.Add(stu);
            return "Done";
        }
        [HttpPatch("Update")]
        public IEnumerable<Student> Update(int id, [FromBody] JsonPatchDocument<Student> jsonPatchDocument)
        {
            Student stu = repo.Get(id);
            jsonPatchDocument.ApplyTo(stu);
            return repo.GetAll();
        }
    }
}
