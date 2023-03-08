using PE1.Webshop.Core.Enums;

namespace PE1.Webshop.Core.Entities
{
    public class Font
    {
        public int FontSize { get; set; }
        public FontWeight FontWeight { get; set; }
        public LetterType LetterType { get; set; }

        public Font(int fontSize, FontWeight fontWeight, LetterType letterType)
        {
            FontSize = fontSize;
            FontWeight = fontWeight;
            LetterType = letterType;    
        }
    }
}