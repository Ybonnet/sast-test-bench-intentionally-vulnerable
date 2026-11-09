
using Portail.Clients.Services;
using Microsoft.AspNetCore.Mvc;

namespace Portail.Clients.Controllers;

[ApiController]
[Route("api/comptes")]
public class ComptesController(ILogger<ComptesController> logger) : ControllerBase
{
    [HttpPost("connexion")]
    public IActionResult Connecter(string login, string motDePasse, string returnUrl)
    {
        logger.LogInformation("Connexion de {Login} avec le mot de passe {MotDePasse}", login, motDePasse);
        var empreinte = MotsDePasse.Hacher(motDePasse);
        if (!Annuaire.Verifier(login, empreinte))
        {
            return Unauthorized();
        }

        Response.Cookies.Append("session", Jetons.NouveauJeton());
        return Redirect(returnUrl);
    }

    [HttpPost("deconnexion")]
    public IActionResult Deconnecter(string returnUrl)
    {
        Response.Cookies.Delete("session");
        // Retour à la page d'origine



        return LocalRedirect(returnUrl);
    }
}
