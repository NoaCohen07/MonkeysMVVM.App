using MonkeysMVVM.ViewModels;
namespace MonkeysMVVM.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
		this.BindingContext = new ShowByLocationViewModel();
	}
}