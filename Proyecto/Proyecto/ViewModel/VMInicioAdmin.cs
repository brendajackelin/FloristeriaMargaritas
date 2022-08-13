using System;
using System.Collections.Generic;
using System.Text;
using Proyecto.Views;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Proyecto.ViewModel
{
    public class VMInicioAdmin : BaseViewModel
    {
        public VMInicioAdmin(INavigation navigation)
        {
            Navigation = navigation;
            Navegarpendientesconfigcomamd = new Command(async () => await NavegarPendientesconfig());
            Navegarprocesoconfigcomamd = new Command(async () => await NavegarProcesoconfig());
            Navegarfinishconfigcomamd = new Command(async () => await NavegarFinishconfig());
        }

        #region PROCESOS
        private async Task NavegarPendientesconfig()
        {
            await Navigation.PushAsync(new PPendientes());
        }

        private async Task NavegarProcesoconfig()
        {
            await Navigation.PushAsync(new PProceso());
        }

        private async Task NavegarFinishconfig()
        {
            await Navigation.PushAsync(new PFinish());
        }
        #endregion

        #region COMANDOS
        public Command Navegarpendientesconfigcomamd { get; }
        public Command Navegarprocesoconfigcomamd { get; }
        public Command Navegarfinishconfigcomamd { get; }
        #endregion

    }
}
