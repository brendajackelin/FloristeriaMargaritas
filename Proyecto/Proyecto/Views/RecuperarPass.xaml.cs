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


namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarPass : ContentPage
    {
        public RecuperarPass()
        {
            InitializeComponent();
        }

        private async void btnPass_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new MainPage());

            string WebAPIkey = "AIzaSyAWGQVBeuz1m_zLJOqk5tw1kiK55SMckR8";

            if (String.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                await this.DisplayAlert("Advertencia", "Ingrese el correo electrónico", "OK");
            }
            else
            {
                try
                {
                    var usuario = await App.DBase.obtenerUsuario(3, txtCorreo.Text);

                    if (usuario != null)
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));

                        // Enviar correo de recuperación
                        await authProvider.SendPasswordResetEmailAsync(txtCorreo.Text);
                        await DisplayAlert("Mensaje", "Se envió un mensaje de recuperación a su correo electrónico", "Ok");

                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "El correo electrónico que ha ingresado no existe", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                }
            }
                
        }
    }
}