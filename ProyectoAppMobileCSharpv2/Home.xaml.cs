using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            
        }

        private void BtnPapel_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProductsView.Paper());
        }

        private void BtnOficina_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnMuebles_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnIlum_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnElec_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCompu_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}