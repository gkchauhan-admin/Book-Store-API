using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStoreAPI.Data
{
    public class BookStoreContext : DbContext 
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            :base(options)
        {

        }
        public DbSet<Books>? books { get; set; }
    }
}
