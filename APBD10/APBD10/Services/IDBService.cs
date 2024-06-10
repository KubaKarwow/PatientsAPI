using APBD10.DTOs;
using APBD10.Models;

namespace APBD10.Services;

public interface IDBService
{
    public Task<bool> DoesPatientExist(PrescriptionDTO prescriptionDto);
    public Task<bool> DoesDoctorExist(PrescriptionDTO prescriptionDto);
    public Task AddPatient(PrescriptionDTO prescriptionDto);
    public Task<bool> DoesMedicamentExist(MedicamentDTO medicamentDto);
    public bool AreDatesCorrect(PrescriptionDTO prescriptionDto);
    public Task<PrescriptionToSend> AddPrescription(PrescriptionDTO prescriptionDto);

    public Task<List<Prescription>> GetPrescriptions(Patient patient);

    public Task<Patient?> GetPatient(string lastName);
    public Task<PatientDTO> GetPatientInfoFormatted(Patient patient);
}