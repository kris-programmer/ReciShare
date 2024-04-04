using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReciShare.Services;
using MvvmHelpers.Commands;

namespace ReciShare.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public  class CreateRecipeViewModel : ViewModelBase
    {
        string name, description;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Description { get => description; set => SetProperty(ref description, value); }

        public AsyncCommand SaveCommand { get; }

        public CreateRecipeViewModel()
        {
            Title = "Add Recipe";
            SaveCommand = new AsyncCommand(Save);
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(description))
            {
                return;
            }

            await RecipeService.AddRecipe(name, description);

            await Shell.Current.GoToAsync("..");
        }
    }
}
