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
    public partial class Office : ContentPage
    {
        public ObservableCollection<Producto> officeClass;

        public Office()
        {
            InitializeComponent();

            officeClass = new ObservableCollection<Producto>
            {
                new Producto{Name="ECOTANK L1250 WIFI", Image="Impresora1.jpg",Price="2500",Type=Producto.Group.Office},
                new Producto{Name="TERMICA TM-M30II", Image="Impresora2.jpg",Price="2500",Type=Producto.Group.Office},
                new Producto{Name="Premium M10", Image="Trituradora.jpg",Price="2500",Type=Producto.Group.Office},
            };
            OfficeCollectionView.ItemsSource = officeClass;
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