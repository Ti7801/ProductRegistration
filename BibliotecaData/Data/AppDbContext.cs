using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaData.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
