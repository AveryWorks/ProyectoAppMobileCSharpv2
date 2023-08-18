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
    public partial class Forniture : ContentPage
    {

        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo2/Plantilla1";

        HttpClient cliente = new HttpClient();

        public ObservableCollection<Producto> fornitureClass;

        public Forniture()
        {
            InitializeComponent();
            fornitureClass = new ObservableCollection<Producto>();
            LoadDataAsync();
            FornitureCollectionView.ItemsSource = fornitureClass;
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
                        if (product.Type == "Forniture")
                        {
                            fornitureClass.Add(product);
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

        public async void AddButtonClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.BindingContext is Producto product)
            {
                string message = $"ID: {product.ID}";
                await popUpPass(message);
            }
        }

        public async Task popUpPass(string Msg)
        {
            await DisplayAlert("Mensaje", Msg, "OK");
        }
    }
}