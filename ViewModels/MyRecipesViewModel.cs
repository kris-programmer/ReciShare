using CommunityToolkit.Maui.Converters;
using MvvmHelpers;
using MvvmHelpers.Commands;
using ReciShare.Models;
using ReciShare.Services;
using ReciShare.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command = MvvmHelpers.Commands.Command;

namespace ReciShare.ViewModels
{
    public class MyRecipesViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Recipe> Recipes { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Recipe> RemoveCommand { get; }
        public AsyncCommand<Recipe> SelectedCommand { get; }


        public MyRecipesViewModel()
        {
            Title = "My Recipes";
            Recipes = new ObservableRangeCollection<Recipe>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Recipe>(Remove);
            SelectedCommand = new AsyncCommand<Recipe>(Selected);
        }

        async Task Add()
        {
            //var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of recipe");
            //var description = await App.Current.MainPage.DisplayPromptAsync("Description", "Description of the recipe");
            //await RecipeService.AddRecipe(name, description);
            //await Refresh();

            var route = $"{nameof(RecipeCreationPage)}?Name=Recipe name";
            await Shell.Current.GoToAsync(route);
        }

        async Task Selected(Recipe recipe)
        {
            if (recipe == null) return;

            var route = $"{nameof(RecipeDetailsPage)}?RecipeId={recipe.Id}";
            await Shell.Current.GoToAsync(route);
        }

        async Task Remove(Recipe recipe)
        {
            await RecipeService.RemoveRecipe(recipe.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Recipes.Clear();
            var recipes = await RecipeService.GetRecipes();
            Recipes.AddRange(recipes);
            IsBusy = false;
        }
    }
}
