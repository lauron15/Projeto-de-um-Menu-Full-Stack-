using Microsoft.EntityFrameworkCore;
using Foods.Model;


namespace Foods.Util
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        public DbSet<Food> foods { get; set; }
  
        //public DbSet<Produtos> Produtos { get; set; }




    }
}