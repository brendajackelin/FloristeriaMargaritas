using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Proyecto.Views;

namespace Proyecto.ViewModel
{
    public class VMPedido:BaseViewModel
    {
        #region CONSTRUCTOR
        public VMPedido(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await Volver());
        }
        #endregion

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
