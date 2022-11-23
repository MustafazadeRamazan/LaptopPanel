using LaptopTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopTask.Controllers
{
    public class LaptopController : Controller
    {
        public static List<LaptopViewModel> Laptops { get; set; }


        static LaptopController()
        {
            Laptops = new List<LaptopViewModel>()
            {
                new LaptopViewModel() { Vendor = "Asus", Model = "Zenbook Pro Duo" },
                new LaptopViewModel() { Vendor = "Hp", Model = "ProBook 4540" },
                new LaptopViewModel() { Vendor = "Lenovo", Model = "Chromebook Duet 3" },
                new LaptopViewModel() { Vendor = "Dell", Model = "XPS 13" },
            };
        }


        public IActionResult Home() => View();

        public IActionResult Create() => View(new LaptopViewModel());

        public IActionResult Read() => View(Laptops);

        public IActionResult Update()
        {
            var items = new List<SelectListItem>();

            foreach (var item in Laptops)
            {
                var selectItem = new SelectListItem(item.ToString(), item.Id.ToString());

                items.Add(selectItem);
            }

            ViewBag.Laptops = items;

            return View();
        }

        public IActionResult Delete()
        {
            var items = new List<SelectListItem>();

            foreach (var item in Laptops)
            {
                var selectItem = new SelectListItem(item.ToString(), item.Id.ToString());

                items.Add(selectItem);
            }

            ViewBag.Laptops = items;

            return View();
        }



        [HttpPost]
        public IActionResult Create(LaptopViewModel laptopViewModel)
        {
            Laptops.Add(laptopViewModel);

            return RedirectToAction("Read");
        }

        [HttpPost]
        public IActionResult Update(LaptopViewModel laptopViewModel)
        {
            int index = Laptops.FindIndex(laptop => laptop.Id == laptopViewModel.Id);

            if (index == -1) return View();

            var laptop = Laptops.FirstOrDefault(laptop => laptop.Id == laptopViewModel.Id);

            if (laptopViewModel.Vendor is null) laptopViewModel.Vendor = laptop.Vendor;
            if (laptopViewModel.Model is null) laptopViewModel.Model = laptop.Model;

            Laptops.RemoveAt(index);
            Laptops.Insert(index, laptopViewModel);

            return RedirectToAction("Read");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var count = Laptops.RemoveAll(laptop => laptop.Id == int.Parse(id));

            return (count == 0) ? View() : RedirectToAction("Read");
        }
    }
}
