using CST356_Week_5_Lab.Data.Entities;
using CST356_Week_5_Lab.Models.View;
using CST356_Week_5_Lab.Repositories;
using CST356_Week_5_Lab.Services;
using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST356_Week_5_Lab.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService _dataService;
        private readonly ILog _log = LogManager.GetLogger(typeof(PetController));

        public PetController(IPetService service)
        {
            _dataService = service;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            _log.Debug("Getting list of pets for user: " + userId);

            return View(_dataService.GetPetsForUser(userId));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            _log.Info("Creating pet");

            if (!ModelState.IsValid)
                return View();

            try
            {
                petViewModel.UserId = User.Identity.GetUserId();
                _dataService.CreatePet(petViewModel);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to save pet.", ex);
                throw;
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var pet = _dataService.GetPet(id);

            if (pet == null)
                return RedirectToAction("List");

            if (!User.Identity.GetUserId().Equals(pet.UserId))
                return RedirectToAction("List");

            else
            {
                _dataService.DeletePet(id);

                return RedirectToAction("List");
            }
        }

        public ActionResult Details(int id)
        {
            var pet = _dataService.GetPet(id);

            if (!User.Identity.GetUserId().Equals(pet.UserId))
                return RedirectToAction("List");

            return View(pet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = _dataService.GetPet(id);

            if (!User.Identity.GetUserId().Equals(pet.UserId))
                return RedirectToAction("List");

            ViewBag.UserId = pet.UserId;

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _dataService.UpdatePet(petViewModel);

                return RedirectToAction("List");
            }

            return View();
        }
    }
}