using System.Data;
using CS_Entity.Context;

namespace CS_Entity{
    public class App{
        public static string connectionString=@"Data Source=.;Initial Catalog=EF_Database;Integrated Security=True";
        public static async Task Main(string[] args){
            MyDBContext context=new MyDBContext(connectionString);
            await context.DeleteDatabase();
            await context.CreateDatabase();
            await context.AddData();
            // var prd=await context.FindProduct("cc742d9a-4802-4515-af74-13462070fcfe");
            // var cate=prd.category;
            // if(prd!=null){
            //     string cateName=cate!=null?cate.Name:"cate is Null";
            //     Console.WriteLine(cateName);
            // }
        }
    }
}