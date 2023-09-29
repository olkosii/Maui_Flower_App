using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class FlowerDetailsViewModel
    {
        #region Propetries

        public Flower Flower { get; set; }
        private IFlowerRepository _flowerRepository;

        #endregion

        public FlowerDetailsViewModel(Flower flower)
        {
            Flower = flower;
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
        }

        #region Commands

        public ICommand UpdateCommand => new Command(UpdateFlower);

        #endregion

        #region Commands methods

        private async void UpdateFlower()
        {
            var result = await _flowerRepository.UpdateFlowerAsync(Flower);

            if (result)
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.FlowerUpdated, "Ok");
            else
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
