using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoAppMobileCSharpv2;

namespace ProyectoAppMobileCSharpv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            btnCompu.Clicked += BtnCompu_Clicked;
            btnElec.Clicked += BtnElec_Clicked;
            btnIlum.Clicked += BtnIlum_Clicked;
            btnMuebles.Clicked += BtnMuebles_Clicked;
            btnOficina.Clicked += BtnOficina_Clicked;
            btnPapel.Clicked += BtnPapel_Clicked;

            Carrito.Clicked += Carrito_Clicked;
            Perfil.Clicked += Perfil_Clicked;
            //Logout.Clicked += Logout_Clicked;
            Ayuda.Clicked += Ayuda_Clicked;
            btnMapa.Clicked += BtnMapa_Clicked;
            btnVideo.Clicked += BtnVideo_Clicked;

        }
        private void BtnVideo_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new VideoCompras());
        }

        private void BtnMapa_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MapaTiendas());
        }
        private void Ayuda_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Ayuda());
        }

        private void Perfil_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Perfil());
        }

        //private void Logout_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("En desarrollo","Logout no está programado aún","ok");
        //}

        private void Carrito_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Carrito());
        }

        private void BtnPapel_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Paper());
        }

        private void BtnOficina_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Office());
        }

        private void BtnMuebles_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Forniture());
        }

        private void BtnIlum_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Lamp());
        }

        private void BtnElec_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Electronics());
        }

        private void BtnCompu_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Computer());
        }
    }
}