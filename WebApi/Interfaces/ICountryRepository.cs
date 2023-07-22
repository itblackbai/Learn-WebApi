using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);

        ICollection<Owner> GetOwnersFromCounty(int countryId);

        bool CountyExists(int id);
        bool CreateCountry(Country country);

        bool Save();
    }
}
