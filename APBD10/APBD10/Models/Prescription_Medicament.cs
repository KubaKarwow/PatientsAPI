using System.ComponentModel.DataAnnotations;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Models;

[PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
public class Prescription_Medicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
    public Medicament Medicament { get; set; }
    public Prescription Prescription { get; set; }
}