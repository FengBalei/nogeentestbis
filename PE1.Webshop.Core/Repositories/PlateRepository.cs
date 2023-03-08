using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.AccessControl;

namespace PE1.Webshop.Core.Repositories
{
    public class PlateRepository
    {
        public IEnumerable<Plate> GetPlates()

        {
            List<Plate> plates = new List<Plate>
            {
                new NamePlate(9, Dimension.Small, Material.Hout),
                new NamePlate(10,Dimension.Large, Material.Aluminium),
                new NamePlate(11,Dimension.Medium, Material.Plexi),
                new NamePlate(12,Dimension.Medium, Material.Kunststof),
                new HouseNumberPlate(15,Dimension.Large, Material.Plexi),
                new HouseNumberPlate(16,Dimension.Large, Material.Hout),
                new HouseNumberPlate(17, Dimension.Medium, Material.Aluminium),
                new HouseNumberPlate(18, Dimension.Medium,  Material.Kunststof),
                new PetLabel(19, Dimension.Large, Material.Aluminium),
                new PetLabel(20, Dimension.Large, Material.Plexi),
                new PetLabel(21,Dimension.Medium, Material.Kunststof),

            };
            return plates;
        }

        public List<NamePlate> GetHouseNamePlate()
        {
            List<NamePlate> filteredList = new List<NamePlate>();
            foreach (Plate collectable in GetPlates())
            {
                Type type = collectable.GetType();
                if (type == typeof(NamePlate))
                    filteredList.Add((NamePlate)collectable);
            }
            return filteredList;
        }

        public List<HouseNumberPlate> GetHouseNumberPlate()
        {
            List<HouseNumberPlate> filteredList = new List<HouseNumberPlate>();
            foreach (Plate collectable in GetPlates())
            {
                Type type = collectable.GetType();
                if (type == typeof(HouseNumberPlate))
                    filteredList.Add((HouseNumberPlate)collectable);
            }
            return filteredList;
        }
        public List<PetLabel> GetPetLabels()
        {
            List<PetLabel> filteredList = new List<PetLabel>();
            foreach (Plate collectable in GetPlates())
            {
                Type type = collectable.GetType();
                if (type == typeof(PetLabel))
                    filteredList.Add((PetLabel)collectable);
            }
            return filteredList;
        }


        public List<string> GetTypes()
        {
            List<Type> filteredList = new List<Type>();
            foreach (Plate collectable in GetPlates())
            {
                Type newType = collectable.GetType();
                if (!filteredList.Contains(newType))
                    filteredList.Add(newType);
            }
            List<string> types = new List<string>();
            foreach (Type type in filteredList)
            {
                string typeName;
                if (type == typeof(PetLabel))
                    typeName = "Dierenlabel";
                else if (type == typeof(HouseNumberPlate))
                    typeName = "Naamplaat";
                else
                    typeName = "Huisnummer";
                types.Add(typeName);
            }
            return types;
        }

    }
}
