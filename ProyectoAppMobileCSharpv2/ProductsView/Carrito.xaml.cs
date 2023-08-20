using Newtonsoft.Json;
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
using static System.Net.WebRequestMethods;

namespace ProyectoAppMobileCSharpv2.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carrito : ContentPage
    {
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo3/Plantilla1";
        private string productUrl = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo2/Plantilla1";
        HttpClient cliente = new HttpClient();

        public ObservableCollection<Producto> SLClass;
        public IList<ShoppingList> ShpList { get; private set; }

        public Carrito()
        {
            InitializeComponent();
            ShpList = new List<ShoppingList>();
            SLClass = new ObservableCollection<Producto>();
            LoadDataAsync();
            CarritoCollectionView.ItemsSource = SLClass;
        }

        public string GetUser()
        {
            string UsrActual;
            return UsrActual = Login.UsrSesion;
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
                    var ShopLists = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingList>>(jsonArray);

                    foreach (var ShopList in ShopLists)
                    {
                        if (ShopList.splist_userid == GetUser())
                        {
                            await LoadProductsForShoppingList(ShopList.spprodid);
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

        public async Task LoadProductsForShoppingList(string spprodid)
        {
            try
            {
                var response = await cliente.GetAsync(productUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(content);
                    var jsonArray = jsonObject["items"].ToString();
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(jsonArray);
                    foreach (var product in products)
                    {
                        if (product.ID == spprodid)
                        {
                            SLClass.Add(product);
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
        public async void RemoveButtonClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.BindingContext is Producto product)
            {
                try
                {
                    string splist_userid = GetUser(); // Reemplaza con el valor real
                    string spprodid = product.ID; // Reemplaza con el valor real

                    // Construye la URL con los atributos conocidos como parámetros
                    string apiUrl = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo3/Plantilla1";
                    string urlWithParams = $"{apiUrl}?splist_userid={splist_userid}&spprodid={spprodid}";

                    // Realiza una solicitud GET a la API
                    HttpClient httpClient = new HttpClient();
                    var response = await httpClient.GetAsync(urlWithParams);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(content);

                        // Obtén el valor del atributo 'shoppinglistid'
                        string shoppid = jsonObject["items"]?.ToString();
                        var ShopLists = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingList>>(shoppid);

                        foreach (var ShopList in ShopLists)
                        {
                            if (ShopList.splist_userid == splist_userid && ShopList.spprodid == spprodid)
                            {

                                var shoppinglistid = ShopList.shoppinglistid;
                                await DisplayAlert("shoppinglistid Obtenido", shoppinglistid, "OK");

                                try
                                {
                                    // Construye la URL correcta para eliminar el producto de la API de productos
                                    string deleteUrl = $"{apiUrl}" +
                                        $"?shoppinglistid={shoppinglistid}&shoppinglist_userid={splist_userid}&spprodid={spprodid}";
                                    HttpResponseMessage response2 = await cliente.DeleteAsync(deleteUrl);
                                    if (response2.IsSuccessStatusCode)
                                    {
                                        SLClass.Remove(product);
                                    }
                                    else
                                    {
                                        popUpPass("No funca bro");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    await DisplayAlert("Error", ex.Message, "OK");
                                }

                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo obtener la respuesta de la API.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        public async Task popUpPass(string Msg)
        {
            await DisplayAlert("Mensaje", Msg, "OK");
        }
    }
}