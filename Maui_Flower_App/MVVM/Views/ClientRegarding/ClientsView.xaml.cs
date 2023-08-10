using Maui_Flower_App.MVVM.ViewModels.ClientsRegarding;

namespace Maui_Flower_App.MVVM.Views.ClientRegarding;

public partial class ClientsView : ContentPage
{
	private ClientsViewModel _clientViewModel;
	public ClientsView()
	{
		InitializeComponent();

		_clientViewModel = new ClientsViewModel();

		BindingContext = _clientViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await _clientViewModel.InitializeClientsAsync();
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		_clientViewModel.Search(searchBar.Text);
    }
}