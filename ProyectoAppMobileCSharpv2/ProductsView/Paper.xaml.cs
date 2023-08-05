﻿using ProyectoAppMobileCSharpv2.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAppMobileCSharpv2.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Paper : ContentPage
    {
        public ObservableCollection<Producto> paperClass;

        public Paper()
        {
            InitializeComponent();

            
            paperClass = new ObservableCollection<Producto>
            {
                new Producto{Name="Reciclado", Image="reciclado.jpg",Type=Producto.Group.Paper},
                new Producto{Name="Satinado", Image="satinado.jpg",Type=Producto.Group.Paper},
                new Producto{Name="Universal", Image="imprimir.jpg",Type=Producto.Group.Paper}
            };
            PaperCollectionView.ItemsSource = paperClass;


        }

        public void AddButtonClicked(object sender, EventArgs e)
        {
            popUpPass("Presionaste el boton Anadir");
        }
        public async Task popUpPass(string Msg)
        {
            await DisplayAlert("mensaje", Msg, "OK");
        }
    }
}
