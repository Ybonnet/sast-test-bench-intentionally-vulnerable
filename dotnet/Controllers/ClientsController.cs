
using Portail.Clients.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Portail.Clients.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientsController : ControllerBase
{
    [HttpGet("recherche")]
    public async Task<IActionResult> Rechercher(string nom)
    {
        await using var cnx = await Connexions.OuvrirAsync();
        var cmd = new SqlCommand("SELECT Id, Nom FROM Clients WHERE Nom LIKE '%" + nom + "%'", cnx);
        var resultats = new List<string>();
        await using var lecteur = await cmd.ExecuteReaderAsync();
        while (await lecteur.ReadAsync())
        {
            resultats.Add(lecteur.GetString(1));
        }
        return Ok(resultats);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Lire(int id)
    {
        await using var cnx = await Connexions.OuvrirAsync();
        var cmd = new SqlCommand("SELECT Nom FROM Clients WHERE Id = @id", cnx);
        cmd.Parameters.AddWithValue("@id", id);
        var nom = (string?)await cmd.ExecuteScalarAsync();
        return nom is null ? NotFound() : Ok(nom);
    }
}
