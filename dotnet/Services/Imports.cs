
using System.Xml;
using Newtonsoft.Json;

namespace Portail.Clients.Services;

public static class Imports
{
    public static IEnumerable<string> LireXml(string xml)
    {
        var document = new XmlDocument { XmlResolver = new XmlUrlResolver() };
        document.LoadXml(xml);
        return document.SelectNodes("//ligne")?.Cast<XmlNode>().Select(n => n.InnerText) ?? [];
    }

    public static object? LireJson(string json)
    {
        // Les imports contiennent des objets de plusieurs types : on garde le type dans le JSON



        return JsonConvert.DeserializeObject(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
    }
}
