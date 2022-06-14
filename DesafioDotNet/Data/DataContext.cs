using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(mapper =>
            {
                mapper.ToTable("Products");
                mapper.HasKey(p => p.Id);                
            });                
            base.OnModelCreating(modelBuilder);
        }
    }
}
