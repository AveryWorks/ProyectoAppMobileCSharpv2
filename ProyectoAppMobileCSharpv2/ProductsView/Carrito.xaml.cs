using ProyectoAppMobileCSharpv2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharpv2.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrito : ContentPage
    {
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/modulo1/Plantilla1";
        
        HttpClient cliente = new HttpClient();

        public ObservableCollection<Producto> cartClass;
        public Carrito()
        {
            
            InitializeComponent();
            cartClass = new ObservableCollection<Producto>();
            CarritoCollectionView.ItemsSource = cartClass;

        }

        public async Task LoadDataAsync()
        {
            try
            {
                var response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(content);
                    var jsonArray = jsonObject["items"].ToString();
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(jsonArray);

                    foreach (var product in products)
                    {
                        if (product.Type == "Computer")
                        {
                            cartClass.Add(product);
                        }

                    }
                }
                else
                {
                    await popUpPass("No se pudo obtener los datos");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task popUpPass(string Msg)
        {
            await DisplayAlert("Mensaje", Msg, "OK");
        }

        private void RemoveButtonClicked(object sender, EventArgs e)
        {

        }
    }
}