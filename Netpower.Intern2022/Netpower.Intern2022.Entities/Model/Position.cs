using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    public class Position
    {
        [Required]
        public string Name { get; set; }

        public ICollection<ProfileModel> profiles { get; set; }


        [ForeignKey("FK_Depatment")]
        public Guid FK_Department { get; set; }
        public DepartmentModel position_Department { get; set; }
    }
    [Table("TB_POSITION")]
    public class PositionModel : Position
    {
        [Key]
        public Guid ID_Position { get; set; }
    }
}
