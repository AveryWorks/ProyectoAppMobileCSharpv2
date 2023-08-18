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
    public partial class Carrito : ContentPage
    {

        public ObservableCollection<Producto> cartClass;

        public Carrito()
        {
            
            InitializeComponent();
            cartClass = new ObservableCollection<Producto>();
            CarritoCollectionView.ItemsSource = cartClass;

        }

        private void RemoveButtonClicked(object sender, EventArgs e)
        {

        }
    }
}