using Mopups.Pages;
using wesscott_recipe_box_maui.Models.DataModels;
using wesscott_recipe_box_maui.Models.ViewModels;

namespace wesscott_recipe_box_maui.Views;

public partial class RecipeFormPopupPage : PopupPage
{
    public RecipeFormPopupPage()
    {
        InitializeComponent();
        BindingContext = new RecipeFormPopupViewModel();
    }

    public RecipeFormPopupPage(Recipe recipeToEdit)
    {
        InitializeComponent();
        BindingContext = new RecipeFormPopupViewModel(recipeToEdit);
    }
}
