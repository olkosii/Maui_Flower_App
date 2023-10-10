using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.ViewModels.FlowersRegarding;

namespace Maui_Flower_App.MVVM.Views.FlowersRegarding;

public partial class FlowerDetailsView : ContentPage
{
	private FlowerDetailsViewModel _viewModel;
	public FlowerDetailsView(Flower flower)
	{
		InitializeComponent();

		_viewModel = new FlowerDetailsViewModel(flower);

		BindingContext = _viewModel;
	}
}