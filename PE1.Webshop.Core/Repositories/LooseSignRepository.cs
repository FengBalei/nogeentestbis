using PE1.Webshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PE1.Webshop.Core.Enums;

namespace PE1.Webshop.Core.Repositories
{
    public class LooseSignRepository
    {
        public IEnumerable<LooseSign> GetLooseSigns()

        {
            List<LooseSign> looseSigns = new List<LooseSign>
            {
                new LooseLetter(1, Dimension.Large, Material.Plexi, 'A' , LetterType.AdLib),
                new LooseLetter(2, Dimension.Large, Material.Kunststof, 'A' , LetterType.Calibre),
                new LooseLetter(3, Dimension.Large, Material.Aluminium, 'A' , LetterType.Cambria),
                new LooseLetter(4, Dimension.Large, Material.Hout, 'A' , LetterType.ComingSoon),
                new LooseNumber(5, Dimension.Large, Material.Hout, 45),
                new LooseNumber(6, Dimension.Large, Material.Plexi, 45, Color.Aqua),
                new LooseNumber(7, Dimension.Large, Material.Aluminium, 45),
                new LooseNumber(8, Dimension.Large, Material.Kunststof, 45, Color.RebeccaPurple),
            };
            return looseSigns;
        }

        public List<LooseLetter> GetLooseLetters()
        {
            List<LooseLetter> filteredList = new List<LooseLetter>();
            foreach (LooseSign collectable in GetLooseSigns())
            {
                Type type = collectable.GetType();
                if (type == typeof(LooseLetter))
                    filteredList.Add((LooseLetter)collectable);
            }
            return filteredList;
        }

        public List<LooseNumber> GetLooseNumbers()
        {
            List<LooseNumber> filteredList = new List<LooseNumber>();
            foreach (LooseSign collectable in GetLooseSigns())
            {
                Type type = collectable.GetType();
                if (type == typeof(LooseNumber))
                    filteredList.Add((LooseNumber)collectable);
            }
            return filteredList;
        }
    }
}
