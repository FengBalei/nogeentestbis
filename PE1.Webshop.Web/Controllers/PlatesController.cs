using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class PlatesController : Controller
    {
        private readonly PlateRepository _plateRepository;
        public PlatesController()
        {
            _plateRepository = new PlateRepository();
        }
        public IActionResult Index()
        {
            PlateCategoriesIndexViewModel platesCategoriesIndex = new PlateCategoriesIndexViewModel();
            platesCategoriesIndex.PlateCategories = new List<PlateCategoriesDetailViewModel>();
            foreach(string type in _plateRepository.GetTypes())
            {         
                platesCategoriesIndex.PlateCategories.Add(
                    new PlateCategoriesDetailViewModel
                    {
                        TypeName = type,
                    });
            }
            return View(platesCategoriesIndex);
        }

        public ViewResult GetAllPlates()
        {
            PlatesIndexViewModel platesIndexViewModel = new PlatesIndexViewModel();
            platesIndexViewModel.Plates = new List<PlatesDetailViewModel>();
            foreach (Plate plate in _plateRepository.GetPlates())
            {
                platesIndexViewModel.Plates.Add(
                new PlatesDetailViewModel
                {
                    Id = plate.Id,
                    Dimension = plate.Dimension,
                    Material = plate.Material,
                    EngravingCategory = plate.EngravingCategory,
                    Font = plate.Font,
                    Type = DetermineType(plate)
                }
                ) ;
            }
            return View(platesIndexViewModel);
        }

        public ViewResult GetAllNamePlates()
        {
            PlatesIndexViewModel platesIndexViewModel = new PlatesIndexViewModel();
            platesIndexViewModel.Plates = new List<PlatesDetailViewModel>();
            foreach (Plate plate in _plateRepository.GetHouseNamePlate())
            {
                platesIndexViewModel.Plates.Add(
                new PlatesDetailViewModel
                {
                    Id = plate.Id,
                    Dimension = plate.Dimension,
                    Material = plate.Material,
                    EngravingCategory = plate.EngravingCategory,
                    Font = plate.Font,
                    Type = DetermineType(plate)
                }
                );
            }
            return View(platesIndexViewModel);
        }

        public ViewResult GetAllPetLabels()
        {
            PlatesIndexViewModel platesIndexViewModel = new PlatesIndexViewModel();
            platesIndexViewModel.Plates = new List<PlatesDetailViewModel>();
            foreach (Plate plate in _plateRepository.GetPetLabels())
            {
                platesIndexViewModel.Plates.Add(
                new PlatesDetailViewModel
                {
                    Id = plate.Id,
                    Dimension = plate.Dimension,
                    Material = plate.Material,
                    EngravingCategory = plate.EngravingCategory,
                    Font = plate.Font,
                    Type = DetermineType(plate)
                }
                );
            }
            return View(platesIndexViewModel);
        }

        public ViewResult GetAllHouseNumberPlates()
        {
            PlatesIndexViewModel platesIndexViewModel = new PlatesIndexViewModel();
            platesIndexViewModel.Plates = new List<PlatesDetailViewModel>();
            foreach (Plate plate in _plateRepository.GetHouseNumberPlate())
            {
                platesIndexViewModel.Plates.Add(
                new PlatesDetailViewModel
                {
                    Id = plate.Id,
                    Dimension = plate.Dimension,
                    Material = plate.Material,
                    EngravingCategory = plate.EngravingCategory,
                    Font = plate.Font,
                    Type = DetermineType(plate)
                }
                );
            }
            return View(platesIndexViewModel);
        }
        public IActionResult ShowPlateDetail(int id)
        {
            return SearchPlateDetailById(id);
        }

        public IActionResult PersonalizeAndOrder(int id)
        {
            ViewBag.Title = "In deze stap kan je je keuze personaliseren en bestellen.";
            return SearchPlateDetailById(id);
        }
        private IActionResult SearchPlateDetailById(int id)
        {
            Plate choosenPlate = _plateRepository.GetPlates().FirstOrDefault(l => l.Id == id);
            if (choosenPlate == null)
                return RedirectToAction("WrongId", "Home");
            else
            {
                PlatesDetailViewModel platesDetailViewModel = new PlatesDetailViewModel();
                platesDetailViewModel.Id = choosenPlate.Id;
                platesDetailViewModel.Dimension = choosenPlate.Dimension;
                platesDetailViewModel.Material = choosenPlate.Material;
                platesDetailViewModel.Font = choosenPlate.Font;
                platesDetailViewModel.EngravingCategory = choosenPlate.EngravingCategory;
                platesDetailViewModel.Type = DetermineType(choosenPlate);
                platesDetailViewModel.FromPrice = choosenPlate.FromPrice;
                ViewBag.ImageString = $"/images/{platesDetailViewModel.Type}-{platesDetailViewModel.Material}.jpg";
                return View(platesDetailViewModel);
            }
        }
        private string DetermineType(Plate plate)
        {
            string type;
            if (plate.GetType() == typeof(PetLabel))
            {
                type = "Dierenlabel";
            }
            else if (plate.GetType() == typeof(NamePlate))
            {
                type = "Naamplaat";
            }
            else
                type = "Huisnummers";
            return type;
        }
    }
}
