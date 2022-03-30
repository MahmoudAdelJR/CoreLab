using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Models
{
    public class Employee:BaseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual Department dept { get; set; }
    }
}
