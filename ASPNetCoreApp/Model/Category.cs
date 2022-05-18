using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS_Entity.Model
{
    [Table("CATEGORY")]
    public class Category
    {
    public virtual List<Product> products {set; get;}
        [Key]
        public Guid ID{get;set;}
        [Required,StringLength(50)]
        public string Name{get;set;}
    }
}