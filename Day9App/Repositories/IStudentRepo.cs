using Day9App.Models;
using System.Collections.Generic;

namespace Day9App.Repositories
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAll();
        Student Add(Student s);
        Student Get(int id);
    }
}