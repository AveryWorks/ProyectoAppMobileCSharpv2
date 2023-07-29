using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharp
{
    public partial class App : Application
    {
        public static NavigationPage Navigation { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = Navigation = new NavigationPage(new Home());
            

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
