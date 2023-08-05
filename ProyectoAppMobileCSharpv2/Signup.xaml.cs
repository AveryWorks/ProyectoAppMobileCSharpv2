using Newtonsoft.Json;
using ProyectoAppMobileCSharpv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharpv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        //String de la conección con el REST API de la base de datos en la nube
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/modulo1/Plantilla1";
        //private string url = "https://g287196683f9c6a-i59czvwjkowzalch.adb.us-chicago-1.oraclecloudapps.com/ords/admin/usuarios";

        HttpClient cliente = new HttpClient();

        //La lista donde se guardan los usuarios recuperados de la base de datos
        public IList<USER> USERS { get; private set; }

        //para crear el id del usuario de forma random
        static Random rnd = new Random();

        public Signup()
        {
            InitializeComponent();

            //Se crea la lista donde de van a guardar los usuarios
            USERS = new List<USER>();

        }

        //metodo predeterminado, para no repetir código, que limpia la interfaz del login
        public void cleanInputs()
        {
            nameSignup.Text = "";
            emailSignup.Text = "";
            passSignup.Text = "";
            checkboxSignup.IsChecked = false;
        }

        void checkboxSignup_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (checkboxSignup.IsChecked == true)
            {
                passSignup.IsPassword = false;
            }
            else
            {
                passSignup.IsPassword = true;
            }
        }

        public async void insertBD()
        {
            int r = rnd.Next(1000, 9999);

            USER user = new USER
            {
                user_id = r.ToString(),
                user_name = nameSignup.Text,
                email = emailSignup.Text,
                keyword = passSignup.Text
            };

            var json = JsonConvert.SerializeObject(user);

            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(url, contentJson);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //await DisplayAlert("Datos", "Se actualizó correctamente la info");
                userCreated();
            }
            else
            {
                popUpPass();
            }
        }

        private void btnSignup_Clicked(System.Object sender, System.EventArgs e)
        {
            if (nameSignup.Text != "" && emailSignup.Text != "" && passSignup.Text != "")
            {
                //si se logró validar el usuario
                insertBD();
                cleanInputs();
            }
            else
            {
                //si no existe, se le muestra un mensaje de error
                popUpPass();
                cleanInputs();
            }
        }

        //metodo que genera el mensaje de error
        public async Task popUpPass()
        {
            await DisplayAlert("Información incorrecta", "El correo, nombre o contraseña ingresados son incorrectos. Inténtalo de nuevo.", "OK");
        }

        public async Task userCreated()
        {
            await DisplayAlert("Información correcta", "Usuario creado correctamente. Vuelve a la página inicial de Login para entrar a la aplicación.", "OK");
        }
    }
}