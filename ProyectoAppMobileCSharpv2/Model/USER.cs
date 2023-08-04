using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAppMobileCSharp.Model
{
    public class USER
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string keyword { get; set; }
    }

    public class ArrayProblem
    {
        public USER[] items { get; set; }
        public bool hasMore { get; set; }
        public bool limit { get; set; }
        public bool offset { get; set; }
        public bool count { get; set; }
        public links[] links { get; set; }
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
}
