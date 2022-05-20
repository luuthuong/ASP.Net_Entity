using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.DTO
{
    public class DepartmentDTO
    {
        public class Department
        {
            public Guid ID { get; set; }
            public string? Name { get; set; }
            public Role? info { get; set; }
        }
        public class Role
        {
            public string? NameRole { get; set; }
        }
        
    }

}
