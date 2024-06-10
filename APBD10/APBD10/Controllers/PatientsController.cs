using APBD10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientsController:ControllerBase
{
    private readonly IDBService _service;

    public PatientsController(IDBService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientInfo(string LastName)
    {
        var patient =await _service.GetPatient(LastName);
        if (patient == null)
        {
            return BadRequest("No patient with such lastName exists");
        }

        var patientInfo = await _service.GetPatientInfoFormatted(patient);
        return Ok(patientInfo);
    }
}