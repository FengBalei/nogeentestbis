using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class HouseNumberPlate : Plate
    {
        public int HouseNumber { get; private set; }
        public string Box { get; private set; }
        public HouseNumberPlate(int id, Dimension dimension, Material material) : base(id, dimension, material)
        {
            FromPrice = 10M;
        }

        public void AddHouseNumber(int number)
        {
            HouseNumber = number;
        }

        public void AddBox(string box)
        {
            Box = box;
        }
    }
}
