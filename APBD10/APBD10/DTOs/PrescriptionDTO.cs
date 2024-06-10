using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.DTOs;

public class PrescriptionDTO
{
    public Patient Patient { get; set; }
    [MaxLength(10)]
    public ICollection<MedicamentDTO> medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Doctor Doctor { get; set; }
}

public class MedicamentDTO
{
    public int idMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
}