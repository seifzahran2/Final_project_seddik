using FinalProjectSeddik.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectSeddik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {

        }
        public DbSet<ComptitveRegistration> ComptitveRegistration { get; set; }
        public DbSet<UploadProject> UploadProject { get; set; }
        public DbSet<Contact> ContactUs { get; set; }

    }
}
