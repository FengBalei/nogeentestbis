using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class LooseNumber : LooseSign
    {
        public int Number { get; set; }
        public LooseNumber(int id, Dimension dimension, Material material, int number, Color? color = null) : base(id, dimension, material, color)
        {
            Number = number;
        }
    }
}
