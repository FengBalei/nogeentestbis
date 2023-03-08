using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;

namespace PE1.Webshop.Web.ViewModels
{
    public class IEngravableBaseDetailViewModel
    {
        public int Id { get; set; }
        public Dimension Dimension { get; set; }
        public EngravingCategory EngravingCategory { get; set; }
        public decimal FromPrice { get; set; }
        public decimal Price { get; set; }
        public bool Availibility { get; set; }

        public string Type { get; set; }
    }
}
