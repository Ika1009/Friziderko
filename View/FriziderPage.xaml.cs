using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;
using System.Collections.ObjectModel;

namespace Friziderko.View;

public partial class FriziderPage : ContentPage
{
    FriziderPageViewModel vmm;
    public FriziderPage(FriziderPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        vmm = vm;
	}

    private void DodajNamirnicu(object sender, EventArgs e)
    {
        this.ShowPopup(new NamirnicePopup(vmm));

    }
    private void Obrisi(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        vmm.ObrisiNamirnicu((int)button.BindingContext);
        
        button.Text = button.BindingContext.ToString();
    }

}