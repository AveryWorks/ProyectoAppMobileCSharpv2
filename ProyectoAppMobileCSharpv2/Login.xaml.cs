using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProyectoAppMobileCSharpv2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ProyectoAppMobileCSharpv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //String de la conección con el REST API de la base de datos en la nube
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/modulo1/Plantilla1";
        //private string url = "https://g287196683f9c6a-i59czvwjkowzalch.adb.us-chicago-1.oraclecloudapps.com/ords/admin/usuarios";

        HttpClient cliente = new HttpClient();

        //La lista donde se guardan los usuarios recuperados de la base de datos
        public IList<USER> USERS { get; private set; }

        public Login()
        {
            InitializeComponent();

            //Se crea la lista donde de van a guardar los usuarios
            USERS = new List<USER>();
            recoverDB();

            BindingContext = this;

        }

        //metodo predeterminado, para no repetir código, que limpia la interfaz del login
        public void cleanInputs()
        {
            emailLogin.Text = "";
            passLogin.Text = "";
            checkboxLogin.IsChecked = false;
        }

        //metodo predeterminado que limpia la lista de los usuarios
        public void clearUSERSList()
        {
            USERS.Clear();
        }


        //metodo que permite que se muestre o no la contraseña en el entry
        void checkboxLogin_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
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

        //metodo que recupera los usuario de la base de datos y los guarda en la lista que se creó antes (USERS)
        public async void recoverDB()
        {
            string user_idx = "";
            string user_namex = "";
            string emailx = "";
            string keywordx = "";

            string[] stringArray = new string[3];

            string contenido = await cliente.GetStringAsync(url);

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ArrayProblem>(contenido);

            foreach (var item in data.items)
            {
                user_idx = string.Format("{0}", item.user_id.ToString());
                user_namex = string.Format("{0}", item.user_name.ToString());
                emailx = string.Format("{0}", item.email.ToString());
                keywordx = string.Format("{0}", item.keyword.ToString());

                USERS.Add(new USER
                {
                    user_id = user_idx,
                    user_name = user_namex,
                    email = emailx,
                    keyword = keywordx
                });

                //este label de test era para ver si la lista de USER tenía algo
                //test.Text = USERS[0].user_name;
            }
        }

        //metodo que valida el usuario según los usuarios en la lista de USERS contra los entries de la persona
        public bool ValidateUser(string email, string password)
        {
            //se llama al método de recoverDB para agregarlos a la lista de los USERS y poder realizar la validadción
            clearUSERSList();
            recoverDB();

            //para revisar que los entries no estén vacios
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            //para encontrar el email en la lista de USERS según el entry
            var user = USERS.FirstOrDefault(u => u.email == email);

            if (user == null)
            {
                return false;
            }

            //para comparar también la contraseña
            if (user.keyword == password)
            {
                return true;
                
            }

            return false;
        }

        //metodo para cuando se va a realizar el login
        private void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            //clearUSERSList();
            //recoverDB();

            string email = emailLogin.Text;
            string password = passLogin.Text;

            if (ValidateUser(email, password))
            {
                //si se logró validar el usuario
                ((NavigationPage)this.Parent).PushAsync(new Home());
                cleanInputs();
            }
            else
            {
                //si no existe, se le muestra un mensaje de error
                popUpPass();
                cleanInputs();
            }
        }


        //si la persona no tiene un usuario, puede entrar aquí para crear uno
        //metodo que abre la ventana del signup
        void btnSignup_Clicked(System.Object sender, System.EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Signup());
        }

        //metodo que genera el mensaje de error
        public async Task popUpPass()
        {
            await DisplayAlert("Información incorrecta", "El correo o contraseña ingresados son incorrectos. Inténtalo de nuevo.", "OK");
        }
    }
}