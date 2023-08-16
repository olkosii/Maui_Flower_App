using Maui_Flower_App.MVVM.ViewModels.FlowersRegarding;

namespace Maui_Flower_App.MVVM.Views.FlowersRegarding;

public partial class FlowersView : ContentPage
{
    private FlowersViewModel _flowersViewModel;

    public FlowersView()
    {
        InitializeComponent();

        _flowersViewModel = new FlowersViewModel();

        BindingContext = _flowersViewModel;
    }
}