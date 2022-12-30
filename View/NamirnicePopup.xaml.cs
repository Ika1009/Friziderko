using CommunityToolkit.Maui.Views;
using Friziderko.Model;
using Friziderko.ViewModel;

namespace Friziderko.View;

public partial class NamirnicePopup : Popup
{

	public NamirnicePopup(NamirnicePopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}