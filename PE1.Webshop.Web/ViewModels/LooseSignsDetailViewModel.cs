using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PE1.Webshop.Web.ViewModels
{
    public class LooseSignsDetailViewModel : IEngravableBaseDetailViewModel
    {
        public Material Material { get; set; }

        [Display(Name = "Kies kleur")]
        public Color? Color { get; set; }
    }
}
