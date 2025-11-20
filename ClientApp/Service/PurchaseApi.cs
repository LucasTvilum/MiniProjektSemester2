using System.Net.Http.Json;

namespace ClientApp.Service;

public static class PurchaseApi
{
    private const string ApiBase = "http://localhost:5107/";

    public static async Task<string> SendAsync(HttpClient http, string productId, int quantity)
    {
        using var resp = await http.PostAsJsonAsync($"{ApiBase}api/purchases", new {productId, quantity});
        resp.EnsureSuccessStatusCode();
        var created = await resp.Content.ReadFromJsonAsync<PurchaseCreated>();
        return created?.RequestId ?? throw new InvalidOperationException("No RequestId");
    }

    public static async Task CancelAsync(HttpClient http, string requestId)
    {
        using var resp = await http.PostAsJsonAsync($"{ApiBase}api/purchases/cancel", new {requestId});
        resp.EnsureSuccessStatusCode();
    }

    private sealed record PurchaseCreated(string RequestId);
}