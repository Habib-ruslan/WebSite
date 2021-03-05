using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public PostModel PostModel { get; set; }

        public int PostModelId { get; set; }
    }
}
