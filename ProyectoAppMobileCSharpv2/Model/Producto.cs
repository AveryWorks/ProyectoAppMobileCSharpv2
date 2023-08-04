using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAppMobileCSharpv2.Model
{
    public class Producto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        
        public Group Type { get; set; }

        public enum Group
        {
            Paper, Computer, Lamps
        }
    }
}
