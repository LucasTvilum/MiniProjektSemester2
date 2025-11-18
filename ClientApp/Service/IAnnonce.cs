using Core.Models;

namespace ClientApp.Service;


public interface IAnnonce
{
    Task<List<Annonce>> GetAll();

    Task Add(Annonce item);

    Task Delete(string annonceId);
}