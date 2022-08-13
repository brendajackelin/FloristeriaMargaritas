using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedido3 : ContentPage
    {
        public Pedido3()
        {
            InitializeComponent();
            refresh();
        }

        public async void refresh()
        {
            List<Models.productos> sit = await Proyecto.Controllers.ApiProducto.GetListProducts();
            list.ItemsSource = sit;
        }
    }
    
}