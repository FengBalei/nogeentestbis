using PE1.Webshop.Core.Enums;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class PetLabel : Plate
    {
        public string PetName { get; set; }
        public string OwnerId { get; set; }
        public PetLabel(int id, Dimension dimension, Material material) : base(id, dimension, material)
        {

        }
        public override decimal CalculatePrice()
        {
            decimal price = (PetName.Length + OwnerId.Length)*(int)Material;
            return price;
        }

        public void AddPetName(string name)
        {
            PetName = name;
        }

        public void AddOwnerId(string ownerId)
        {
            OwnerId = ownerId;  
        }
    }
}
