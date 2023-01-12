using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;
using System.Collections.ObjectModel;

namespace Friziderko.View;

public partial class FriziderPage : ContentPage
{
    FriziderPageViewModel friziderkoPageViewModel;
    public FriziderPage(FriziderPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        friziderkoPageViewModel = vm;
	}

    private void DodajNamirnicu(object sender, EventArgs e)
    {
        this.ShowPopup(new NamirnicePopup(friziderkoPageViewModel));

    }
    private void Obrisi(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        friziderkoPageViewModel.ObrisiNamirnicu((int)button.BindingContext);
    }
    private async void Ucitaj(object sender, EventArgs e)
    {
		//zove se funkcija koja popunjava kolekciju namirnica, koja se zatim ispisuje
		await friziderkoPageViewModel.GetNamirniceAsync();
    }
}