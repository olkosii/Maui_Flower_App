using Maui_Flower_App.MVVM.ViewModels.FlowersRegarding;

namespace Maui_Flower_App.MVVM.Views.FlowersRegarding;

public partial class NewFlowerFormView : ContentPage
{
	private NewFlowerViewModel _newFlowerViewModel;

	public NewFlowerFormView()
	{
		InitializeComponent();

		_newFlowerViewModel = new NewFlowerViewModel();

		BindingContext = _newFlowerViewModel;
	}
}