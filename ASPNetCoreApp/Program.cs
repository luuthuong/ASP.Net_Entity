using System.Data;
namespace CS_Entity{
    public class App{
        public static async Task Main(string[] args){
        using( MyDBContext context=new MyDBContext()){
            // await  context.CreateDatabase();
            // var prd=context.Products.Single(
            //     product=>product.Description=="Python"
            // );
            // context.Remove(prd);
            // int row=await context.SaveChangesAsync();
            // Console.WriteLine($"Delete Sucess: {row}");
            foreach(var product in context.Products){
            var prdEntry=context.Entry<Product>(product);
            var validFrom=prdEntry.Property<DateTime>("ValidFrom").CurrentValue;
            var validTo=prdEntry.Property<DateTime>("ValidTo").CurrentValue;
            Console.WriteLine($"  Product {product.Name} valid from {validFrom} to {validTo}");
            }
        }  
        }
    }
}