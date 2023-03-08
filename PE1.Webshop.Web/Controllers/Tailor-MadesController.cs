using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.ViewModels;
using PE1.Webshop.Core.Entities;

namespace PE1.Webshop.Web.Controllers
{
    public class Tailor_MadesController : Controller
    {
        private readonly TailorMadeRepository _tailorMadeRepository;
        public Tailor_MadesController()
        {
            _tailorMadeRepository = new TailorMadeRepository();
        }
        public ViewResult Index()
        {
            Tailor_MadeIndexViewModel tailorMadeIndexViewModel = new Tailor_MadeIndexViewModel();
            tailorMadeIndexViewModel.TailorMades = new List<Tailor_MadeDetailViewModel>();
            foreach(TailorMade tailorMade in _tailorMadeRepository.GetTailorMades())
            {
                tailorMadeIndexViewModel.TailorMades.Add(
                    new Tailor_MadeDetailViewModel
                    {
                        Id = tailorMade.Id,
                        Image = tailorMade.Image,
                        Description = tailorMade.Description,
                        EngravingCategory = tailorMade.EngravingCategory,
                        Dimension = tailorMade.Dimension,
                        HourlyPrice = tailorMade.HourlyPrice,
                    }
                    );
            }
            return View(tailorMadeIndexViewModel);
        }

        public ViewResult GetAllPersonalizedObjects()
        {
            Tailor_MadeIndexViewModel tailorMadeIndexViewModel = new Tailor_MadeIndexViewModel();
            tailorMadeIndexViewModel.TailorMades = new List<Tailor_MadeDetailViewModel>();
            foreach (PersonalizedObject tailorMade in _tailorMadeRepository.GetPersonalizedObjects())
            {
                    tailorMadeIndexViewModel.TailorMades.Add(
                    new Tailor_MadeDetailViewModel
                    {
                        Id = tailorMade.Id,
                        Image = tailorMade.Image,
                        Description = tailorMade.Description,
                        EngravingCategory = tailorMade.EngravingCategory,
                        Dimension = tailorMade.Dimension,
                        HourlyPrice = tailorMade.HourlyPrice,
                        GiftObject = tailorMade.GiftObject,
                        FromPrice = tailorMade.FromPrice,
                    }
                    );
            }
            return View(tailorMadeIndexViewModel);
        }

        public IActionResult ShowTailorMadeDetail(int id)
        {
            return SearchTailorMadeDetailById(id);
        }

        private IActionResult SearchTailorMadeDetailById(int id)
        {
            PersonalizedObject choosenTailorMade = _tailorMadeRepository.GetPersonalizedObjects().FirstOrDefault(l => l.Id == id);
            if (choosenTailorMade == null)
                return RedirectToAction("WrongId", "Home");
            else
            {
                Tailor_MadeDetailViewModel tailorMadeDetailViewModel = new Tailor_MadeDetailViewModel();
                tailorMadeDetailViewModel.Id = choosenTailorMade.Id;
                tailorMadeDetailViewModel.Dimension = choosenTailorMade.Dimension;
                tailorMadeDetailViewModel.EngravingCategory = choosenTailorMade.EngravingCategory;
                tailorMadeDetailViewModel.HourlyPrice = choosenTailorMade.HourlyPrice;
                tailorMadeDetailViewModel.GiftObject = choosenTailorMade.GiftObject;
                tailorMadeDetailViewModel.FromPrice = choosenTailorMade.FromPrice;
                tailorMadeDetailViewModel.Price = choosenTailorMade.CalculatePrice();
                return View(tailorMadeDetailViewModel);
            }
        }

        public IActionResult PersonalizeAndOrder(int id)
        {
            ViewBag.Title = "Bedankt voor je interesse. In deze stap kan je je keuze personaliseren en bestellen.";
            return SearchTailorMadeDetailById(id);
        }
    }   
}
