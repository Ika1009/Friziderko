using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friziderko.ViewModel
{
    public partial class NamirnicePopupViewModel : ObservableObject
    {
        BazaPristupServis bazaPristupServis;

        public NamirnicePopupViewModel(BazaPristupServis dbService)
        {
            bazaPristupServis= dbService;
        }

    }
}
 