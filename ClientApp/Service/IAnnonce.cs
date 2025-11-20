using Core.Models;

namespace ClientApp.Service;


public interface IAnnonce
{
    Task<Annonce[]> GetAll();

    Task Add(Annonce item);
    
    Task UpdateStatus(Annonce item);

    Task Delete(string todoid);
}