using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class NamirnicePopup : Popup
{
	BazaPristupServis bazaPristupServis;

    public NamirnicePopup(BazaPristupServis dbService, FriziderPageViewModel vm)
	{
		InitializeComponent();
        bazaPristupServis = dbService;
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

        string status = bazaPristupServis.DodajNamirnicu(new Namirnica(nazivNamirnice, opisNamirnice, int.Parse(kolicinaNamirnice), "Za sad nema"));

		
        if (status != "success")
            await Shell.Current.DisplayAlert("Greška", "Došlo je do greške: " + status, "OK");


    }
}