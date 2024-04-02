namespace ReciShare.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void CreateARecipe_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RecipeCreationPage");
    }
}