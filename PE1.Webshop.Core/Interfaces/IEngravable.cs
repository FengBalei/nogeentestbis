using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;

namespace PE1.Webshop.Core.Interfaces
{
    public interface IEngravable
    {
        public int Id { get; }
        public Dimension Dimension { get; set; }
        public decimal FromPrice { get; }
        public decimal CalculatePrice();
        public EngravingCategory EngravingCategory { get;}
        public bool ImmediateAvailable { get; }
    }
}
