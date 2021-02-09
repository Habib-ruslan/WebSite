using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _1.Models
{
    public class PostModel
    {
        public int Id{get;set;}
        public string Name { get; set; }
        public string Text { get; set; }

    }
}
