using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.ViewModels.ClientsRegarding;

namespace Maui_Flower_App.MVVM.Views.ClientRegarding;

public partial class ClientDetailsView : ContentPage
{
	private ClientDetailsViewModel _viewModel;
	public ClientDetailsView(Client client)
	{
		InitializeComponent();

		_viewModel = new ClientDetailsViewModel(client);

		BindingContext = _viewModel;
	}
}