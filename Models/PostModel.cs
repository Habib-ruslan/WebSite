using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _1.Models
{
    public class PostModel
    {
        public int Id{get;set;}
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        public string Text { get; set; }

    }
}
