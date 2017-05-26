using System.Data.Entity;

namespace DPSP_DAL
{
    public class DboContext : DbContext, IDboContext
    {
        public DboContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //            .HasMany<Project>(s => s.Projects)
            //            .WithMany(c => c.Users)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("UserRefId");
            //                cs.MapRightKey("ProjectRefId");
            //                cs.ToTable("UserProject");
            //            });

        }
    }

    public interface IDboContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<Project> Projects { get; set; }
        
    }
}
