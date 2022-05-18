
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS_Entity{
    public class MyDBContext:DbContext{
        protected string connectionString=@"Data Source=.;Initial Catalog=MyDatabase;Trusted_Connection=true";
        public DbSet<Product> Products {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder option){
            ILoggerFactory loggerFac=LoggerFactory.Create((ILoggingBuilder buider)=>buider.AddConsole());
            option.UseSqlServer(connectionString);
        }

        public async Task CreateDatabase(){
            string database= Database.GetDbConnection().Database;
            Console.WriteLine($"Create Database: {database}");
            bool result=await Database.EnsureCreatedAsync();
            string resultString= result?"Create Success":"Database is Exist!";
            Console.WriteLine(resultString);
        }
        public async Task DeleteDatabase(){
            string database= Database.GetDbConnection().Database;
            Console.WriteLine($"Are you Sure\n Delete Database: {database}");
            string input =Console.ReadLine();
            if(input.ToLower()=="y"){
                bool deleted=await Database.EnsureDeletedAsync();
                string resultDeleted=deleted?"Deleted !":"Can't Delete";
            }

        }
    }
}