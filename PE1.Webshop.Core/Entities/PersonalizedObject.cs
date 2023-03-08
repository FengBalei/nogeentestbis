using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class PersonalizedObject : TailorMade
    {
        public GiftObject GiftObject { get; set; }
        public PersonalizedObject(int id, decimal hourlyPrice, GiftObject giftObject) : base(id, hourlyPrice)
        {
            GiftObject = giftObject;
            FromPrice = 7.99M;
        }

        public override decimal CalculatePrice()
        {
            decimal price;
            switch (GiftObject)
            {
                case GiftObject.Wijnglas:
                    price = 10.99M;
                    break;
                case GiftObject.Champagneglas:
                    price = 15.99M;
                    break;
                case GiftObject.Aansteker:
                    price = 20.99M;
                    break;
                case GiftObject.Lepel:
                    price = 7.99M;
                    break;
                case GiftObject.Doos:
                    price = 25.99M;
                    break;
                case GiftObject.Sleutelhanger:
                    price = 12.99M;
                    break;
                case GiftObject.Kettinghartje:
                    price = 13.99M;
                    break;
                default:
                    price = 0M;
                    break;
            }
            return price;
        }


    }
}
