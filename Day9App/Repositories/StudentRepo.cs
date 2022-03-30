using Day9App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day9App.Repositories
{
    public class StudentRepo:IStudentRepo
    {
        public List<Student> students = new List<Student>() { 
        new Student{ID = 1,Name ="Ahmed",Age = 22},
        new Student {ID = 2 , Name = "Mahmoud", Age = 25}
        };
        public Student Add(Student s)
        {
            students.Add(s);
            return s;
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student Get(int id)
        {
            Student e = students.FirstOrDefault(i => i.ID == id);
            return e;
        }
    }
}
