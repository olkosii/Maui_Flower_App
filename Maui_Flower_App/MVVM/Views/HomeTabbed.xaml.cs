namespace Maui_Flower_App.MVVM.Views;

public partial class HomeTabbed : TabbedPage
{
	public HomeTabbed(string pageName)
	{
		InitializeComponent();

		switch (pageName)
		{
			case "ClientsView":
				CurrentPage = Children.FirstOrDefault();
				break;
			case "FlowersView":
				CurrentPage = Children.Skip(1).FirstOrDefault();
				break;
            case "OrdersView":
                CurrentPage = Children.Skip(2).FirstOrDefault();
                break;
            default:
				break;
		}
	}
}