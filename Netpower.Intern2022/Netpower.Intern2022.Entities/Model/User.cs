using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    public class User
    {
        [Required,MaxLength(100)]
        public string UserName { get; set; }
        [Required,MinLength(8)]
        public string Password { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime CreatedAt { get; set; }

    }
    [Table("USER")]
    public class UserModel : User
    {
        [Key]
        public Guid ID { get; set; }
    }
}
