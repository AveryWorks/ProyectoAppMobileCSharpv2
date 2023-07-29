using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAppMobileCSharp.Model
{
    public class Usuario
    {
        public string NOMBRE_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
    }

    public class links
    {
        public string rel { get; set; }
        public string href { get; set; }

        public override string ToString()
        {
            return href;
        }
    }

    public class ArrayProblem
    {
        public Usuario[] items { get; set; }
        public bool hasMore { get; set; }
        public bool limit { get; set; }
        public bool offset { get; set; }
        public bool count { get; set; }
        public links[] links { get; set; }
    }
}
