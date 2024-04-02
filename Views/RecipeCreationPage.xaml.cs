using ReciShare.Models;
using ReciShare.ViewModels;

namespace ReciShare.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RecipeCreationPage : ContentPage
{
    public RecipeCreationPage()
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
    }
}