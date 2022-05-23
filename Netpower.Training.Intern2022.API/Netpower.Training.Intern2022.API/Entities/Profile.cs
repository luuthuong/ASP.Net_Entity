using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netpower.Training.Intern2022.API.Entities
{
    public class Profile : EntityBase
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        [ForeignKey("PositionID")]
        public Guid? PositionID { get; set; }
        [ForeignKey("UserID")]
        public Guid? UserID { get; set; }
    }
}
