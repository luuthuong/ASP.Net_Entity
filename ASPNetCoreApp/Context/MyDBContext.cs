using CS_Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS_Entity.Context{
    public class MyDBContext:DbContext{
        private readonly string _connectionString;
        public MyDBContext(string connectionString){
            this._connectionString=connectionString;
        }
        DbSet<Product> products{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            ILoggerFactory iLoggerFactory=LoggerFactory.Create(loggingBuilder=>loggingBuilder.AddConsole());
            optionsBuilder.UseSqlServer(this._connectionString).UseLazyLoadingProxies().UseLoggerFactory(iLoggerFactory);
        }
        public async Task CreateDatabase(){
            string databaseName=Database.GetDbConnection().Database;
            bool result=await Database.EnsureCreatedAsync();
            string resultString=result?"Database Created":"Database exist..";
            Console.WriteLine(resultString);
            Console.WriteLine($"{databaseName} -- {resultString}");
        }
        public async Task DeleteDatabase(){
            string databaseName=Database.GetDbConnection().Database;
            bool result = await Database.EnsureDeletedAsync();
            string resultString=result?"Database Deleted":"Can not Deleted";
            Console.WriteLine(resultString);
        }
        public async Task AddData(){
            var cate1= new Category(){
                    ID=Guid.NewGuid(),
                    Name="Cate1"
                };
            var cate2= new Category(){
                    ID=Guid.NewGuid(),
                    Name="Cate2"
                };
            await AddRangeAsync(cate1,cate2);
            await SaveChangesAsync();

            await AddRangeAsync(
                new Product(){
                    ID=Guid.NewGuid(),
                    Name="Product 1",
                    CreateAt=DateTime.Now,
                    category2=cate1,
                    category1=cate2,
                },
                new Product(){
                    ID=Guid.NewGuid(),
                    Name="Product 2",
                    CreateAt=DateTime.Now,
                    category1=cate2,
                    category2=cate1
                },
                new Product(){
                    ID=Guid.NewGuid(),
                    Name="Product 3",
                    CreateAt=DateTime.Now,
                    category1=cate1,
                    category2=cate2
                }
            );
            await SaveChangesAsync();
        }
        public async Task<Product> FindProduct(string ID){
            var p= await( from product in products where product.ID.ToString()==ID select product).FirstOrDefaultAsync();

            await Entry(p)
            .Reference(x=>x.category1)
            .LoadAsync();
            return p;
        }
    }
    
}