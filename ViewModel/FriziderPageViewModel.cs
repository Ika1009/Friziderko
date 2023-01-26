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
    
    public partial class FriziderPageViewModel : ObservableObject
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

        [ObservableProperty]
        List<Namirnica> lista_namirnica = new();
        [ObservableProperty]
        ObservableCollection<Namirnica> kolekcija_namirnica = new();
        public FriziderPageViewModel(BazaPristupServis dbService) 
        {
            bazaPristupServis = dbService; 
            Title = "Frižider";
        }

        //pretvara u komandu da bi moglo da se pozove iz view
        [RelayCommand]
        //treba da se pozove pri startapu aplikacije
        public async Task GetNamirniceAsync() // samo uzima namirnice iz baze
        {
            if (isBusy)
                return;
            try
            {
                isNotBusy = false;
                isBusy = true;

                if (kolekcija_namirnica != null && kolekcija_namirnica.Count != 0)
                    kolekcija_namirnica.Clear();

                lista_namirnica = await bazaPristupServis.GetAllNamirniceAsync();

                foreach (Namirnica namirnica in lista_namirnica)
                    kolekcija_namirnica.Add(namirnica);
            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
            }
            finally { isBusy = false; isNotBusy = true; }
        }

        [RelayCommand]
		public async Task DodajNamirnicuAsync(Namirnica namirnica)
		{
			if (isBusy)
				return;
			try
			{
				isNotBusy = false;
				isBusy = true;

                bazaPristupServis.DodajNamirnicu(namirnica);              
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
			}
			finally { isBusy = false; isNotBusy = true; }
		}



		public async Task SpustiKolicinuAsync(int id)
        {
            if (isBusy)
                return;
            try
            {
                isNotBusy = false;
                isBusy = true;

                Namirnica namirnica = Pronadji(id);
                namirnica.Kolicina--;

                if (namirnica == null)
                    return;

                await bazaPristupServis.UpdateKolicinu(namirnica);

			}
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
            }
            finally { isBusy = false; isNotBusy = true; }
        }
		public async Task DigniKolicinuAsync(int id)
		{
			if (isBusy)
				return;
			try
			{
				isNotBusy = false;
				isBusy = true;

				Namirnica namirnica = Pronadji(id);
				namirnica.Kolicina++;

				if (namirnica == null)
					return;

				await bazaPristupServis.UpdateKolicinu(namirnica);

			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
			}
			finally { isBusy = false; isNotBusy = true; }
		}

		public void ObrisiNamirnicu(int id)
        {
            Namirnica namirnicaZaBrisanje = lista_namirnica.Where(x => x.Id == id).First();
            kolekcija_namirnica.Remove(namirnicaZaBrisanje);
            lista_namirnica.Remove(namirnicaZaBrisanje);
            bazaPristupServis.ObrisiNamirnicu(namirnicaZaBrisanje);
        }

        public Namirnica Pronadji(int id)
        {
            return lista_namirnica.Where(x => x.Id == id).First();
        }

        public void Searchbar(string searchTerm)
        {
			var filteredItems = lista_namirnica.Where(value => value.Naziv.ToLowerInvariant().Contains(searchTerm)).ToList();

			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				searchTerm = string.Empty;
				filteredItems = lista_namirnica;
			}

			foreach (var value in lista_namirnica)
			{
				if (!filteredItems.Contains(value))
				{
					kolekcija_namirnica.Remove(value);
				}
				else if (!Kolekcija_namirnica.Contains(value))
				{
					kolekcija_namirnica.Add(value);

				}
			}
		}
	}
}
