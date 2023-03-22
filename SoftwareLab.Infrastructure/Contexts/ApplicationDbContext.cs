using Microsoft.EntityFrameworkCore;
using SoftwareLab.Core.Entities;

namespace SoftwareLab.Infrastructure.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }

        DbSet<User> Users { get; set; }

    }
}
