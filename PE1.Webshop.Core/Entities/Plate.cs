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
    public abstract class Plate : IEngravable
    {
        public int Id { get; }
        public Font Font { get; set; }
        public EngravingCategory EngravingCategory => new EngravingCategory("Naam en nummerplaatjes", "Een gepersonaliseerd label voor aan je deur, boven je bel of aan je praktijk. Of geef je favoriete huisdier een identificatieplaatje zodat hij altijd zijn weg terugvindt.");
        public Material Material { get; set; }
        public Dimension Dimension { get; set; }
        public bool ImmediateAvailable => true;
        public decimal FromPrice { get; protected set; }
        public Plate(int id, Dimension dimension, Material material)
        {
            Id = id;
            Dimension = dimension;
            Material = material;
            FromPrice = 5M;
        }
        public virtual decimal CalculatePrice()
        {
            decimal price;
            price = Convert.ToDecimal((int)Dimension * (int)Material);
            return price; ;
        }

        public void AddFont(Font font)
        {
            Font = font;
        }

        public void ChangeDimension(Dimension dimension)
        {
            Dimension = Dimension;
        }
    }
}
