using Microsoft.EntityFrameworkCore;
using Patient.Domain;

namespace Patient.Infrastructure
{
    public class PatientDbContext: DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        //public PatientDbContext(DbContextOptions options): base(options) 
        //{

        //}

        public DbSet<PatientDetail> PatientDetails { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
