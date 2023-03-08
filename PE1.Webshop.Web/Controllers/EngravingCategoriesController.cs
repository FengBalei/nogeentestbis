using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class EngravingCategoriesController : Controller
    {
        private readonly EngravableRepository _engravableRepository;

        public EngravingCategoriesController()
        {
            _engravableRepository = new EngravableRepository();
        }
        public IActionResult Index()
        {
            EngravingCategoriesIndexViewModel engravingCategoryIndexViewModel = new EngravingCategoriesIndexViewModel();
            engravingCategoryIndexViewModel.EngravingCategories = new List<EngravingCategoriesDetailViewModel>();
            foreach (EngravingCategory category in _engravableRepository.GetEngravingCategories())
            {
                engravingCategoryIndexViewModel.EngravingCategories.Add(
                    new EngravingCategoriesDetailViewModel { Name = category.Name, Description = category.Description }
                    );
            };
            return View(engravingCategoryIndexViewModel);
        }
    }
}
