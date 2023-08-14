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
    public partial class Electronics : ContentPage
    {
        public ObservableCollection<Producto> electronicsClass;

        public Electronics()
        {
            InitializeComponent();

            electronicsClass = new ObservableCollection<Producto>
            {
                new Producto{Name="Parlante", Image="parlante.jpg",Price="2500",Type=Producto.Group.Electronics},
                new Producto{Name="Bateria Portatil", Image="powerbank.jpg",Price="2500",Type=Producto.Group.Electronics},
                new Producto{Name="Headset", Image="audifonos_headset.jpg",Price="2500",Type=Producto.Group.Electronics},
                new Producto{Name="Chromecast", Image="chromecast.jpg",Price="2500",Type=Producto.Group.Electronics},
                new Producto{Name="Proyector", Image="videobin.jpg",Price="2500",Type=Producto.Group.Electronics},
            };
            ElectronicCollectionView.ItemsSource = electronicsClass;
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