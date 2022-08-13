using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Proyecto.Views;

namespace Proyecto.ViewModel
{
    public class VMInicioUser : BaseViewModel
    {
        public VMInicioUser(INavigation navigation)
        {
            Navigation = navigation;
            Navegarpedidoconfigcomamd = new Command(async () => await NavegarPedidosconfig());
            Navegarcontactoconfigcomamd = new Command(async () => await NavegarContactoconfig());
        }

        #region PROCESOS
        private async Task NavegarPedidosconfig()
        {
            await Navigation.PushAsync(new Pedido3());
        }

        private async Task NavegarContactoconfig()
        {
            await Navigation.PushAsync(new Contacto());
        }
        #endregion

        #region COMANDOS
        public Command Navegarpedidoconfigcomamd { get; }
        public Command Navegarcontactoconfigcomamd { get; }
        #endregion
    }


}
