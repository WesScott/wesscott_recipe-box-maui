using Mopups.Pages;
using wesscott_recipe_box_maui.Models.DataModels;
using wesscott_recipe_box_maui.Models.ViewModels;

namespace wesscott_recipe_box_maui.Views;

public partial class IngredientFormPopupPage : PopupPage
{
	public IngredientFormPopupPage()
	{
		InitializeComponent();
		BindingContext = new IngredientFormPopupViewModel();
	}

    public IngredientFormPopupPage(Ingredient ingredientToEdit)
    {
        InitializeComponent();
        BindingContext = new IngredientFormPopupViewModel(ingredientToEdit);
    }
}