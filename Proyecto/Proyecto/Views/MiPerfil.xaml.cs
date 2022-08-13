using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.ViewModel;
using Proyecto.Models;
using Proyecto.Controllers;
using Acr.UserDialogs;
using System.IO;
using Xamarin.Essentials;


namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiPerfil : ContentPage
    {

        User user;
        public string _nom,_mail;

        public MiPerfil()
        {
            InitializeComponent();
            

        }

        /*private async void btnGaleria_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisUbicaciones());
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisUbicaciones());
        }*/

        protected async override void OnAppearing()
        {
            _nom = Preferences.Get("txtNombre", string.Empty);
            txtNombre.Text = _nom;

            //var usuario = await App.DBase.obtenerUsuario(2, txtNombre.Text);


            var perfil = new User
            {
                nombre = txtNombre.Text,
            };

            var usu = await ApiUsuario.GetUsuario(perfil);

            if (usu != null)
            {
                usu.apellido = txtApellido.Text;
            }

         //   List<User> sit = await ApiUsuario.GetUsuario(perfil);
          //  list.ItemsSource = sit;

            //var usuario = await App.DBase.obtenerCuentaUser(3, _mail);

            //txtNombre.IsVisible = true;
            //txtNombre.Text = perfil.nombre;
            //txtApellido.Text = perfil.apellido;
            /*txtTelefono.Text = perfil.telefono;
            txtCorreo.Text = perfil.correo;
            */

            /*var persistencia = await App.DBase.obtenerPersistencia(1);
            if (persistencia.Email != null)
            {
                //correo.Text = persistencia.Email;
                var usuario = await App.DBase.obtenerCuentaUser(3, persistencia.Email);
                // usuario.nombre = nombre;
                // usuario.apellido = apellido;
                txtNombre.Text = usuario.nombre;
                txtApellido.Text = usuario.apellido;
                txtTelefono.Text = usuario.telefono;
                txtCorreo.Text = usuario.correo;
                //correo.Text = usuario.ToString();
                //recargar();
            }
            else
            {
                string _nom = Preferences.Get("txtCorreo", string.Empty);
                //correo.Text = _correo;
                //var usuario = await App.DBase.obtenerUsuario(_correo);
                var usuario = await App.DBase.obtenerCuentaUser(3, _nom);
                txtNombre.Text = usuario.nombre;
                txtApellido.Text = usuario.apellido;
                txtTelefono.Text = usuario.telefono;
                txtCorreo.Text = usuario.correo;
                //usuario.nombre = correo.Text;
                //correo.Text = usuario.ToString();
                //recargar();
            }*/

        }

        private async void btnUbicaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisUbicaciones());
        }

        public async void recargar()
        {
            var usuario = await App.DBase.obtenerUsuario(3, txtCorreo.Text);
            // txtNombre.Text = usuario.nombre;
            // txtApellido.Text = usuario.apellido;
            // txtTelefono.Text = usuario.telefono;
            //txtCorreo.Text = usuario.correo;

            //  var cuentas = await App.DBase.obtenerCuentasUsuario(pusuario.NumeroIdentidad);

        }

    }
}