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
        this.ShowPopup(new NamirnicePopup(friziderkoPageViewModel, null));

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
    private void Promeni(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        //pronadje namirnicu koju zeli da promeni
        Namirnica namirnica = friziderkoPageViewModel.Pronadji((int)button.BindingContext);

		this.ShowPopup(new NamirnicePopup(friziderkoPageViewModel, namirnica));
	}

	private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
        string searchTerm = e.NewTextValue.ToLowerInvariant();

        friziderkoPageViewModel.Searchbar(searchTerm);
        
    }
}