using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        private readonly Geocoder _geocoder = new Geocoder();

        public MapPage()
        {
            InitializeComponent();
        }

        async void Map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            await DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude}, Long: {e.Position.Longitude}", "OK");

            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);

            await DisplayAlert("Address", addresses.FirstOrDefault()?.ToString(), "OK");

            var positions = await _geocoder.GetPositionsForAddressAsync("Broadway, New York");

            await DisplayAlert("Position", $"Lat: {positions.First().Latitude}, Long: {positions.First().Longitude}", "OK");

            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromKilometers(1)));
        }
    }
}