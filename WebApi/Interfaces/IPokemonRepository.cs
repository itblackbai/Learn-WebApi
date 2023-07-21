using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRatings(int pokeId);

        bool PokemonExists (int pokeId);
    }
    
}
