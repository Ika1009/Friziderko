using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Friziderko.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friziderko.ViewModel
{
    public partial class ShoppingListaPageViewModel : ObservableObject
    {
        readonly BazaPristupServis bazaPristupServis;
		[ObservableProperty]
		string title;

		bool isBusy = false, isNotBusy = true;

		public bool IsNotBusy
		{
			get => isNotBusy; set => isNotBusy = value;
		}
		public bool IsBusy
		{
			get => isBusy; set => isBusy = value;
		}

		List<Artikal> lista_artikal = new();
		[ObservableProperty]
		ObservableCollection<Artikal> kolekcija_artikal = new();
		public ShoppingListaPageViewModel(BazaPristupServis dbService)
		{
			bazaPristupServis = dbService;
			title = "Kupovna lista";
		}

		//pretvara u komandu da bi moglo da se pozove iz view
		[RelayCommand]
		//treba da se pozove pri startapu aplikacije
		public async Task GetArtikleAsync() // samo uzima Artikle iz baze
		{
			if (isBusy)
				return;
			try
			{
				isNotBusy = false;
				isBusy = true;

				if (kolekcija_artikal != null && kolekcija_artikal.Count != 0)
					kolekcija_artikal.Clear();

				lista_artikal = await bazaPristupServis.GetAllArtikalsAsync();

				foreach (Artikal artikal in lista_artikal)
					kolekcija_artikal.Add(artikal);
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
			}
			finally { isBusy = false; isNotBusy = true; }
		}

		[RelayCommand]
		public async Task DodajArtikalAsync(Artikal artikal)
		{
			if (isBusy)
				return;
			try
			{
				isNotBusy = false;
				isBusy = true;

				bazaPristupServis.DodajArtikal(artikal);
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
			}
			finally { isBusy = false; isNotBusy = true; }
		}

		public void ObrisiArtikal(int id)
		{
			Artikal ArtikalZaBrisanje = lista_artikal.Where(x => x.Id == id).First();
			kolekcija_artikal.Remove(ArtikalZaBrisanje);
			bazaPristupServis.ObrisiArtikal(ArtikalZaBrisanje);
		}
	}
}
