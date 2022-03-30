using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Models
{
    public class Department:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
