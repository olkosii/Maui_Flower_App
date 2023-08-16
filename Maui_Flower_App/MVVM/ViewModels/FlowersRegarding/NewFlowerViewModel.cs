using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    public class NewFlowerViewModel
    {
        #region Properties

        public Flower Flower { get; set; }
        private IFlowerRepository _flowerRepository { get; set; }

        #endregion

        public NewFlowerViewModel()
        {
            Flower = new Flower();
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
        }

        #region Commands

        public ICommand SaveCommand => new Command(CreateFlower);

        #endregion

        #region Commands Method

        public async void CreateFlower()
        {
            var result = await _flowerRepository.CreateFlowerAsync(Flower);

            if (result)
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.FlowerAdded, "Ok");
            else
                await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
