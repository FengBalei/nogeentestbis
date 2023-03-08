using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core.Entities
{
    public class EngravingCategory
    {
        private static List<string> _categories;
        public string Name { get; set; }
        public string Description { get; set; }

        public EngravingCategory(string name, string description)
        {
            Name = name;
            Description = description;
            if(_categories == null)
                _categories = new List<string>();
            else
            {
               if(!_categories.Contains(name))
                    _categories.Add(name);
            }
            
        }

        public IEnumerable<string> GetCategories()
        {
            return _categories;
        }
        public override bool Equals(object obj)
        {
            return obj is EngravingCategory category &&
                   Name == category.Name &&
                   Description == category.Description;
        }
    }
}
