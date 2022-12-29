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
        BazaPristupServis bazaPristupServis;
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
        ObservableCollection<Namirnica> kolekcija_namirnica;
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

                var namirnice = await bazaPristupServis.GetAllNamirniceAsync();

                foreach (Namirnica namirnica in namirnice)
                    kolekcija_namirnica.Add(namirnica);

            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
            }
            finally { isBusy = false; isNotBusy = true; }
        }
        


        
    }
}
