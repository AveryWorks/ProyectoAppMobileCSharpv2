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
    public partial class Forniture : ContentPage
    {
        public ObservableCollection<Producto> fornitureClass;

        public Forniture()
        {
            InitializeComponent();

            fornitureClass = new ObservableCollection<Producto>
            {
                new Producto{Name="Escritorio 2 niveles", Image="EscriDosNiv.jpg",Price="3500"},
                new Producto{Name="Escritorio forma L", Image="EscriFormL.jpg",Price="2500"},
                new Producto{Name="Escritorio gabetero", Image="EscriGab.jpg",Price="2500"},
            };
            FornitureCollectionView.ItemsSource = fornitureClass;
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