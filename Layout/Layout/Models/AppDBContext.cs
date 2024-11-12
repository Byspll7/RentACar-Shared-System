using Microsoft.EntityFrameworkCore;

namespace Layout.Models
{
    public class AppDBContext :DbContext
    {



        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            

        }

        public DbSet<Product> TblProduct { get; set; }
    }
}
