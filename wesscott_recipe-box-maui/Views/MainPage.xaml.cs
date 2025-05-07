using wesscott_recipe_box_maui.Models.ViewModels;

namespace wesscott_recipe_box_maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

    }

}
