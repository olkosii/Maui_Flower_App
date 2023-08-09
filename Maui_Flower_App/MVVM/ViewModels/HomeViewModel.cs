using Maui_Flower_App.MVVM.Views;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels
{
    public class HomeViewModel
    {
        #region Commands
        public ICommand Redirect => new Command<string>(RedirectToPageAsync);

        #endregion

        #region Commands Methods

        public void RedirectToPageAsync(string page)
        {
            var pageName = page + "View";

            App.Current.MainPage.Navigation.PushAsync(new HomeTabbed(pageName));
        }

        #endregion
    }
}
