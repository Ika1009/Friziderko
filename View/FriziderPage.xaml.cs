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
    private async void Obrisi(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (await DisplayAlert("Pitanje", "Da li ste sigurni da zelite da izbrisete namirnicu?", "DA", "NE"))
        {
            try
            {
                friziderkoPageViewModel.ObrisiNamirnicu((int)button.BindingContext);
            }

            catch (Exception)
            {
                await DisplayAlert("Greska", "Nije moguce izbrisati namirnicu", "OK");
            }
        }
    }

    private async void Ucitaj(object sender, EventArgs e)
    {
		//zove se funkcija koja popunjava kolekciju namirnica, koja se zatim ispisuje
		await friziderkoPageViewModel.GetNamirniceAsync();
    }
	private void Edit(object sender, EventArgs e)
	{
		CustomImageButton button = (CustomImageButton)sender;

		//uzima id od klase
		int id = button.ImageId;

		Namirnica namirnica = friziderkoPageViewModel.Pronadji(id);

		this.ShowPopup(new NamirnicePopup(friziderkoPageViewModel, namirnica));
	}



	private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
	{
        string searchTerm = e.NewTextValue.ToLowerInvariant();

        friziderkoPageViewModel.Searchbar(searchTerm);
        
    }

	private async void Spusti(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		int id = (int)button.BindingContext;
        
        await friziderkoPageViewModel.SpustiKolicinuAsync(id);

        await friziderkoPageViewModel.GetNamirniceAsync();

        
	}
	private async void Digni(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		int id = (int)button.BindingContext;

		await friziderkoPageViewModel.DigniKolicinuAsync(id);

		await friziderkoPageViewModel.GetNamirniceAsync();
	}
}