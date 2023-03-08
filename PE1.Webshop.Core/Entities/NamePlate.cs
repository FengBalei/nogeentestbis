using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class NamePlate : Plate
    {
        public string Description { get; private set; }

        public NamePlate(int id, Dimension dimension, Material material) : base(id, dimension, material)
        {
            FromPrice = 15M;
        }
        public string AddDetailedDescription(string description)
        {
            Description += description;
            return description;
        }
    }
}
