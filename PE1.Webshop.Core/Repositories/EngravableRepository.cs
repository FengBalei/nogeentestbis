using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using PE1.Webshop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Repositories
{
    public class EngravableRepository
    {
        private LooseSignRepository _signRepository;
        private PlateRepository _plateRepository;
        private TailorMadeRepository _tailorMadeRepository;
        public IEnumerable<IEngravable> Engravables { get; set; }
        public EngravableRepository()
        {
            _signRepository = new LooseSignRepository();
            _plateRepository = new PlateRepository();
            _tailorMadeRepository = new TailorMadeRepository();
            Engravables = AllEngravables();
        }

        public IEnumerable<IEngravable> AllEngravables()
        {
            List<IEngravable> allEngravables = new List<IEngravable>();
            foreach (IEngravable engravable in _signRepository.GetLooseSigns())
            {
                allEngravables.Add(engravable);
            }
            foreach(IEngravable engravable in _plateRepository.GetPlates())
            {
                allEngravables.Add(engravable);
            }
            foreach (IEngravable engravable in _tailorMadeRepository.GetTailorMades())
            {
                allEngravables.Add(engravable);
            }
            return allEngravables.AsEnumerable();
        }

        public IEnumerable<IEngravable> AllItemsOfCertainMaterial(Material material)
        {
            List<IEngravable> engravables = new List<IEngravable>();
            foreach (IEngravable engravable in _plateRepository.GetPlates())
            {
                Plate plate = engravable as Plate;
                if(plate.Material == material)
                    engravables.Add(plate);
            }
            foreach (IEngravable engravable in _signRepository.GetLooseSigns())
            {
                LooseSign looseSign = engravable as LooseSign;
                if (looseSign.Material == material)
                    engravables.Add(looseSign);
            }
            return engravables.AsEnumerable();
        }

        public IEnumerable<IEngravable>AllItemsWithAPriceFrom(decimal price)
        {
            List<IEngravable> fromPriceItems = new List<IEngravable>();
            foreach(IEngravable engravable in Engravables)
            {
                if (engravable.FromPrice >= price)
                    fromPriceItems.Add(engravable);
            }
            return fromPriceItems.AsEnumerable();
        }

        public IEnumerable<IEngravable>AllItemsWithCertainAvailability(bool availibilty)
        {
            List<IEngravable> availibilityItems = new List<IEngravable>();
            foreach (IEngravable engravable in Engravables)
            {
                if (engravable.ImmediateAvailable == availibilty)
                    availibilityItems.Add(engravable);
            }
            return availibilityItems.AsEnumerable();
        }

        public IEnumerable<EngravingCategory> GetEngravingCategories()
        {
            List<EngravingCategory> engravingCategories = new List<EngravingCategory>();
            foreach(IEngravable engravable in Engravables)
            {
                if(!engravingCategories.Contains(engravable.EngravingCategory))
                {
                    engravingCategories.Add(engravable.EngravingCategory);  
                };
            };
            return engravingCategories.AsEnumerable();  
        }
    }
}
