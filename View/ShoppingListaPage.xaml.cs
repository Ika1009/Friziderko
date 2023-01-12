using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;
using System.Collections.ObjectModel;

namespace Friziderko.View;

public partial class ShoppingListaPage : ContentPage
{
	ShoppingListaPageViewModel shoppingListaPageViewModel;
	public ShoppingListaPage(ShoppingListaPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		shoppingListaPageViewModel = vm;
	}

	private async void DodajArtikal(object sender, EventArgs e)
	{
		string Naziv = DodajEntry.Text;

		if(string.IsNullOrEmpty(Naziv))
		{
			await Shell.Current.DisplayAlert("Greška", "Morate uneti naziv artikla!", "OK");
		}

		Artikal artikal = new Artikal(Naziv, false);

		await shoppingListaPageViewModel.DodajArtikalAsync(artikal);

		DodajEntry.Text = "";

	}
	private void Obrisi(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		shoppingListaPageViewModel.ObrisiArtikal((int)button.BindingContext);
	}
	private async void Ucitaj(object sender, EventArgs e)
	{
		//zove se funkcija koja popunjava kolekciju artikla, koja se zatim ispisuje
		await shoppingListaPageViewModel.GetArtikleAsync();
	}
}