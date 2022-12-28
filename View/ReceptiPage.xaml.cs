using CommunityToolkit.Maui.Views;

namespace Friziderko.View;

public partial class ReceptiPage : ContentPage
{
	public ReceptiPage()
	{
		InitializeComponent();
	}
    private void DodajRecept(object sender, EventArgs e)
    {
		this.ShowPopup(new DodajReceptPopup());
    }
}
