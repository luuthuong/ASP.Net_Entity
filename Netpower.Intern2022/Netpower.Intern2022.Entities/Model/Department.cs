using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Entities.Model
{
    public class Department
    {
        public string Name { get; set; }
    }
    [Table("TB_DEPARTMENT")]
    public class DepartmentModel:Department
    {
        public Guid ID { get; set; }
        public List<PositionModel> PositionModels { get; set; }
    }
}
