using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;


namespace ProyectoAppMobileCSharpv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaTiendas : ContentPage
    {
        public MapaTiendas()
        {
            InitializeComponent();

            btnMap1.Clicked += BtnMap1_Clicked;
            btnMap2.Clicked += BtnMap2_Clicked;
            btnMap3.Clicked += BtnMap3_Clicked;
        }

        private void BtnMap3_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryLatitude3.Text, out double lat)) { return; }
            if (!double.TryParse(EntryLongitud3.Text, out double lng)) { return; }
            Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }

        private void BtnMap2_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryLatitude2.Text, out double lat)) { return; }
            if (!double.TryParse(EntryLongitud2.Text, out double lng)) { return; }
            Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }

        private void BtnMap1_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(EntryLatitude1.Text, out double lat)) { return; }
            if (!double.TryParse(EntryLongitud1.Text, out double lng)) { return; }
            Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                NavigationMode = NavigationMode.None
            });
        }
    }
}