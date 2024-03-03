using _66bitTest.app.entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Versioning;


namespace _66bitTest.app
{
    public class AppDbContext:DbContext
    {

        public DbSet<PlayerEntity> PlayerEntities { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) 
        {
            Database.EnsureCreated();
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerEntity>()
                .HasKey(x => x.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strCfg = File.ReadAllText("./Properties/dbSettings.json");
            Dictionary<string, string> cfg = JsonConvert.DeserializeObject<Dictionary<string, string>>(strCfg);
            optionsBuilder.UseNpgsql($"Host={cfg["Host"]};Port={cfg["Port"]};Database={cfg["Database"]};Username={cfg["Username"]};Password={cfg["Password"]}");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
