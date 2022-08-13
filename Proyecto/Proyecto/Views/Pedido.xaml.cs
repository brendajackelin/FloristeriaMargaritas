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
    public partial class Pedido : ContentPage
    {
        public List<Productos> oListaProductos;
        public Pedido()
        {
            InitializeComponent();
            ObtenerProductos();
            BindingContext = new VMPedido(Navigation);
        }

        private async void ObtenerProductos()
        {
            Dictionary<string, Productos> oObjeto = new Dictionary<string, Productos>();
            //oObjeto = await Controllers.ApiProducto.GetAllProductos();

            List<Productos> oListaTemp = new List<Productos>();

            if (oObjeto.Count > 0)
            {
                foreach (KeyValuePair<string, Productos> item in oObjeto)
                {
                    oListaTemp.Add(new Productos()
                    {
                        idProducto = item.Key,
                        descripcion = item.Value.descripcion,
                        productName = item.Value.productName,
                        //imagenProducto = item.Value.imagenProducto,
                        precio = item.Value.precio
                    });
                }
                oListaProductos = oListaTemp;
            }

            cvListaProductos.ItemsSource = oListaProductos;
        }

        private async void CvListaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Productos oProducto = (Productos)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new PedidoDetalle(oProducto));
            //((CollectionView)sender).SelectedItem = null;
        }
    }
}