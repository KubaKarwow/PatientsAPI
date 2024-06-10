using APBD10.Data;
using APBD10.DTOs;
using APBD10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10.Services;

public class DBService:IDBService
{
    private readonly ApplicationContext _applicationContext;

    public DBService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<bool> DoesPatientExist(PrescriptionDTO prescriptionDto)
    {
       return await _applicationContext.Patients.AnyAsync(p => p.IdPatient == prescriptionDto.Patient.IdPatient);
    }
    

    public async Task<bool> DoesDoctorExist(PrescriptionDTO prescriptionDto)
    {
        return await _applicationContext.Doctors.AnyAsync(d => d.IdDoctor == prescriptionDto.Doctor.IdDoctor);
    }

    public async Task AddPatient(PrescriptionDTO prescriptionDto)
    {
        await _applicationContext.Patients.AddAsync(new Patient
        {
            IdPatient = prescriptionDto.Patient.IdPatient,
            FirstName = prescriptionDto.Patient.FirstName,
            LastName = prescriptionDto.Patient.LastName,
            Birthdate = prescriptionDto.Patient.Birthdate,
        });
    }

    public async Task<bool> DoesMedicamentExist(MedicamentDTO medicamentDto)
    {
        return await _applicationContext.Medicaments.AnyAsync(m => m.IdMedicament == medicamentDto.idMedicament);
    }

    public bool AreDatesCorrect(PrescriptionDTO prescriptionDto)
    {
        return prescriptionDto.DueDate.CompareTo(prescriptionDto.Date) >= 0;
    }

    public async Task<PrescriptionToSend> AddPrescription(PrescriptionDTO prescriptionDto)
    {
        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = prescriptionDto.Doctor.IdDoctor,
            IdPatient = prescriptionDto.Patient.IdPatient
        };
        await _applicationContext.Prescriptions.AddAsync(prescription);
        await _applicationContext.SaveChangesAsync();
        
        foreach (var medicament in prescriptionDto.medicaments)
        {
            await _applicationContext.Prescription_Medicaments.AddAsync(
                new Prescription_Medicament
                {
                    IdMedicament = medicament.idMedicament,
                    Details = medicament.Description,
                    Dose = medicament.Dose,
                    IdPrescription = prescription.IdPrescription
                });
        }

        await _applicationContext.SaveChangesAsync();
        return new PrescriptionToSend
        {
            IdPrescription=prescription.IdPrescription,
            IdPatient=prescription.IdPatient,
            IdDoctor=prescription.IdDoctor,
            Date=prescription.Date,
            DueDate=prescription.DueDate
        };
    }

    public async Task<List<Prescription>> GetPrescriptions(Patient patient)
    {

        return await _applicationContext.Prescriptions
            .Include(p => p.Doctor)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(p => p.Medicament)
            .Where(p => p.IdPatient == patient.IdPatient)
            .ToListAsync();
    }

    public async Task<Patient?> GetPatient(string lastName)
    {
        return await _applicationContext.Patients.FirstOrDefaultAsync(p => p.LastName.Equals(lastName));
    }


    public async Task<PatientDTO> GetPatientInfoFormatted(Patient patient)
    {
        var prescriptions = await GetPrescriptions(patient);
        var prescriptionDtoGets = prescriptions.Select(p => new PrescriptionDTOGet
        {
            IdPrescription = p.IdPrescription,
            Date = p.Date,
            DueDate = p.DueDate,
            Medicaments = p.PrescriptionMedicaments
                .Select(pm => new MedicamentDTOGet
                {
                    IdMedicament = pm.Medicament.IdMedicament,
                    Name = pm.Medicament.Name,
                    Dose = pm.Dose,
                    Description = pm.Medicament.Description
                }).ToList(),
            Doctor = new DoctorDTO
            {
                IdDoctor = p.IdDoctor,
                FirstName = p.Doctor.FirstName
            }
        }).ToList();


        return new PatientDTO
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = prescriptionDtoGets
        };

    }
}
