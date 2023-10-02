using Maui_Flower_App.MVVM.ViewModels.FlowersRegarding;

namespace Maui_Flower_App.MVVM.Views.FlowersRegarding;

public partial class FlowerNameGroupView : ContentPage
{
	private FlowerNameGroupViewModel _viewModel;
	public FlowerNameGroupView(string flowerName)
	{
		InitializeComponent();

		_viewModel = new FlowerNameGroupViewModel(flowerName);

		BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await _viewModel.InitializeFlowersAsync();
    }
}