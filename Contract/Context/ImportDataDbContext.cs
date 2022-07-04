using Contract.Models;

using Microsoft.EntityFrameworkCore;

namespace Contract.Context
{
    public class ImportDataDbContext : DbContext
    {
        public ImportDataDbContext()
        {

        }
        public ImportDataDbContext(DbContextOptions<ImportDataDbContext> options): base (options)
        {
        }
        public DbSet<JsonProduct> JsonProduct { get; set; }

        public DbSet<YamlProduct> YamlProduct { get; set; }

    }
}
