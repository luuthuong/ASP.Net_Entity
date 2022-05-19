using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    public class Profile
    {
        public string FullName { get; set; }
        public string Age { get; set; }
        public string Mail { get; set; }
        
    }
    [Table("PROFILE")]
    public class ProfileModel: Profile
    {
        public Guid ID { get; set; }
    }
}
