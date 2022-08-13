using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.Models;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoDetalle : ContentPage
    {
        public Productos oGlobalProducto;
        public PedidoDetalle(Productos oProducto)
        {
            InitializeComponent();
            oGlobalProducto = oProducto;

            //ImagenProducto.Source = oProducto.imagenProducto;
            txtNombre.Text = oProducto.productName;
            txtDescripcion.Text = oProducto.descripcion;
            txtPrecio.Text = string.Format("L. {0}", oProducto.precio.ToString());
        }
    }
}