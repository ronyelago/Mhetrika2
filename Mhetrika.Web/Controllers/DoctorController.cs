using AutoMapper;
using mhetrika.core.Entities;
using mhetrika.Infrastructure.Repository;
using Mhetrika.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mhetrika.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository doctorRepository = new DoctorRepository();

        public ActionResult Index()
        {
            var doctors = doctorRepository.GetAll().ToList();
            var doctorList = Mapper.Map<List<DoctorListViewModel>>(doctors);

            return View(doctorList);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(DoctorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var doctor = Mapper.Map<Doctor>(viewModel);
                doctorRepository.Add(doctor);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var doc = doctorRepository.GetById(id);

            doctorRepository.Remove(doc);

            return RedirectToAction("Index");
        }
    }
}