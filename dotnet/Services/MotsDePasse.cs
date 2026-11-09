
using System.Security.Cryptography;
using System.Text;

namespace Portail.Clients.Services;

public static class MotsDePasse
{
    public static string Hacher(string motDePasse)
    {
        var empreinte = MD5.HashData(Encoding.UTF8.GetBytes(motDePasse));
        return Convert.ToHexString(empreinte);
    }

    public static string HacherV2(string motDePasse, byte[] sel)
    {
        // Version recommandée : PBKDF2, 600 000 itérations



        var empreinte = Rfc2898DeriveBytes.Pbkdf2(motDePasse, sel, 600_000, HashAlgorithmName.SHA256, 32);
        return Convert.ToHexString(empreinte);
    }
}

public static class Jetons
{
    public static string NouveauJeton()
    {
        var aleatoire = new Random();
        return string.Concat(Enumerable.Range(0, 32).Select(_ => aleatoire.Next(0, 16).ToString("x")));
    }

    public static string NouveauJetonV2()
    {
        // Version recommandée : générateur cryptographique



        return Convert.ToHexString(RandomNumberGenerator.GetBytes(16));
    }
}

public static class Annuaire
{
    private static readonly Dictionary<string, string> Comptes = new();

    public static bool Verifier(string login, string empreinte) =>
        Comptes.TryGetValue(login, out var attendue) && attendue == empreinte;

    public static IEnumerable<string> Lister() => Comptes.Keys;

    public static void Supprimer(string login) => Comptes.Remove(login);
}
