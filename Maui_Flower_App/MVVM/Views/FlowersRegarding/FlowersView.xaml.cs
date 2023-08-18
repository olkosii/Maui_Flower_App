using Maui_Flower_App.MVVM.ViewModels.FlowersRegarding;

namespace Maui_Flower_App.MVVM.Views.FlowersRegarding;

public partial class FlowersView : ContentPage
{
	private FlowersViewModel _flowersViewModel;

	public FlowersView()
	{
		InitializeComponent();

		_flowersViewModel = new FlowersViewModel();

		BindingContext = _flowersViewModel;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

		await _flowersViewModel.InitializeFlowersAsync();
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		_flowersViewModel.Search(searchBar.Text);
    }
}