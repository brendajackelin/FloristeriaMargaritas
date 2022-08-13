using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.Views;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace Proyecto.ViewModel
{
    public class VMUbicaciones : BaseViewModel
    {
        public VMUbicaciones(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await Volver());
            Navegarubicacionesconfigcomamd = new Command(async () => await NavegarUbicacionesconfig());
        }

        #region PROCESOS
        private async Task NavegarUbicacionesconfig()
        {
            await Navigation.PushAsync(new Map());
        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public Command Navegarubicacionesconfigcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion

    }
}
