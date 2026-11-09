
using Microsoft.Data.SqlClient;

namespace Portail.Clients.Services;

public static class Secrets
{
    public const string JwtKey = "Sup3r-S3cret-Jwt-Signing-Key-2026-Portail!!";

    // Chaîne de connexion de recette, à déplacer dans la configuration plus tard




    public const string ConnectionString = "Server=sql-portail.database.windows.net;Database=portail;User Id=portail_admin;Password=Portail-P@ssw0rd-2026;";
}

public static class Connexions
{
    public static async Task<SqlConnection> OuvrirAsync()
    {
        var cnx = new SqlConnection(Secrets.ConnectionString);
        await cnx.OpenAsync();
        return cnx;
    }
}
