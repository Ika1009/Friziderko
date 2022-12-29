using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class FriziderPage : ContentPage
{
    public FriziderPage(FriziderPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void DodajNamirnicu(object sender, EventArgs e)
    {
        this.ShowPopup(new DodajNamirnicePopup());
    }

}