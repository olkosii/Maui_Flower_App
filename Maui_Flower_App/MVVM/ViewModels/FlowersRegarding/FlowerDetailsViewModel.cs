﻿using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Models.Enums;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Windows.Input;
using Color = Maui_Flower_App.MVVM.Models.Enums.Color;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class FlowerDetailsViewModel
    {
        #region Propetries

        public Flower Flower { get; set; }
        private IFlowerRepository _flowerRepository;
        public string[] FlowerColors { get; set; }
        public string[] FlowerTypes { get; set; }

        #endregion

        public FlowerDetailsViewModel(Flower flower)
        {
            Flower = flower;
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
            FlowerColors = Enum.GetNames(typeof(Color));
            FlowerTypes = Enum.GetNames(typeof(FlowerType));
        }

        #region Commands

        public ICommand UpdateCommand => new Command(UpdateFlower);
        public ICommand DeleteCommand => new Command(DeleteFlower);

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

        private async void DeleteFlower()
        {
            var alertResult = await Application.Current.MainPage
                    .DisplayAlert(Constants.AppConstants.Message.Attention,
                    Constants.AppConstants.Message.DeleteClientAttentionMessage + $"({Flower.TypeName})", "Ok", "Cancel");

            if (alertResult)
            {
                var result = await _flowerRepository.DeleteFlowerAsync(Flower.Id);

                if (result)
                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Message.MessageWord, Constants.AppConstants.Message.FlowerDeleted, "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert(Constants.AppConstants.Error.ErrorWord, Constants.AppConstants.Error.ErrorMessage, "Ok");

                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        #endregion
    }
}
