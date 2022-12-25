using DownloadSystem.WebAPI.Entitites;
using Microsoft.EntityFrameworkCore;

namespace DownloadSystem.WebAPI
{
    public class DBContext: DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<ProductVersionEntity> ProductVersions => Set<ProductVersionEntity>();
    }
}
