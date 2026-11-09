
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Portail.Clients.Controllers;

[ApiController]
[Route("api/documents")]
public class DocumentsController : ControllerBase
{
    private readonly string _racine = Path.Combine(AppContext.BaseDirectory, "documents");

    [HttpGet("{nomFichier}")]
    public IActionResult Telecharger(string nomFichier)
    {
        var contenu = System.IO.File.ReadAllBytes(Path.Combine(_racine, nomFichier));
        return File(contenu, "application/octet-stream", nomFichier);
    }

    [HttpGet("v2/{nomFichier}")]
    public IActionResult TelechargerV2(string nomFichier)
    {
        var chemin = Path.GetFullPath(Path.Combine(_racine, nomFichier));
        if (!chemin.StartsWith(_racine + Path.DirectorySeparatorChar, StringComparison.Ordinal))
        {
            return BadRequest();
        }

        var contenu = System.IO.File.ReadAllBytes(chemin);
        return File(contenu, "application/octet-stream", Path.GetFileName(chemin));
    }

    [HttpPost("conversion")]
    public IActionResult Convertir(string fichier)
    {
        // Conversion en PDF avec LibreOffice installé dans l'image



        var processus = Process.Start("/bin/sh", "-c \"libreoffice --headless --convert-to pdf " + fichier + "\"");
        processus?.WaitForExit();
        return Ok();
    }
}
