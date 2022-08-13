using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.ViewModel;
using Proyecto.Models;
namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioAdmin : ContentPage
    {
        public InicioAdmin()
        {
            InitializeComponent();
            BindingContext = new VMInicioAdmin(Navigation);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {

            var action = await App.Current.MainPage.DisplayAlert("Alert", "¿Estás seguro de cerrar sesión?", "Si", "No");

            if (action == true)
            {
                Persistencia persistencia = new Persistencia();
                persistencia.Id = 1;
                persistencia.Email = null;
                persistencia.Clave = null;

                await App.DBase.PersistenciaSave(persistencia);

                await Navigation.PushAsync(new Login());
            }
        }
    }
}