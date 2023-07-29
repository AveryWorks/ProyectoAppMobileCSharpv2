using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProyectoAppMobileCSharp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private string url = "https://g287196683f9c6a-i59czvwjkowzalch.adb.us-chicago-1.oraclecloudapps.com/ords/admin/metadata-catalog/";
        HttpClient cliente = new HttpClient();

        public IList<Usuario> CAT_USUARIOS { get; private set; }

        public Login()
        {
            InitializeComponent();

            CAT_USUARIOS = new List<Usuario>();

            BindingContext = this;
        }

        void checkboxLogin_CheckedChanged(Object sender, CheckedChangedEventArgs e)
        {
            if (checkboxLogin.IsChecked == true)
            {
                passLogin.IsPassword = false;
            }
            else
            {
                passLogin.IsPassword = true;
            }
        }

        void btnSignup_Clicked(Object sender,EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Signup());
        }
        void btnLogin_Clicked(System.Object sender, EventArgs e)
        {
            if (usuarioLogin.Text != null)

            {
                ConsultarDatosDirecto();
                ((NavigationPage)this.Parent).PushAsync(new Home());
                usuarioLogin.Text = "";
                passLogin.Text = "";
                checkboxLogin.IsChecked = false;
            }

            else
            {
                popUpPass();
            }
        }

        public async Task popUpPass()
        {
            await DisplayAlert("Información incorrecta", "El correo o contraseña ingresados son incorrectos. Inténtalo de nuevo.", "OK");
        }

        public async Task<bool> ConsultarDatosDirecto()
        {

            string usuarioLoginx = "";

            string passLoginx = "";

            string DData = usuarioLogin.Text;

            string[] stringArray = new string[3];

            string contenido = await cliente.GetStringAsync(url + "/" + DData);


            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ArrayProblem>(contenido);


            if (data == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}