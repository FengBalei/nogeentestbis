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
    public abstract class LooseSign : IEngravable
    {
        public int Id { get; }
        public Dimension Dimension { get; set; }
        public EngravingCategory EngravingCategory => new EngravingCategory ("Losse Tekens", "Losse tekens zijn uitgefreezde letters of nummers in een kleur, grootte en materiaal naar keuze. Je kan kiezen uit Aluminium, hout, Plexi of Kunststof.");
        public Material Material { get; set; }
        public Color? Color { get; set; }
        public decimal FromPrice { get; }
        public bool ImmediateAvailable => true;
        protected LooseSign(int id, Dimension dimension, Material material, Color? color = null)
        {
            Id = id;
            Dimension = dimension;
            Material = material;
            Color = color;
            FromPrice = 5M;
        }

        public virtual decimal CalculatePrice()
        {
            decimal price;
            price = Convert.ToDecimal((int)Dimension * (int)Material);
            if (price == 0)
                price = FromPrice;
            return price;
        }

        public void ChangeDimension(Dimension dimension)
        {
            Dimension = dimension;
        }
    }
}
