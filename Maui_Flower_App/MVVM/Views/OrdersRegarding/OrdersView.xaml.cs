using Maui_Flower_App.MVVM.ViewModels.OrdersRegarding;

namespace Maui_Flower_App.MVVM.Views.OrdersRegarding;

public partial class OrdersView : ContentPage
{
	private OrdersViewModel _viewModel;
	public OrdersView()
	{
		InitializeComponent();

		_viewModel = new OrdersViewModel();

		BindingContext = _viewModel;
	}


}