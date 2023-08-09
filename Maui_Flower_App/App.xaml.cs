using Maui_Flower_App.MVVM.Views;

namespace Maui_Flower_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new HomeView());
	}
}
