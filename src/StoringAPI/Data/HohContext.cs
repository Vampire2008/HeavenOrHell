using Microsoft.EntityFrameworkCore;

namespace StoringAPI.Data
{
    public class HohContext : DbContext
    {

        public HohContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<SurveyResult> SurveyResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Person)
                .Property(e => e.Name)
                .HasMaxLength(50);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Gluttony);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Lust);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Wrath);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Sloth);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Pride);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Greed);

            modelBuilder
                .Entity<SurveyResult>()
                .OwnsOne(e => e.Envy);

            modelBuilder.Entity<SurveyResult>()
                .HasIndex(e => e.FrontUuid)
                .IsUnique();
        }
    }
}
