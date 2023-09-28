using Maui_Flower_App.MVVM.Models;
using Maui_Flower_App.MVVM.ViewModels.ClientsRegarding;

namespace Maui_Flower_App.MVVM.Views.ClientRegarding;

public partial class ClientsView : ContentPage
{
	private ClientsViewModel _clientViewModel;
    private SwipeView _previousSwipeView;

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

    private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
    {
        clientsCollectionView.SelectionChangedCommand = null;

        if (_previousSwipeView != null && _previousSwipeView.IsVisible)
            _previousSwipeView.Close();
    }

    private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
    {
        _previousSwipeView = (SwipeView)sender;
    }

    private void clientsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(clientsCollectionView.SelectionChangedCommand == null)
            clientsCollectionView.SelectionChangedCommand = _clientViewModel.ItemSelectedCommand;
    }

    private async void deleteClientButton_Clicked(object sender, EventArgs e)
    {
        if(clientsCollectionView.SelectedItem is Client client)
            await _clientViewModel.DeleteClientAsync(client);

        clientsCollectionView.SelectionChangedCommand = _clientViewModel.ItemSelectedCommand;
    }
}