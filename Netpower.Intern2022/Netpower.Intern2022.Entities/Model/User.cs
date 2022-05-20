using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    [Table("dfsfsd")]
    public class User
    {
        [Required,MaxLength(100)]
        public string UserName { get; set; }
        [Required,MinLength(8)]
        public string Password { get; set; }
        public string Mail { get; set; }


        [Column(TypeName ="datetime")]
        public DateTime CreatedAt { get; set; }


        [ForeignKey("FK_profile")]
        public ProfileModel user_profile { get; set; }
    }
    [Table("TB_USER")]
    public class UserModel : User
    {
        [Key]
        public Guid ID { get; set; }
    }
}
