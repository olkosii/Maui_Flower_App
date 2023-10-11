using Maui_Flower_App.MVVM.ViewModels.OrdersRegarding;

namespace Maui_Flower_App.MVVM.Views.OrdersRegarding;

public partial class NewOrderView : ContentPage
{
	private NewOrderViewModel _viewModel;
	public NewOrderView()
	{
		InitializeComponent();

		_viewModel = new NewOrderViewModel();

		BindingContext = _viewModel;
	}
}