using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_Entity.Model{
    [Table("PRODUCT")]
    public class Product{
        [Key]
        public Guid ID{get;set;}
        [Column(TypeName ="nvarchar"),StringLength(50),Required]
        public string Name{get;set;}
        [DataType(DataType.DateTime)]
        public DateTime CreateAt{get;set;}
        [Required]
        public Guid cateID1{get;set;}
        [ForeignKey("cateID1")]
        public virtual Category category1 {get;set;}
        public Guid? cateID2{get;set;}

        [ForeignKey("cateID2"),InverseProperty("products")]
        public virtual Category category2 {get;set;}
    }
}