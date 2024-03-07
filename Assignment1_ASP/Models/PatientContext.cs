using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_ASP.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(
           ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = "St", Name = "Standing" },
                new Position { PositionId = "Si", Name = "Sitting" },
                new Position { PositionId = "Ly", Name = "Lying Down" });

            modelBuilder.Entity<Patient>().HasData(
                        new Patient
                        {
                            PatientId = 14,
                            Date = new DateTime(2012, 2, 12),
                            Diastolic = 150,
                            PositionId = "St",
                            Stylostic = 70
                        },
                        new Patient
                        {
                            PatientId = 15,
                            Date = new DateTime(2017, 1, 15),
                            Diastolic = 120,
                            PositionId = "Si",
                            Stylostic = 80
                        },
                        new Patient
                        {
                            PatientId = 16,
                            Date = new DateTime(2023, 8, 9),
                            Diastolic = 79,
                            PositionId = "Ly",
                            Stylostic = 100
                        },
                         new Patient
                         {
                             PatientId = 17,
                             Date = new DateTime(1997, 8, 19),
                             Diastolic = 91,
                             PositionId = "Ly",
                             Stylostic = 81
                         },
                          new Patient
                          {
                              PatientId = 18,
                              Date = new DateTime(1981, 3, 25),
                              Diastolic = 140,
                              PositionId = "Ly",
                              Stylostic = 110
                          });
        }
    }
}
