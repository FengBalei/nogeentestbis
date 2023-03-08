using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class PersonalEngraving : TailorMade
    {
        public string ObjectName { get; set; }
        public PersonalEngraving(int id, decimal hourlyPrice, string objectName) : base(id, hourlyPrice)
        {
            ObjectName = objectName;
        }

        public override decimal CalculatePrice()
        {
            decimal price;
            if (Description != null)
            {
                price = base.CalculatePrice();
            }
            else
            {
                price=base.CalculatePrice() + (base.CalculatePrice())*0.10M;
            }
            return price ;
        }
    }
}
