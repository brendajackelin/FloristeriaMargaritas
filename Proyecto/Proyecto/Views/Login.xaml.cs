using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Acr.UserDialogs;
using Proyecto.Models;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //private FirebaseAuth mAuth;
        public Login()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override async void OnAppearing()
        {

            // PERSISTENCIA obtener
            var persistencia = await App.DBase.obtenerPersistencia(1);
            if (persistencia != null)
            {
                try
                {
                    if(persistencia.Email != null)
                    {
                        txtCorreo.Text = persistencia.Email;
                        txtPass.Text = persistencia.Clave;
                        procesoIniciar();
                    }
                    
                }catch(Exception error) { }
            }

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
            await Navigation.PushAsync(new RegistrarUsuario());
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            //Validar la Persistencia de datos

            procesoIniciar();
        }

        async void procesoIniciar()
        {
           

            // await Navigation.PushAsync(new MainPage());

            string WebAPIkey = "AIzaSyAWGQVBeuz1m_zLJOqk5tw1kiK55SMckR8";

            if (ValidationForm().IsCompleted)
            {
                try
                {
                    var usuario = await App.DBase.obtenerUsuario(3, txtCorreo.Text);
                    Preferences.Set("txtCorreo", txtCorreo.Text);

                    UserDialogs.Instance.ShowLoading();

                    if (usuario!=null)
                    {
                        try {
                            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));

                            var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtCorreo.Text, txtPass.Text);
                            var content = await auth.GetFreshAuthAsync();
                            var serializedcontent = JsonConvert.SerializeObject(content);
                            Preferences.Set("MyFirebaseRefreshToken", serializedcontent);

                            var uid = auth.User.LocalId;

                           

                            if (SaveUser.IsToggled == true)
                            {
                                Persistencia persistencia = new Persistencia();
                                persistencia.Id = 1;
                                persistencia.Email = txtCorreo.Text;
                                persistencia.Clave = txtPass.Text;

                                await App.DBase.PersistenciaSave(persistencia);
                            }
                            else
                            {
                                Persistencia persistencia = new Persistencia();
                                persistencia.Id = 1;
                                persistencia.Email = null;
                                persistencia.Clave = null;

                                await App.DBase.PersistenciaSave(persistencia);
                            }

                            UserDialogs.Instance.HideLoading();



                            if (content.User.IsEmailVerified == false)
                            {

                                var action = await App.Current.MainPage.DisplayAlert("Alert", "Tu correo no está activado, ¿Desea enviar el código de activación de nuevo?", "Si", "No");

                                if (action == true)
                                {
                                    await authProvider.SendEmailVerificationAsync(content.FirebaseToken);
                                    await DisplayAlert("Mensaje", "Se envió un mensaje de verificación a su correo electrónico", "Ok");
                                }
                                else
                                {
                                    await DisplayAlert("Mensaje", "Se requiere verificar el Email para Iniciar Sesion", "Ok");
                                }

                            }
                            else
                            {
                                if (txtCorreo.Text == "yesmangunera3@gmail.com")
                                {
                                    await Navigation.PushAsync(new InicioRepartidor());
                                }
                                else if (txtCorreo.Text == "sarapavon1799@gmail.com")
                                {
                                    await Navigation.PushAsync(new InicioAdmin());
                                }
                                else
                                {
                                    await Navigation.PushAsync(new InicioUser());
                                }

                            }
                        }
                        catch(Exception e)
                        {
                             
                                UserDialogs.Instance.HideLoading();
                            await DisplayAlert("Alerta", "La constraseña es incorrecta", "OK");
                           // await DisplayAlert("Alerta", "La constraseña es incorrecta", "OK");
                        }
                       
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await DisplayAlert("Alerta", "El correo electrónico que ha ingresado no existe", "OK");
                    }

                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();

                    
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");

                }
            }
        }

        private async Task ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(txtCorreo.Text) ||
                String.IsNullOrWhiteSpace(txtPass.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "OK");
                UserDialogs.Instance.HideLoading();
            }
            
            if(txtPass.Text.Length < 6)
            {
                await this.DisplayAlert("Advertencia", "La contraseña debe ser mayor a 5 caracteres", "OK");
            }
        }

        private async void btnPass_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarPass());
        }

    }
}