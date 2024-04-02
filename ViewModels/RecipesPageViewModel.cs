using MvvmHelpers;
using MvvmHelpers.Commands;
using ReciShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command = MvvmHelpers.Commands.Command;

namespace ReciShare.ViewModels
{
    public class RecipesPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Recipe> Recipes { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Recipe> SelectedCommand { get; }

        public Command LoadMoreCommand { get; }
        public Command DelayLoadMoreCommand { get; }
        public Command ClearCommand { get; }

        public RecipesPageViewModel()
        {
            Title = "Recipes page";
            Recipes = new ObservableRangeCollection<Recipe>();

            LoadMore();

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<Recipe>(Selected);
            LoadMoreCommand = new Command(LoadMore);
            ClearCommand = new Command(Clear);
            DelayLoadMoreCommand = new Command(DelayLoadMore);
        }

        Recipe previouslySelected;
        Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => SetProperty(ref selectedRecipe, value);
        }

        async Task Selected(Recipe recipe)
        {
            if (recipe == null) return;
            SelectedRecipe = null;
            await Application.Current.MainPage.DisplayAlert("Selected", recipe.Name, "OK");
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Recipes.Clear();
            LoadMore();
            IsBusy = false;
        }

        void LoadMore()
        {
            if (Recipes.Count >= 20) return;

            var image = "https://img.freepik.com/free-photo/chocolate-cake-with-chocolate-sprinkles_144627-8998.jpg?w=996&t=st=1711459210~exp=1711459810~hmac=00b665515eb85d987b940efad973268e0894a64c5e6ab6ab188a0642a83c1f5b";
            Recipes.Add(new Recipe { Name = "Cake", Description = "A choco cake", Image = image });
            Recipes.Add(new Recipe { Name = "Cake", Description = "A choco cake", Image = image });
            Recipes.Add(new Recipe { Name = "Cake", Description = "A choco cake", Image = image });
            Recipes.Add(new Recipe { Name = "Cake", Description = "A choco cake", Image = image });
            Recipes.Add(new Recipe { Name = "Cake", Description = "A choco cake", Image = image });
        }

        void DelayLoadMore()
        {
            if (Recipes.Count <= 10) return;
            LoadMore();
        }

        void Clear()
        {
            Recipes.Clear();    
        }
    }

}
