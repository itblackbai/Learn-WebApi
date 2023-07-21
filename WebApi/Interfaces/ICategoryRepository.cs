﻿using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICategoryRepository
    {

        ICollection<Category> GetCategories();
        
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory( int categoryId);

        bool CategotyExists(int id);
    }
}