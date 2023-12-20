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
    public IEnumerable<ServiceAuftragDto> GetServiceAuftr�ge()
    {
        // Hier k�nntest du die Serviceauftr�ge aus der Datenbank laden und in ein DTO konvertieren
        var serviceAuftr�ge = dbContext.ServiceAuftr�ge.ToList();
        var serviceAuftr�geDto = serviceAuftr�ge.Select(auftrag => new ServiceAuftragDto
        {
            AuftragsID = auftrag.AuftragsID,
            Kundenname = auftrag.Kundenname,
            Email = auftrag.Email,
            Telefon = auftrag.Telefon,
            Priorit�t = auftrag.Priorit�t,
            Dienstleistung = auftrag.Dienstleistung,
            Status = auftrag.Status
        });
        return serviceAuftr�geDto;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateServiceAuftrag(int id, [FromBody] ServiceAuftragDto updatedAuftrag)
    {
        // Hier k�nntest du die Serviceauftragsdaten in der Datenbank aktualisieren
        var existingAuftrag = dbContext.ServiceAuftr�ge.Find(id);
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
        // Hier k�nntest du den Serviceauftrag aus der Datenbank l�schen
        var existingAuftrag = dbContext.ServiceAuftr�ge.Find(id);
        if (existingAuftrag == null)
        {
            return NotFound();
        }

        dbContext.ServiceAuftr�ge.Remove(existingAuftrag);
        dbContext.SaveChanges();

        return NoContent();
    }
}
