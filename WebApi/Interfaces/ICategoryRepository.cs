﻿using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICategoryRepository
    {

        ICollection<Category> GetCategories();
        
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory( int categoryId);

        bool CategotyExists(int id);

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        bool Save();
    }
}
