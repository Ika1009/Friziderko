using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class NamirnicePopup : Popup
{
    FriziderPageViewModel friziderPageViewModel;
    public NamirnicePopup(FriziderPageViewModel vm)
	{
		InitializeComponent();
        friziderPageViewModel = vm;
        //Namirnica promena_teksta = new Namirnica();
	}


    private async void DodajNamirnicu(object sender, EventArgs e)
    {
        string nazivNamirnice = NazivEntry.Text;
        string opisNamirnice = OpisEntry.Text;
        string kolicinaNamirnice = KolicinaEntry.Text;
        if (string.IsNullOrEmpty(nazivNamirnice) || string.IsNullOrEmpty(opisNamirnice) || string.IsNullOrEmpty(kolicinaNamirnice))
        {
            await Shell.Current.DisplayAlert("Greška", "Morate uneti sve vrednosti!", "OK");
            return;
        }

        Namirnica namirnica = new Namirnica(nazivNamirnice, opisNamirnice, int.Parse(kolicinaNamirnice), "Za sad nema");

        await friziderPageViewModel.DodajNamirnicuAsync(namirnica);


    }
}