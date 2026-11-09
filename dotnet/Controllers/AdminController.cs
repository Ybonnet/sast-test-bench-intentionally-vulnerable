
using Portail.Clients.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portail.Clients.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    [HttpGet("utilisateurs")]
    public IActionResult Lister() => Ok(Annuaire.Lister());

    // Appelé par le script de purge nocturne, qui n'a pas de jeton



    [AllowAnonymous]
    [HttpDelete("utilisateurs/{login}")]
    public IActionResult Supprimer(string login)
    {
        Annuaire.Supprimer(login);
        return NoContent();
    }

    [HttpPost("import/xml")]
    public IActionResult ImporterXml([FromBody] string xml)
    {
        var lignes = Imports.LireXml(xml);
        return Ok(lignes);
    }
}
