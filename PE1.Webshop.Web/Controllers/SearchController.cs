using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Enums;
using PE1.Webshop.Core.Interfaces;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.ViewModels;

namespace PE1.Webshop.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly EngravableRepository _engravableRepository;

        public SearchController()
        {
            _engravableRepository = new EngravableRepository();
        }
        public ViewResult Index()
        {
            ViewBag.Title = "Snelle zoekopties";
            return View();
        }

        public ViewResult GetItemsWithCertainMaterialAndPrice(Material material, decimal fromPrice)
        {
            IEngravableIndexViewModel engravableIndexViewModel = new IEngravableIndexViewModel();
            engravableIndexViewModel.IEngravables = new List<IEngravableBaseDetailViewModel>();
            foreach (IEngravable engravable in _engravableRepository.AllItemsOfCertainMaterial(material))
            {
                if(engravable.FromPrice >= fromPrice)
                {
                    AddCorrectDetailViewModelToEngravableIndexViewModel(engravableIndexViewModel, engravable);
                }   
            }
            ViewBag.Title = $"Resultaten van je zoekopdracht voor items in het {material} met een prijs vanaf {fromPrice} euro";
            return View(engravableIndexViewModel);
        }

        public ViewResult GetAvailableItemsWithACertainFromPrice(bool available, decimal fromPrice)
        {
            IEngravableIndexViewModel engravableIndexViewModel = new IEngravableIndexViewModel();
            engravableIndexViewModel.IEngravables = new List<IEngravableBaseDetailViewModel>();
            foreach (IEngravable engravable in _engravableRepository.AllItemsWithAPriceFrom(fromPrice))
            {
                if (engravable.ImmediateAvailable == true)
                {
                    AddCorrectDetailViewModelToEngravableIndexViewModel(engravableIndexViewModel, engravable);
                }
            }
            ViewBag.Title = $"Resultaten van je zoekopdracht voor items vanaf {fromPrice} euro die onmiddelijk beschikbaar zijn";
            return View(engravableIndexViewModel);
        }

        public ViewResult GetItemsWithACertainDimensionandFromPrice(Dimension dimension, decimal fromPrice)
        {
            IEngravableIndexViewModel engravableIndexViewModel = new IEngravableIndexViewModel();
            engravableIndexViewModel.IEngravables = new List<IEngravableBaseDetailViewModel>();
            foreach (IEngravable engravable in _engravableRepository.AllItemsWithAPriceFrom(fromPrice))
            {
                if (engravable.Dimension == dimension)
                {
                    AddCorrectDetailViewModelToEngravableIndexViewModel(engravableIndexViewModel, engravable);
                }
            }
            ViewBag.Title = $"Resultaten van je zoekopdracht voor items vanaf {fromPrice} euro die volgende grootte hebben:{dimension}";
            return View(engravableIndexViewModel);
        }

        private void AddCorrectDetailViewModelToEngravableIndexViewModel(IEngravableIndexViewModel engravableIndexViewModel, IEngravable engravable)
        {
            if (engravable.GetType() == typeof(LooseLetter) || engravable.GetType() == typeof(LooseNumber))
            {
                LooseSign newEngravable = (LooseSign)engravable;
                engravableIndexViewModel.IEngravables.Add(new LooseSignsDetailViewModel
                {
                    Id = engravable.Id,
                    Availibility = engravable.ImmediateAvailable,
                    FromPrice = engravable.FromPrice,
                    EngravingCategory = engravable.EngravingCategory,
                    Dimension = engravable.Dimension,
                    Type = DetermineType(engravable),
                    Material = newEngravable.Material
                });
            }
            else if (engravable.GetType() == typeof(NamePlate) || engravable.GetType() == typeof(HouseNumberPlate) || engravable.GetType() == typeof(PetLabel))
            {
                Plate newEngravable = (Plate)engravable;
                engravableIndexViewModel.IEngravables.Add(new PlatesDetailViewModel
                {
                    Id = engravable.Id,
                    Availibility = engravable.ImmediateAvailable,
                    FromPrice = engravable.FromPrice,
                    EngravingCategory = engravable.EngravingCategory,
                    Dimension = engravable.Dimension,
                    Type = DetermineType(engravable),
                    Material = newEngravable.Material
                });
            }
            else
            {
                PersonalizedObject newEngravable = (PersonalizedObject)engravable;
                engravableIndexViewModel.IEngravables.Add(new Tailor_MadeDetailViewModel
                {
                    Id = engravable.Id,
                    Availibility = engravable.ImmediateAvailable,
                    FromPrice = engravable.FromPrice,
                    EngravingCategory = engravable.EngravingCategory,
                    Dimension = engravable.Dimension,
                    Type = DetermineType(engravable),
                    GiftObject = newEngravable.GiftObject,
                });
            }
        }
        private string DetermineType(IEngravable engravable)
        {
            string type;
            if (engravable.GetType() == typeof(LooseLetter))
                type = "Losse Letter";
            else if (engravable.GetType() == typeof(LooseNumber))
                type = "Los Nummer";
            else if (engravable.GetType() == typeof(PetLabel))
                type = "Dierenlabel";
            else if (engravable.GetType() == typeof(NamePlate))
                type = "Naamplaat";
            else if (engravable.GetType() == typeof(HouseNumberPlate))
                type = "Huisnummers";
            else
                type = "Gepersonaliseerde voorwerpen";
            return type;
        }
    }
}
