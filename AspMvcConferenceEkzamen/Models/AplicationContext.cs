using Microsoft.EntityFrameworkCore;

namespace AspMvcConferenceEkzamen.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<Models.Conference> Conferences { get; set; }
        public DbSet<Models.User> Users { get; set; }

        private string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ConferencesBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
