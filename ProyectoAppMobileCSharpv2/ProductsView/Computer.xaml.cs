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
    public partial class Computer : ContentPage
    {
        public ObservableCollection<Producto> computerClass;

        public Computer()
        {
            InitializeComponent();

            computerClass = new ObservableCollection<Producto>
            {
                new Producto{Name="IDEAPAD 3 14IML05", Image="Laptop1.jpg",Price="2500",Type=Producto.Group.Computer},
                new Producto{Name="MODERN 15 B13M", Image="Laptop2.jpg",Price="2500",Type=Producto.Group.Computer},
                new Producto{Name="15-DY2033NR", Image="Laptop3.jpg",Price="2500",Type=Producto.Group.Computer},
                new Producto{Name="X515MA-BR423", Image="Laptop4.jpg",Price="2500",Type=Producto.Group.Computer},
                
            };
            ComputerCollectionView.ItemsSource = computerClass;
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