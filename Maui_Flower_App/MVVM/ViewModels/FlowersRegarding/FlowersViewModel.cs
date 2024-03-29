using System;
using Maui_Flower_App.MVVM.Views.FlowersRegarding;
using System.Windows.Input;
using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.Repositories.DI;
using Maui_Flower_App.Helpers;
using PropertyChanged;
using Maui_Flower_App.MVVM.Models.Groups;

namespace Maui_Flower_App.MVVM.ViewModels.FlowersRegarding
{
    [AddINotifyPropertyChangedInterface]
    public class FlowersViewModel
    {
        #region Properties

        private List<FlowerGroupGroup> Flowers { get; set; }
        public List<FlowerGroupGroup> FilteredFlowers { get; set; }
        private IFlowerRepository _flowerRepository { get; set; }

        #endregion

        public FlowersViewModel()
        {
            _flowerRepository = ServiceHelper.GetService<IFlowerRepository>();
            Flowers = new List<FlowerGroupGroup>();
            FilteredFlowers = new List<FlowerGroupGroup>();
        }

        #region Commands

        public ICommand RedirectToFlowerNameGroupCommand => new Command<Flower>(RedirectToFlowerNameGroup);
        public ICommand RedirectToAddFlowerFormCommand => new Command(RedirectToAddFlowerForm);
        public ICommand SearchCommand => new Command<string>(Search);

        #endregion

        #region Commands Methods

        private void RedirectToFlowerNameGroup(Flower flower)
        {
            if (flower != null)
                Application.Current.MainPage.Navigation.PushAsync(new FlowerNameGroupView(flower.TypeName));
        }

        private void RedirectToAddFlowerForm()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewFlowerFormView());
        }

        //NOT WORKING
        public void Search(string flowerName)
        {
            //FilteredFlowers = Flowers.Where(f => f.TypeName.ToLower().Contains(flowerName.ToLower())).ToList();
        }

        #endregion

        public async Task InitializeFlowersAsync()
        {
            Flowers = await _flowerRepository.GetDistinctGroupsOfFlowerGroupsAsync();
            FilteredFlowers = new List<FlowerGroupGroup>(Flowers);
        }
    }
}
