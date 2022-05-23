using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpower.Training.Intern2022.API.Entities
{
    public class User : EntityBase
    {
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public Profile? Profile { get; set; }
    }
}
