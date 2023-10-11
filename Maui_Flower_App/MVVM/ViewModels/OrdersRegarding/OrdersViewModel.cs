using Maui_Flower_App.MVVM.Views.OrdersRegarding;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.OrdersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class OrdersViewModel
    {
        #region Properties

        #endregion

        public OrdersViewModel()
        {
            
        }

        #region Commands

        public ICommand NewOrderCommand => new Command(RedirectToNewOrderForm);

        #endregion

        #region Command Methods

        public async void RedirectToNewOrderForm()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewOrderView());
        }

        #endregion
    }
}
