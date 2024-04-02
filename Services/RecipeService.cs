using ReciShare.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciShare.Services
{
    public static class RecipeService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Recipe>();
        }

        public static async Task AddRecipe(string name, string description)
        {
            await Init();
            var image = "https://img.freepik.com/free-photo/chocolate-cake-with-chocolate-sprinkles_144627-8998.jpg?w=996&t=st=1711459210~exp=1711459810~hmac=00b665515eb85d987b940efad973268e0894a64c5e6ab6ab188a0642a83c1f5b";
            var recipe = new Recipe 
            { 
                Name = name, 
                Description = description,
                Image = image
            };

            var id = await db.InsertAsync(recipe);
        }

        public static async Task RemoveRecipe(int id)
        {
            await Init();
            await db.DeleteAsync<Recipe>(id);
        }

        public static async Task<IEnumerable<Recipe>> GetRecipes()
        {
            await Init();
            var recipes = await db.Table<Recipe>().ToListAsync();
            return recipes;
        }

        public static async Task<Recipe> GetRecipes(int id)
        {
            await Init();
            var recipe = await db.Table<Recipe>().FirstOrDefaultAsync(c=>c.Id == id);
            return recipe;
        }
    }
}
