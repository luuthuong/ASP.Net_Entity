using System;
using System.ComponentModel.DataAnnotations;

namespace Netpower.Training.Intern2022.API.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTimeOffset CreateAt { get; set; }
    }
}
