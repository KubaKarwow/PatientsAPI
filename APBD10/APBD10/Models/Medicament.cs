using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD10.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    [MaxLength(100)]
    public string Type { get; set; }
    [ForeignKey(nameof(IdMedicament))]
    public ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}