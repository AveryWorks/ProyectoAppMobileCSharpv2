using ProyectoAppMobileCSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        private string url = "https://g287196683f9c6a-i59czvwjkowzalch.adb.us-chicago-1.oraclecloudapps.com/ords/admin/metadata-catalog/";
        HttpClient cliente = new HttpClient();

        public IList<Usuario> CAT_USUARIOS { get; private set; }

        public Signup()
        {
            InitializeComponent();

            CAT_USUARIOS = new List<Usuario>();

            BindingContext = this;
        }

        public async Task popUpSignup()
        {
            await DisplayAlert("Sign Up", "Tu cuenta ha sido creada.", "OK");
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

        void btnSignup_Clicked(System.Object sender, System.EventArgs e)
        {
            popUpSignup();
            nombreSignup.Text = "";
            correoSignup.Text = "";
            passSignup.Text = "";
        }
        /*public async void AgregarenBD()
        {
            Usuario CA = new Usuario
            {
                NOMBRE_USUARIO = usuarioLogin.Text,
                CONTRASENA = passLogin.Text
            };

            var json = JsonConvert.SerializeObject(CA);
            //var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(url, contentJson);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //await DisplayAlert("Datos", "Se actualizó correctamente la info");
                //lblstatus.Text = "Se ingresó correctamente el registro";
            }
            else { popUpPass(); }
        }*/
    }
}