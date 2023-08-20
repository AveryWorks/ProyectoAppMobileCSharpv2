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

namespace ProyectoAppMobileCSharpv2.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Computer : ContentPage
    {
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo2/Plantilla1";

        HttpClient cliente = new HttpClient();

        static Random rnd = new Random();

        public ObservableCollection<Producto> computerClass;

        public IList<ShoppingList> ShpList { get; private set; }

        public Computer()
        {
            InitializeComponent();
            ShpList = new List<ShoppingList>();
            computerClass = new ObservableCollection<Producto>();
            LoadDataAsync();
            ComputerCollectionView.ItemsSource = computerClass;
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
                    var products = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Producto>>(jsonArray);

                    foreach (var product in products)
                    {

                        if (product.Type == "Computer")
                        {

                            computerClass .Add(product);

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
                
                try
                {
                   
                    string addProdID = product.ID;
                    string addUser_ID = GetUser();
                    
                    //string message = $"ID: {addProdID} User_ID:{addUser_ID}";
                    //await popUpPass(message);

                    insertBD(addUser_ID, addProdID);

                }
                catch
                {

                    await popUpPass("No se pudo agregar a la tabla");

                }
            }
        }
       
        public async void insertBD(string addUser_ID, string addProdID)
        {
            int r = rnd.Next(1, 9999);

            try
            {
                // Crear una instancia de HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // La URL de la API RESTful de Oracle Cloud
                    string url2 = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/Modulo3/Plantilla1";

                    // Crear un objeto JSON con los datos a insertar
                    ShoppingList data = new ShoppingList
                    {
                        shoppinglistid = r+"",
                        splist_userid = addUser_ID +"",
                        spprodid = addProdID+""
                    };

                    // Serializar el objeto JSON a una cadena
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Crear un contenido JSON para la solicitud POST
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Realizar una solicitud POST a la URL
                    HttpResponseMessage response = await client.PostAsync(url2, content);

                    // Comprobar si la solicitud se realizó con éxito
                    if (response.IsSuccessStatusCode)
                    {
                        // El registro se insertó correctamente
                        popUpPass("Se agregó al carrito");
                    }
                    else
                    {
                        // Hubo un problema al insertar el registro
                        popUpPass("No se agregó al carrito");
                    }
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
    }
}