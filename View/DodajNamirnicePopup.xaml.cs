using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class DodajNamirnicePopup : Popup
{ 
	public DodajNamirnicePopup()
	{
		InitializeComponent();
	}
	private void DodajElement(object sender, EventArgs e)
	{
		string Naziv = Nazivcina.Text;
		string Opis = Opiscina.Text;
		int Kolicina = int.Parse(Kolicincina.Text);
		Namirnica namirnica = new Namirnica(Naziv, Opis, Kolicina, /*ovde treba da se stavi PUT DO SLIKE*/"0");
		BazaPristupServis bazaPristupServis;
		
		//bazaPristupServis.DodajNamirnicu(namirnica);
	}
}