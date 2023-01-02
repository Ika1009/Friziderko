using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class NamirnicePopup : Popup
{
	BazaPristupServis bazaPristupServis;

    string nazivNamirnice;

    string kolicinaNamirnice;

    string opisNamirnice;

    public NamirnicePopup(BazaPristupServis dbService)
	{
		InitializeComponent();
        bazaPristupServis = dbService;
	}

    private void Nazivcina_PromenaTeksta(object sender, EventArgs e)
    {
        nazivNamirnice = Nazivcina.Text;
    }

    private void Opiscina_PromenaTeksta(object sender, EventArgs e)
    {
        opisNamirnice = Opiscina.Text;
    }

    private void Kolicincina_PromenaTeksta(object sender, EventArgs e)
    {
        kolicinaNamirnice = Kolicincina.Text;
    }

    private async void DodajNamirnicu(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(nazivNamirnice) || string.IsNullOrEmpty(opisNamirnice) || string.IsNullOrEmpty(kolicinaNamirnice))
        {
            await Shell.Current.DisplayAlert("Greška", "Morate uneti sve vrednosti!", "OK");
            return;
        }

        bazaPristupServis.DodajNamirnicu(new Namirnica(nazivNamirnice, opisNamirnice, int.Parse(kolicinaNamirnice), "Za sad nema"));

        this.Close();

    }
}