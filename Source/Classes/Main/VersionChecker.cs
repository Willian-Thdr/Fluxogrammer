using System.Net.Http;
using System.Text.Json;

public class VersionChecker
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string?> GetLastVersion()
    {
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Fluxogrammer-App");

        string url = "https://api.github.com/repos/Willian-Thdr/Fluxogrammer/releases/latest";

        try
        {
            string json = await client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(json);
            string tagName = doc.RootElement.GetProperty("tag_name").GetString();
            return tagName;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao verificar atualização: {e.Message}");
            return null;
        }
    }
}