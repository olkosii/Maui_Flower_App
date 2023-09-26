
﻿using System;
using Maui_Flower_App.MVVM.Views.FlowersRegarding;
using System.Windows.Input;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Maui_Flower_App.Helpers;
using PropertyChanged;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class FlowersViewModel
    {
        #region Properties

        private List<Flower> Flowers { get; set; }
        public List<Flower> FilteredFlowers { get; set; }
        private IFlowerRepository _flowerRepository { get; set; }

        #endregion

        public FlowersViewModel()
        {
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
        }

        #region Commands

        public ICommand RedirectToAddFlowerFormCommand => new Command(RedirectToAddFlowerForm);
        public ICommand SearchCommand => new Command<string>(Search);

        #endregion

        #region Commands Methods

        private void RedirectToAddFlowerForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewFlowerFormView());
        }

        public void Search(string flowerName)
        {
            FilteredFlowers = Flowers.Where(f => f.TypeName.ToLower().Contains(flowerName.ToLower())).ToList();
        }

        #endregion

        public async Task InitializeFlowersAsync()
        {
            Flowers = await _flowerRepository.GetDistinctFlowersAsync();
            FilteredFlowers = new List<Flower>(Flowers);
        }
    }
}
