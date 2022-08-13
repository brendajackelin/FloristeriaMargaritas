using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Acr.UserDialogs;
using Proyecto.Models;
using Proyecto.Controller;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuario : ContentPage
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                txtPass.IsPassword = false;
                ver.Text = "Ocultar contraseña";
            }
            else
            {
                txtPass.IsPassword = true;
                ver.Text = "Mostrar contraseña";
            }

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            

            string WebAPIkey = "AIzaSyAWGQVBeuz1m_zLJOqk5tw1kiK55SMckR8";

            if (ValidationForm().IsCompleted) {

                txtNombre.IsEnabled = false;
                txtApellido.IsEnabled = false;
                txtTelefono.IsEnabled = false;
                txtCorreo.IsEnabled = false;
                txtPass.IsEnabled = false;
                

                    try
                    {
                        UserDialogs.Instance.ShowLoading();

                        var usuario = await App.DBase.obtenerUsuario(3, txtCorreo.Text);

                        if (usuario == null)
                        {
                            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));

                            //Crear el usuario en firebase
                            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(txtCorreo.Text, txtPass.Text);

                            string gettoken = auth.FirebaseToken;
                            var content = await auth.GetFreshAuthAsync();
                            var serializedcontent = JsonConvert.SerializeObject(content);
                            Preferences.Set("MyFirebaseRefreshToken", serializedcontent);

                            var uid = auth.User.LocalId;

                            //await DisplayAlert("Salvado", "uid" + uid , "Ok");

                            try
                            {

                                //usu
                                var user = new Models.User
                                {
                                    uid = uid,
                                    correo = txtCorreo.Text,
                                    nombre = txtNombre.Text,
                                    apellido = txtApellido.Text,
                                    telefono = txtTelefono.Text,
                                };

                                await App.DBase.CuentaSave(1, user);
                                await Controllers.ApiUsuario.CrearUsuario(user);
                            }
                            catch (Exception ex)
                            {
                                UserDialogs.Instance.HideLoading();
                                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                            }

                            // Enviar correo de verificación
                            await authProvider.SendEmailVerificationAsync(content.FirebaseToken);

                            UserDialogs.Instance.HideLoading();
                            await DisplayAlert("Salvado", "¡Bienvenido(a) " + txtNombre.Text + "! Tu cuenta se registró correctamente. " +
                            "Se envió un mensaje de verificación a tu correo electrónico.", "Ok");
                            ClearScreen();
                            await Application.Current.MainPage.Navigation.PopAsync();
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            await DisplayAlert("Alerta", "El correo electrónico que ha ingresado ya existe, inicie sesión", "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                        ClearScreen();
                    }
                

            }

        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void ClearScreen()
        {
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtCorreo.IsEnabled = true;
            txtPass.IsEnabled = true;

            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtCorreo.Text = String.Empty;
            txtPass.Text = String.Empty;
        }

        private async Task ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(txtNombre.Text) ||
                String.IsNullOrWhiteSpace(txtApellido.Text) ||
                String.IsNullOrWhiteSpace(txtTelefono.Text) ||
                String.IsNullOrWhiteSpace(txtCorreo.Text) ||
                String.IsNullOrWhiteSpace(txtPass.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "OK");
            }

            if (txtPass.Text.Length < 6)
            {
                await this.DisplayAlert("Advertencia", "La contraseña debe ser mayor a 5 caracteres", "OK");
            }
        }

    }
}