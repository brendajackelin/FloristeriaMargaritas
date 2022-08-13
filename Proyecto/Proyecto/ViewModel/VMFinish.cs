using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.Views;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Proyecto.ViewModel
{
    public class VMFinish : BaseViewModel
    {
        public VMFinish(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await Volver());
        }

        #region PROCESOS
       
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public Command Volvercomamd { get; }
        #endregion

    }
}
