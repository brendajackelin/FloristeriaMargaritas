using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Proyecto.Views;
using Firebase.Auth;
using Xamarin.Essentials;
using Proyecto.ViewModel;
using Xamarin.Forms.Xaml;

using Proyecto.Models;

namespace Proyecto
{
    public partial class InicioUser : ContentPage
    {
        string useremail;
        string nombre;
        string apellido;

        public InicioUser()
        {
            InitializeComponent();
            BindingContext = new VMInicioUser(Navigation);
            
        } 

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        
        
        protected override async void OnAppearing()
        {
            var persistencia = await App.DBase.obtenerPersistencia(1);
            if (persistencia.Email != null)
            {
                //correo.Text = persistencia.Email;
                var usuario = await App.DBase.obtenerCuentaUser(3,persistencia.Email);
               // usuario.nombre = nombre;
               // usuario.apellido = apellido;
                correo.Text = "" + usuario.nombre+ " " + usuario.apellido;
                //correo.Text = usuario.ToString();
            }
            else
            {
                string _correo = Preferences.Get("txtCorreo", string.Empty);
                //correo.Text = _correo;
                //var usuario = await App.DBase.obtenerUsuario(_correo);
                var usuario = await App.DBase.obtenerCuentaUser(3, _correo);
                correo.Text = "" + usuario.nombre;
                //usuario.nombre = correo.Text;
                //correo.Text = usuario.ToString();
            }
            
        }

        private async void btnMiPerfil_Clicked(object sender, EventArgs e)
        {
            /*var persistencia = await App.DBase.obtenerPersistencia(1);
            if (persistencia.Email != null)
            {
                var usuario = await App.DBase.obtenerCuentaUser(3, persistencia.Email);
                Preferences.Set("txtCorreo", persistencia.Email);
                await Navigation.PushAsync(new MiPerfil());
            }
            else
            {
                string _correo = Preferences.Get("txtCorreo", string.Empty);
                var usuario = await App.DBase.obtenerCuentaUser(3, _correo);
                Preferences.Set("txtCorreo", persistencia.Email);
                await Navigation.PushAsync(new MiPerfil());
            }*/
           /* var persistencia = await App.DBase.obtenerPersistencia(1);
            if (persistencia.Email != null)
            {
                //var usuario = await App.DBase.obtenerCuentaUser(3, persistencia.Email);
                Preferences.Set("txtEmail", persistencia.Email);
            }
            else
            {
                string _correo = Preferences.Get("txtCorreo", string.Empty);
                Preferences.Set("txtEmail", _correo);
            }*/

            Preferences.Set("txtNombre", correo.Text);
            
            await Navigation.PushAsync(new MiPerfil());
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
