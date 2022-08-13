using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.ViewModel;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PPendientes : ContentPage
    {
        public PPendientes()
        {
            InitializeComponent();
            BindingContext = new VMPendiente(Navigation);
        }
    }
}