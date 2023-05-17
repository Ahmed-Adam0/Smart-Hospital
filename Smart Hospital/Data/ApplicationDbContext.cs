using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart_Hospital.Models;

namespace Smart_Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Patient> patients { get; set; }
    }
}