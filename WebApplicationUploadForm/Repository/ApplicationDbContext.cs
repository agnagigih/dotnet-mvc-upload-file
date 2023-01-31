using Microsoft.EntityFrameworkCore;

namespace WebApplicationUploadForm.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<FormUploadEntity> FormUploadEntities => Set<FormUploadEntity>();

    }
}
