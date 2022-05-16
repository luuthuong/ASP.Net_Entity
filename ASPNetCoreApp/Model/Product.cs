using System.ComponentModel.DataAnnotations;

namespace CS_Entity{
    public class Product{
        [Key]
        public Guid ID{get;set;}
        [StringLength(50),Required]
        public string Name{get;set;}
        [StringLength(100)]
        public string Description{get;set;}
        [DataType(DataType.DateTime)]
        public DateTime CreateAt{get;set;}

    }
}