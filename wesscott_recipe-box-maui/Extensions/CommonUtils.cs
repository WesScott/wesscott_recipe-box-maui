using Mopups.Pages;
using Mopups.Services;

namespace wesscott_recipe_box_maui.Extensions.CommonUtils
{
    public static partial class CommonUtils
    {
        public static async Task OpenPopup(PopupPage popupPage)
        {
            await MopupService.Instance.PushAsync(popupPage);
        }

        public static async Task ClearPopupStack()
        {
            await MopupService.Instance.PopAllAsync();
        }
    }
}
