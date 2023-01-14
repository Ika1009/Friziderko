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
    public NamirnicePopup(FriziderPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
        friziderPageViewModel = vm;
    }


    private async void DodajNamirnicu(object sender, EventArgs e)
    {
        string nazivNamirnice = NazivEntry.Text;
        string opisNamirnice = OpisEntry.Text;
        string kolicinaNamirnice = KolicinaEntry.Text;
        Namirnica namirnica;

        if (string.IsNullOrEmpty(nazivNamirnice) || string.IsNullOrEmpty(opisNamirnice) || string.IsNullOrEmpty(kolicinaNamirnice))
        {
            await Shell.Current.DisplayAlert("Gre�ka", "Morate uneti sve vrednosti!", "OK");
            return;
        }

        // ako je resultat null tj ne izabere se slika, onda se doda znak pitanja umesto nje
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
        this.Close();
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



        var stream = await result.OpenReadAsync();

        Slika.Source =  ImageSource.FromStream(() => stream);
        Slika.Aspect = Aspect.AspectFill;
	}
}