using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class LooseLetter : LooseSign
    {
        public char Letter { get; set; }
        public LetterType LetterType { get; set; }
        public LooseLetter(int id, Dimension dimension, Material material, char letter, LetterType letterType, Color? color = null) : base(id, dimension, material, color)
        {
            Letter = letter;
            LetterType = letterType;
        }
    }
}
