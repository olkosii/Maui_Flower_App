using System;
using Maui_Flower_App.MVVM.Views.FlowersRegarding;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    public class FlowersViewModel
    {
        #region Properties

        #endregion

        #region Commands

        public ICommand RedirectToAddFlowerFormCommand => new Command(RedirectToAddFlowerForm);

        #endregion

        #region Commands Methods

        private void RedirectToAddFlowerForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewFlowerFormView());
        }

        #endregion
    }
}
