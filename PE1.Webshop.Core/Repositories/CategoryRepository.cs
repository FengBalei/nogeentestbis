using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Repositories
{
    public class CategoryRepository
    {
        public IEnumerable<EngravingCategory> GetEngravingCategories()
        {
            List<EngravingCategory> engravingCategories = new List<EngravingCategory>
                {

                   new EngravingCategory("Losse Tekens", "Losse tekens zijn uitgefreezde letters of nummers in een kleur, grootte en materiaal naar keuze. Je kan kiezen uit Aluminium, hout, Plexi of Kunststof."),
                   new EngravingCategory("Naam en nummerplaatjes", "Een gepersonaliseerd label voor aan je deur, boven je bel of aan je praktijk. Of geef je favoriete huisdier een identificatieplaatje zodat hij altijd zijn weg terugvindt."),
                   new EngravingCategory("Gepersonaliseerde gravures", "Je logo op een set gleazen, een ketting met de naam van je vriend(in), een sleutelhanger met een persoonlijke boodschap, het kan allemaal met onze gepersonaliseerde gravures")
                };
            return engravingCategories;
        }
    }
}