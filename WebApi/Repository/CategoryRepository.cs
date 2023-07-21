using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private  DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategotyExists(int id)
        {
            return _context.Categories.Any( c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();   
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories
                .Where(e => e.CategoryId == categoryId)
                .Select(c => c.Pokemon)
                .ToList();
        }
    }
}
