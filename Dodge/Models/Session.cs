using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dodge.Models
{
    public static class Session
    {
        public static bool isSingin { get; set; }
        public static bool isAdmin { get; set; }
        public static string user { get; set; }        
    }
}
