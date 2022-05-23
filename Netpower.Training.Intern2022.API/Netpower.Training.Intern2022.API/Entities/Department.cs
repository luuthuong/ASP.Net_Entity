using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpower.Training.Intern2022.API.Entities
{
    public class Department:EntityBase
    {
        [Required]
        public string Name { get; set; }
        public List<Position> Positions { get; set; }
    }
}
