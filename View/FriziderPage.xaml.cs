using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;
using System.Collections.ObjectModel;

namespace Friziderko.View;

public partial class FriziderPage : ContentPage
{
    NamirnicePopup popup;
    public FriziderPage(FriziderPageViewModel vm, NamirnicePopup np)
	{
		InitializeComponent();
        BindingContext = vm;
        popup = np;
	}

    private void DodajNamirnicu(object sender, EventArgs e)
    {
        this.ShowPopup(popup);

    }

}