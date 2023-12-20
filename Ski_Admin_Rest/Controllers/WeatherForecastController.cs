using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Ski_Admin_Rest;
[ApiController]
[Route("api/serviceauftraege")]
public class ServiceAuftragController : ControllerBase
{
    private readonly AuftragsDbContext dbContext;

    public ServiceAuftragController(AuftragsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<ServiceAuftragDto> GetServiceAufträge()
    {
        // Hier könntest du die Serviceaufträge aus der Datenbank laden und in ein DTO konvertieren
        var serviceAufträge = dbContext.ServiceAufträge.ToList();
        var serviceAufträgeDto = serviceAufträge.Select(auftrag => new ServiceAuftragDto
        {
            AuftragsID = auftrag.AuftragsID,
            Kundenname = auftrag.Kundenname,
            Email = auftrag.Email,
            Telefon = auftrag.Telefon,
            Priorität = auftrag.Priorität,
            Dienstleistung = auftrag.Dienstleistung,
            Status = auftrag.Status
        });
        return serviceAufträgeDto;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateServiceAuftrag(int id, [FromBody] ServiceAuftragDto updatedAuftrag)
    {
        // Hier könntest du die Serviceauftragsdaten in der Datenbank aktualisieren
        var existingAuftrag = dbContext.ServiceAufträge.Find(id);
        if (existingAuftrag == null)
        {
            return NotFound();
        }

        existingAuftrag.Status = updatedAuftrag.Status;

        dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteServiceAuftrag(int id)
    {
        // Hier könntest du den Serviceauftrag aus der Datenbank löschen
        var existingAuftrag = dbContext.ServiceAufträge.Find(id);
        if (existingAuftrag == null)
        {
            return NotFound();
        }

        dbContext.ServiceAufträge.Remove(existingAuftrag);
        dbContext.SaveChanges();

        return NoContent();
    }
}
