using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RacingResource.Models
{
    public class RacingResourceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<RacingResource.Models.RacingResourceContext>());

        public RacingResourceContext() : base("name=RacingResourceContext")
        {
        }

        public DbSet<Horse> Horses { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Jockey> Jockeys { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<GoingDescription> GoingDescriptions { get; set; }

        public DbSet<MeetingPage> MeetingPages { get; set; }

        public DbSet<ResultPage> ResultPages { get; set; }

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>().
              HasOptional(e => e.Sire).
              WithMany(e => e.SireProgeny).
              HasForeignKey(m => m.SireId);

            modelBuilder.Entity<Horse>().
             HasOptional(e => e.Dam).
             WithMany(e => e.DamProgeny).
             HasForeignKey(m => m.DamId);

            modelBuilder.Entity<Race>().
                HasOptional(e => e.Grade).
                WithOptionalDependent().
                Map(e => e.MapKey("RaceGradeId")).
                WillCascadeOnDelete();

            modelBuilder.Entity<Race>().
                HasOptional(e => e.Type).
                WithOptionalDependent().
                Map(e => e.MapKey("RaceTypeId")).
                WillCascadeOnDelete();

            modelBuilder.Entity<Race>().
                HasOptional(e => e.Feature).
                WithMany(e => e.Runnings).WillCascadeOnDelete();

            modelBuilder.Entity<ResultPage>().
                HasRequired(e => e.MeetingPage).
                WithMany(e => e.ResultPages).WillCascadeOnDelete();

            modelBuilder.Entity<Meeting>().
               HasMany(e => e.Races).
               WithRequired(e => e.Meeting).
               WillCascadeOnDelete();

            modelBuilder.Entity<Race>().
             HasMany(e => e.Results).
             WithRequired(e => e.Race).
             WillCascadeOnDelete();

        }

        #endregion

        public DbSet<Race> Races { get; set; }
    }
}
