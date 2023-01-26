using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using Friziderko.Model;
using Friziderko.ViewModel;
using Microsoft.Win32;

namespace Friziderko.View;

public partial class NamirnicePopup : Popup
{
    FriziderPageViewModel friziderPageViewModel;
    FileResult result;
    Namirnica namirnica1;
    public NamirnicePopup(FriziderPageViewModel vm, Namirnica namirnica)
    {
        InitializeComponent();
        BindingContext= vm;
        friziderPageViewModel = vm;
        namirnica1 = namirnica;
        //ako je se edituje onda namirnica postoji tj nije null, samim time se postavljaju vrednosti jer se edituje ista
        if(namirnica1 != null )
        {
            NazivEntry.Text = namirnica.Naziv;
            OpisEntry.Text = namirnica.Opis;
            KolicinaEntry.Text = namirnica.Kolicina.ToString();
            Slika.Source = namirnica.Put_slika;
            Dugme.Text = "Promeni";
        }
    }


    private async void DodajNamirnicu(object sender, EventArgs e)
    {


        Namirnica namirnica;
        string nazivNamirnice = NazivEntry.Text;
        string opisNamirnice = OpisEntry.Text;
        string kolicinaNamirnice = KolicinaEntry.Text;

        if (string.IsNullOrEmpty(nazivNamirnice) || string.IsNullOrEmpty(opisNamirnice) || string.IsNullOrEmpty(kolicinaNamirnice))
        {
            await Shell.Current.DisplayAlert("Greška", "Morate uneti sve vrednosti!", "OK");
            return;
        }
        
        if (namirnica1 != null)
        {
            friziderPageViewModel.ObrisiNamirnicu(namirnica1.Id);
        }

        // ako je resultat null tj ne izabere se slika, onda se doda default umesto nje
        if (result == null)
        {
            namirnica = new Namirnica(nazivNamirnice, opisNamirnice, int.Parse(kolicinaNamirnice), "help_icon.png");
        }
        else
        {
			namirnica = new Namirnica(nazivNamirnice, opisNamirnice, int.Parse(kolicinaNamirnice), result.FullPath);
		}

        

        await friziderPageViewModel.DodajNamirnicuAsync(namirnica);

        //reset za sledece dodavanje
        NazivEntry.Text = "";
        OpisEntry.Text = "";
        KolicinaEntry.Text = "";
        Slika.Source = "help_icon.png";


		await friziderPageViewModel.GetNamirniceAsync(); // update kolekcije(jer se upravo dodala nova)


    }
    private void Izadji(object sender, EventArgs e)
    {
        Close();
    }

    private async void DodajSliku(object sender, EventArgs e)
    {
        //za upload slike
        result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images, 
            PickerTitle = "Izaberite sliku"
        }); 

        //ako se ne izabere slika
        if(result == null)
        {
            return;
        }


        //put do slike
        var stream = await result.OpenReadAsync();

        Slika.Source =  ImageSource.FromStream(() => stream);
        Slika.Aspect = Aspect.AspectFill;
	}
}