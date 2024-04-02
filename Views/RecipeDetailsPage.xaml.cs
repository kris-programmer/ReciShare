using ReciShare.Services;

namespace ReciShare.Views;

[QueryProperty(nameof(RecipeId), nameof(RecipeId))]
public partial class RecipeDetailsPage : ContentPage
{
    public string RecipeId { get; set; }
    public RecipeDetailsPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int.TryParse(RecipeId, out var result);

        BindingContext = await RecipeService.GetRecipes(result);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}