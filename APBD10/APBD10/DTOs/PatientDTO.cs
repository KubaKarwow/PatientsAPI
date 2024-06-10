using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<PrescriptionDTOGet> Prescriptions { get; set; }
    
}

public class PrescriptionDTOGet
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<MedicamentDTOGet> Medicaments { get; set; }
    public DoctorDTO Doctor { get; set; }
}

public class MedicamentDTOGet
{
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }

}
public class DoctorDTO
{
    public int IdDoctor{ get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
}