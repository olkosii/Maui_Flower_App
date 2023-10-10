using Maui_Flower_App.Helpers;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.Views.FlowersRegarding;
using Maui_Flower_App.Repositories.DI;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class FlowerNameGroupViewModel
    {
        #region Properties

        public List<Flower> Flowers { get; set; }
        private IFlowerRepository _flowerRepository { get; set; }
        public string CurrentFlowerName { get; set; }

        #endregion

        public FlowerNameGroupViewModel(string flowerName)
        {
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
            CurrentFlowerName = flowerName;
        }

        #region Commands

        public ICommand RedirectToAddFlowerFormCommand => new Command(RedirectToAddFlowerForm);
        public ICommand RedirectToFlowerDetailsFormCommand => new Command<Flower>(RedirectToFlowerDetailsForm);

        #endregion

        #region Commands Methods

        private void RedirectToAddFlowerForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewFlowerFormView());
        }

        private void RedirectToFlowerDetailsForm(Flower flower)
        {
            Application.Current.MainPage.Navigation.PushAsync(new FlowerDetailsView(flower));
        }

        #endregion

        public async Task InitializeFlowersAsync()
        {
            Flowers = await _flowerRepository.GetFlowerGroupByName(CurrentFlowerName);
        }
    }
}
