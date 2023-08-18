using ProyectoAppMobileCSharpv2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharpv2.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lamp : ContentPage
    {
        public ObservableCollection<Producto> lampClass;

        public Lamp()
        {
            InitializeComponent();

            lampClass = new ObservableCollection<Producto>
            {
                new Producto{Name="Lampara Escritorio", Image="lampEsc.jpg",Price="2500"},
                new Producto{Name="Lampara Colgante", Image="lampCol.jpg",Price="2500"},
                new Producto{Name="Lampara Pared Cuadrada", Image="lampPar.jpg",Price="2500"},
                
            };
            LampCollectionView.ItemsSource = lampClass;
        }

        public void AddButtonClicked(object sender, EventArgs e)
        {
            popUpPass("Presionaste el boton Anadir");
        }
        public async Task popUpPass(string Msg)
        {
            await DisplayAlert("mensaje", Msg, "OK");
        }
    }
}