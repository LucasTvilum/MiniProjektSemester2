using System.Net.Http.Json;
using Core.Models;

namespace ClientApp.Service;

public class AnnonceService : IAnnonce
{
    private HttpClient http;

    private string url = "http://localhost:5267";

    public AnnonceService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<Annonce[]> GetAll()
    {
        Console.WriteLine("Henter alle annoncer...");
        var annonces = await http.GetFromJsonAsync<Annonce[]>($"{url}/api/annonce");
        return annonces ?? Array.Empty<Annonce>();
    }

    public async Task Add(Annonce item)
    {
        await http.PostAsJsonAsync($"{url}/api/annonce", item);
    }

    public async Task Delete(string annonceId)
    {
        await http.DeleteAsync($"{url}/api/annonce/{annonceId}");
    }
}