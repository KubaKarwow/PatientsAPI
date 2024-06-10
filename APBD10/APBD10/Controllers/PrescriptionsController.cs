using APBD10.DTOs;
using APBD10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController:ControllerBase
{
    private readonly IDBService _service;

    public PrescriptionsController(IDBService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionDTO prescriptionDto)
    {
        if (!await _service.DoesPatientExist(prescriptionDto))
        {
            await _service.AddPatient(prescriptionDto);
        }

        foreach (var medicament in prescriptionDto.medicaments)
        {
            if (!await _service.DoesMedicamentExist(medicament))
            {
                return BadRequest("No such medicament");
            }
        }

        if (!_service.AreDatesCorrect(prescriptionDto))
        {
            return BadRequest("DueDate is before Date");
        }

        var prescription = await _service.AddPrescription(prescriptionDto);
        return Created("api/prescriptions",prescription);
    }
}