using Microsoft.AspNetCore.Mvc;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.ViewModels;
using System.Reflection;

namespace PE1.Webshop.Web.Controllers
{
    public class LooseSignsController : Controller
    {
        private readonly LooseSignRepository _looseSignRepository;
        public LooseSignsController()
        {
            _looseSignRepository = new LooseSignRepository();
        }

        private string DetermineType(LooseSign looseSign)
        {
            string type;
            if (looseSign.GetType() == typeof(LooseNumber))
            {
                type = "Los Nummer";
            }
            else
                type = "Losse Letter";
            return type;
        }
        public ViewResult Index()
        {
            LooseSignsIndexViewModel looseSignsIndexViewModel = new LooseSignsIndexViewModel();
            looseSignsIndexViewModel.LooseSigns = new List<LooseSignsDetailViewModel>();
            foreach (LooseSign looseSign in _looseSignRepository.GetLooseSigns())
            {
                looseSignsIndexViewModel.LooseSigns.Add(
                new LooseSignsDetailViewModel
                {
                    Id = looseSign.Id,
                    Color = looseSign.Color,
                    Dimension = looseSign.Dimension,
                    Material = looseSign.Material,
                    EngravingCategory = looseSign.EngravingCategory,
                    Type = DetermineType(looseSign)
                }
                );
            }
            return View(looseSignsIndexViewModel);
        }

        public IActionResult ShowLooseSignDetail(int id)
        {
            return ReturnLooseSignWithId(id);
        }

        public IActionResult PersonalizeAndOrder(int id)
        {
            ViewBag.Title = "Bedankt voor je interesse. In deze stap kan je je keuze personaliseren en bestellen.";
            return ReturnLooseSignWithId(id);
        }

        private IActionResult ReturnLooseSignWithId(int id)
        {
            LooseSign choosenLooseSign = _looseSignRepository.GetLooseSigns().FirstOrDefault(l => l.Id == id);
            if (choosenLooseSign == null)
                return RedirectToAction("WrongId", "Home");
            else
            {
                LooseSignsDetailViewModel looseSignsDetailViewModel = new LooseSignsDetailViewModel();
                looseSignsDetailViewModel.Id = choosenLooseSign.Id;
                looseSignsDetailViewModel.Dimension = choosenLooseSign.Dimension;
                looseSignsDetailViewModel.Material = choosenLooseSign.Material;
                looseSignsDetailViewModel.EngravingCategory = choosenLooseSign.EngravingCategory;
                looseSignsDetailViewModel.Color = choosenLooseSign.Color;
                looseSignsDetailViewModel.FromPrice = choosenLooseSign.FromPrice;
                looseSignsDetailViewModel.Type = DetermineType(choosenLooseSign);
                return View(looseSignsDetailViewModel);
            }
        }
    }
}
