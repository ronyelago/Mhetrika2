using AutoMapper;
using mhetrika.core.Entities;
using mhetrika.Infrastructure.Repository;
using Mhetrika.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mhetrika.Web.Controllers
{
    public class LaboratoryController : Controller
    {
        private readonly LaboratoryRepository laboratoryRepository = new LaboratoryRepository();
        private readonly AddressRepository addressRepository = new AddressRepository();

        // GET: Laboratory
        public ActionResult List()
        {
            var laboratories = laboratoryRepository.GetAll().ToList();
            var viewModel = Mapper.Map<List<LaboratoryListViewModel>>(laboratories);

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(NewLaboratoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var laboratory = Mapper.Map<Laboratory>(viewModel);
                laboratoryRepository.Add(laboratory);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lab = laboratoryRepository.GetById(id);
            laboratoryRepository.Remove(lab);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lab = laboratoryRepository.GetByIdWithAddress(id);
            var viewModel = Mapper.Map<EditLaboratoryViewModel>(lab);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditLaboratoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var lab = Mapper.Map<Laboratory>(viewModel);
                var address = Mapper.Map<Address>(viewModel.AddressViewModel);

                try
                {
                    laboratoryRepository.Update(lab);
                    addressRepository.Update(address);
                }
                catch (Exception ex)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("List");
            }

            else
            {
                return View();
            }
        }

        //private bool LaboratoryExists(int id)
        //{
        //    return _context.Laboratory.Any(e => e.Id == id);
        //}
    }
}