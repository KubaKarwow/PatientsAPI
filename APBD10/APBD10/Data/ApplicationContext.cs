using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Data;

public class ApplicationContext:DbContext
{
    protected ApplicationContext()
    {
    }
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "sdas@gmail.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Jan",
                LastName = "Kowalskii",
                Email = "xdxdxd@gmail.com"
            },
            new Doctor
            {
                IdDoctor = 3,
                FirstName = "Jan",
                LastName = "Kowalskiiii",
                Email = "qweqwe@gmail.com"
            }
        });
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient
            {
                IdPatient = 1,
                FirstName = "Jakub",
                LastName = "Kolorowy",
                Birthdate = DateTime.Today
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Ktos",
                LastName = "Fajny",
                Birthdate = DateTime.MaxValue
            },
            new Patient
            {
                IdPatient = 3,
                FirstName = "Haha",
                LastName = "Dope",
                Birthdate = DateTime.MinValue
            },
        });
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "Grzyby",
                Description = "WOhoo",
                Type = "cool"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Rutinoscorbin",
                Description = "na wszystko",
                Type = "coooler"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "aspirinka",
                Description = "weeeee",
                Type = "coolest"
            },
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.MinValue,
                DueDate = DateTime.MaxValue,
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.MinValue,
                DueDate = DateTime.MaxValue,
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.MinValue,
                DueDate = DateTime.MaxValue,
                IdPatient = 3,
                IdDoctor = 3
            },
        });
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>
        {
            new Prescription_Medicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Details = "take some",
                Dose = 5
            },
            new Prescription_Medicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Details = "take some more ",
                Dose = 10
            },
            new Prescription_Medicament
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Details = "take it all",
                Dose = 70
            },
        });
        
    }
}