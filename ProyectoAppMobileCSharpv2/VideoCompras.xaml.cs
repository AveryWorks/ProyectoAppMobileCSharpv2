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
    public partial class VideoCompras : ContentPage
    {
        public VideoCompras()
        {
            InitializeComponent();
            WView.Source = "https://www.youtube.com/watch?v=rYn8O0UaFxM&t=2s";
        }
    }
}