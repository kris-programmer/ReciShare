namespace ReciShare.Views;

public partial class RecipesPage : ContentPage
{
    public RecipesPage()
    {
        InitializeComponent();
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }

    private async void CreateARecipe_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RecipeCreationPage");
    }
}