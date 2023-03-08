using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Repositories
{
    public class TailorMadeRepository
    {
        public IEnumerable<TailorMade> GetTailorMades()

        {
            List<TailorMade> tailorMades = new List<TailorMade>
            {
                new PersonalEngraving(30, 30.34M, "Portefeuille"),
                new PersonalizedObject(31, 34.05M, GiftObject.Wijnglas),
                new PersonalizedObject(33, 34.05M, GiftObject.Champagneglas),
                new PersonalizedObject(35, 34.05M, GiftObject.Lepel),
                new PersonalizedObject(37, 34.05M, GiftObject.Aansteker),
                new PersonalizedObject(39, 34.05M, GiftObject.Sleutelhanger),
                new PersonalizedObject(41, 34.05M, GiftObject.Kettinghartje),
                new PersonalizedObject(43, 34.05M, GiftObject.Doos),
            };
            return tailorMades;
        }

        public List<PersonalizedObject> GetPersonalizedObjects()
        {
            List<PersonalizedObject> filteredList = new List<PersonalizedObject>();
            foreach (TailorMade collectable in GetTailorMades())
            {
                Type type = collectable.GetType();
                if (type == typeof(PersonalizedObject))
                    filteredList.Add((PersonalizedObject)collectable);
            }
            return filteredList;
        }

        public List<PersonalEngraving> GetPersonalEngravings()
        {
            List<PersonalEngraving> filteredList = new List<PersonalEngraving>();
            foreach (TailorMade collectable in GetTailorMades())
            {
                Type type = collectable.GetType();
                if (type == typeof(PersonalEngraving))
                    filteredList.Add((PersonalEngraving)collectable);
            }
            return filteredList;
        }



    }
}
