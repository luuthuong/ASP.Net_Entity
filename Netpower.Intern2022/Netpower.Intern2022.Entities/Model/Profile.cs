using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    [Table("TB_PROFILE")]
    public class ProfileModel
    {
        public string FullName { get; set; }
        public string Age { get; set; }

        public Guid FK_Role { get; set; }
        public PositionModel prf_Role { get; set; }

        [Key]
        public Guid FK_User { get; set; }
        public UserModel profile_user { get; set; }
    }

}
