using Assessment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Repo
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> BookDbSet { get; set; }
    }
}
