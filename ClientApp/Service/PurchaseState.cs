namespace ClientApp.Service;

public class PurchaseState
{
    private readonly List<string> _requestIds = new();
    
    public IReadOnlyList<string> RequestIds => _requestIds;

    public void Add(string requestId)
    {
        if (!string.IsNullOrWhiteSpace(requestId) && !_requestIds.Contains(requestId)) _requestIds.Add(requestId);
    }

    public void Remove(string requestId)
    {
        _requestIds.Remove(requestId);
    }
}