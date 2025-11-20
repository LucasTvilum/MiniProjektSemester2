using System.Net.Http.Json;
using Core.Models;

namespace ClientApp.Service;

public class BrugerService : IBruger
{
    private HttpClient http;
    
    private string url = "http://localhost:5107";

    public BrugerService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<Bruger[]> GetAll()
    {
        Console.WriteLine("GetAll from mock");
        var todoitemlist = await http.GetFromJsonAsync<Bruger[]>($"{url}/api/bruger");
       
        return todoitemlist;
    }

    public async Task Add(Bruger bruger)
    {
        await http.PostAsJsonAsync($"{url}/api/bruger", bruger);
    }

    public async Task Delete(string brugerid)
    {
        await http.DeleteAsync($"{url}/api/todo/{brugerid}");
    }
    
    public async Task<Bruger> Authenticate(string username, string password)
    {
        Console.WriteLine("Authenticate user");
        var bruger = await http.GetFromJsonAsync<Bruger>($"{url}/api/bruger");
        return bruger;
    }
}