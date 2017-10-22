using PlanilhaDoHugo.ViewModels;
using Xamarin.Forms;

namespace PlanilhaDoHugo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new MainPageViewModel();

        }

    }
}
