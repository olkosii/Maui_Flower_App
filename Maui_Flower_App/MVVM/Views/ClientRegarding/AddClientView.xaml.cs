using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.ViewModels.ClientsRegarding;

namespace Maui_Flower_App.MVVM.Views.ClientRegarding;

public partial class AddClientView : ContentPage
{
	private AddClientViewModel _addClientViewModel;
	public AddClientView()
	{
		InitializeComponent();

		_addClientViewModel = new AddClientViewModel();

		BindingContext = _addClientViewModel;
	}
}