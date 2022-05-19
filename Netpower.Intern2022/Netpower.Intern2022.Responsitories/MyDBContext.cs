using Microsoft.EntityFrameworkCore;
using Netpower.Intern2022.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netpower.Intern2022.Responsitories
{
    public class MyDBContext : DbContext
    {
        public DbSet<UserModel> dB_User { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        //protected OnConfiguring(DB)
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EF_DATABASE;Integrated Security=True");
        //    }
        //}

    }
}
