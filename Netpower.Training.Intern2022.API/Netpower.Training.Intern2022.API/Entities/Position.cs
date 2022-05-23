using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpower.Training.Intern2022.API.Entities
{
    public class Position:EntityBase
    {
        [Required]
        public string Name { get; set; }

        [ForeignKey("DepartmentID")]
        public Guid? DepartmentID { get; set; }
        public List<Profile> Profile { get; set; }

    }
}
