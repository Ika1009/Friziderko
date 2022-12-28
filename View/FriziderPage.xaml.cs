using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class FriziderPage : ContentPage
{
	//DodajUBazu dodajUBazu;
    public FriziderPage()
	{
		InitializeComponent();
		///dodajUBazu = new DodajUBazu(System.IO.Path.Combine(FileSystem.AppDataDirectory, "BazaPodataka3"));
    }

    private void DodajNamirnicu(object sender, EventArgs e)
    {
        this.ShowPopup(new DodajNamirnicePopup());
    }

}