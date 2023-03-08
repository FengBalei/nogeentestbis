using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class Image
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public Image(string name, string format)
        {
            Name = name;
            Format = format;
        }

    }
}
