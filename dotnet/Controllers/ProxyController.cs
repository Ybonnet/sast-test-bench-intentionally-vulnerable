
using Microsoft.AspNetCore.Mvc;

namespace Portail.Clients.Controllers;

[ApiController]
[Route("api/proxy")]
public class ProxyController(IHttpClientFactory fabrique) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Relayer(string url)
    {
        var client = fabrique.CreateClient();
        var contenu = await client.GetStringAsync(url);
        return Content(contenu, "text/plain");
    }

    [HttpGet("partenaire")]
    public async Task<IActionResult> AppelerPartenaire()
    {
        // Le certificat du partenaire est auto-signé en recette
        var gestionnaire = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };
        using var client = new HttpClient(gestionnaire);
        var reponse = await client.GetStringAsync("https://partenaire.example.com/api/releves");
        return Ok(reponse);
    }
}
