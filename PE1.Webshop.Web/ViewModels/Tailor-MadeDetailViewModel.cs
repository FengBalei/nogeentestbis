using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;

namespace PE1.Webshop.Web.ViewModels
{
    public class Tailor_MadeDetailViewModel: IEngravableBaseDetailViewModel
    {
        public string Description { get; set; }
        public Image Image { get; set; }
        public decimal HourlyPrice { get; set; }
        public GiftObject GiftObject { get; set; }
    }
}
