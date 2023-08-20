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
    public partial class Perfil : ContentPage
    {
        //String de la conección con el REST API de la base de datos en la nube
        private string url = "https://gd0f6d2a85d7ffa-proyectofinalc.adb.us-chicago-1.oraclecloudapps.com/ords/admin/modulo1/Plantilla1";
        //private string url = "https://g287196683f9c6a-i59czvwjkowzalch.adb.us-chicago-1.oraclecloudapps.com/ords/admin/usuarios";

        HttpClient cliente = new HttpClient();
        //public static string UsrSesion { get; set; }

        //La lista donde se guardan los usuarios recuperados de la base de datos
        public IList<USER> USERS { get; private set; }

        public Perfil()
        {
            InitializeComponent();
            //Se crea la lista donde de van a guardar los usuarios
            USERS = new List<USER>();
            //popUpPassID();
            fillUser();
        }

        private async void fillUser()
        {
            await recoverDB();

            USER MyUser = SearchUser(Login.UsrSesion);

            namePerfil.Text = MyUser.user_name;
            emailPerfil.Text = MyUser.email;
            passPerfil.Text = MyUser.keyword;
        }

        //metodo predeterminado, para no repetir código, que limpia la interfaz del login
        public void cleanInputs()
        {
            namePerfil.Text = "";
            emailPerfil.Text = "";
            passPerfil.Text = "";
            checkboxPerfil.IsChecked = false;
        }

        void checkboxPerfil_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (checkboxPerfil.IsChecked == true)
            {
                passPerfil.IsPassword = false;
            }
            else
            {
                passPerfil.IsPassword = true;
            }
        }

        public USER SearchUser(string ID)
        {
            //para revisar que los entries no estén vacios
            if (string.IsNullOrWhiteSpace(ID))
            {
                return null;
            }

            //para encontrar el email en la lista de USERS según el entry
            var user = USERS.FirstOrDefault(u => u.user_id == ID);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        //metodo que recupera los usuario de la base de datos y los guarda en la lista que se creó antes (USERS)
        public async Task recoverDB()
        {
            //clearUSERSList();
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
            }
        }

        //metodo que valida el usuario según los usuarios en la lista de USERS contra los entries de la persona
        public USER ValidateUser(string email)
        {
            // Check if the email is not provided
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            // Find a user with the provided email in the USERS list
            var user = USERS.FirstOrDefault(u => u.email == email);

            // Return the user if found, otherwise return null
            return user;
        }

        private async void actualizarBD(USER user)
        {
            var json = JsonConvert.SerializeObject(user);
            //var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync(url, contentJson);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //await DisplayAlert("Datos", "Se actualizó correctamente la info");
                // Call a method or provide a notification for successful update
                userUpdated();
            }
            else
            {
                popUpPass();
            }
        }

        /*private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            USER MyUser = SearchUser(ActualUSERS.ActualUSER);

            if (MyUser != null)
            {
                actualizarBD(MyUser);
                cleanInputs();
            }
            else
            {
                popUpPass();
                cleanInputs();
            }
        }*/

        public async void deleteBD(USER user)
        {
            var response = await cliente.DeleteAsync($"{url}/{user.user_id}");

            if (response.IsSuccessStatusCode)
            {
                userDeleted();
            }
            else
            {
                popUpPass();
            }
        }

        /*private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            USER MyUser = SearchUser(ActualUSERS.ActualUSER);

            if ( MyUser != null)
            {
                deleteBD(MyUser);
                cleanInputs();
                await Navigation.PushAsync(new Login());
            }
            else
            {
                popUpPass2();
                cleanInputs();
            }
        }*/

        private async Task popUpPass()
        {
            await DisplayAlert("Error", "Ocurrió un problema al realizar la acción. Inténtalo de nuevo.", "OK");
        }

        private async Task popUpPass2()
        {
            await DisplayAlert("Error", "El correo ingresado es incorrecto. Inténtalo de nuevo.", "OK");
        }

        private async Task userUpdated()
        {
            await DisplayAlert("Información correcta", "Usuario actualizado correctamente.", "OK");
        }

        private async Task userDeleted()
        {
            await DisplayAlert("Eliminar usuario", "Usuario eliminado exitosamente.", "OK");
        }

        private async Task popUpPassID()
        {
            await DisplayAlert("ID", "El ID es: " + Login.UsrSesion, "OK");
        }

    }
}