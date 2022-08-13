using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto.Views;
using Proyecto.Controller;
using System.IO;

namespace Proyecto
{
    public partial class App : Application
    {
        static DataBase db;

        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Starbank.db3");
                    db = new DataBase(FolderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
          
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
