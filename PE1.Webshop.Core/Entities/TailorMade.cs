using PE1.Webshop.Core.Enums;
using PE1.Webshop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public abstract class TailorMade : IEngravable
    {
        public int Id { get; }
        public string Description { get; private set; }
        public EngravingCategory EngravingCategory => new EngravingCategory("Gepersonaliseerde gravures", "Je logo op een set glazen, een ketting met de naam van je vriend(in), een sleutelhanger met een persoonlijke boodschap, het kan allemaal met onze gepersonaliseerde gravures.");
        public Image Image { get; private set; }
        public Dimension Dimension { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal FromPrice { get; protected set; }
        public bool ImmediateAvailable => false;
        public TailorMade(int id, decimal hourlyPrice)
        {
            Id = id;
            if(hourlyPrice == 0)
            HourlyPrice = 30M;
            HourlyPrice = hourlyPrice;
            FromPrice = 20M;
        }

        public virtual decimal CalculatePrice()
        {
            decimal price;
            price = HourlyPrice * ((int)Dimension);
            if(price < FromPrice)
                price = FromPrice;
            return price ;
        }

        public void AddImage(Image image)
        {
            Image = image;
        }

        public void AddDescription(string description)
        {
            Description = description;
        }

        public void ChangeDimension(Dimension dimension)
        {
            Dimension = dimension;
        }
    }
}
