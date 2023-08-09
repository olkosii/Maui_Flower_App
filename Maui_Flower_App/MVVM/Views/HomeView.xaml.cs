using Maui_Flower_App.MVVM.ViewModels;
using Maui_Flower_App.MVVM.Views.ClientRegarding;

namespace Maui_Flower_App.MVVM.Views;

public partial class HomeView : ContentPage
{
	private HomeViewModel _homeViewModel;
	public HomeView()
	{
		InitializeComponent();

		_homeViewModel = new HomeViewModel();

		BindingContext = _homeViewModel;
	}
}