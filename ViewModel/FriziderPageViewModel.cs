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

        bool isBusy = false;

        [ObservableProperty]
        ObservableCollection<Namirnica> kolekcija_namirnica;
        public FriziderPageViewModel(BazaPristupServis dbService) 
        {
            bazaPristupServis = dbService; 
            title = "Frižider";
        }

        //pretvara u komandu da bi moglo da se pozove iz view
        [RelayCommand]
        public async Task GetNamirniceAsync() // samo uzima namirnice iz baze
        {
            if (isBusy)
                return;
            try
            {
                isBusy = true;

                if (kolekcija_namirnica.Count != 0)
                    kolekcija_namirnica.Clear();

                var namirnice = await bazaPristupServis.GetAllNamirniceAsync();

                foreach (Namirnica namirnica in namirnice)
                    kolekcija_namirnica.Add(namirnica);

            }
            catch (Exception ex) {
                await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
            }
            finally { isBusy = false; }
        }
        


        
    }
}
