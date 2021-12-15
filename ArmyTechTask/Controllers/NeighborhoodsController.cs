﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HR.DataAccess.IRepository;
using HR.DomainModels;
using HR.PresentationsModel.Dots.Neighborhood;

namespace ArmyTechTask.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public NeighborhoodsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: NeighborhoodDtoes
        public ActionResult Index()
        {
            var obj = _unitOfWork.Neighborhood.GetAll();

            return View(AutoMapper.Mapper.Map<List<NeighborhoodDto>>(obj));
        }

        // GET: NeighborhoodDtoes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = await _unitOfWork.Neighborhood.GetAsync(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<NeighborhoodDto>(obj));
        }

        // GET: NeighborhoodDtoes/Create
        public ActionResult Create()
        {
            ViewBag.GovernorateId = new SelectList(_unitOfWork.Governorate.GetAll(), "ID", "Name");

            return View();
        }

        // POST: NeighborhoodDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NeighborhoodForCreateDto neighborhoodDto)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Neighborhood.AddAsync(AutoMapper.Mapper.Map<Neighborhood>(neighborhoodDto)) ;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(neighborhoodDto);
        }

        // GET: NeighborhoodDtoes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.GovernorateId = new SelectList(_unitOfWork.Governorate.GetAll(), "ID", "Name");

            var obj = await _unitOfWork.Neighborhood.GetAsync(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<NeighborhoodForUpdateDto>(obj));
        }

        // POST: NeighborhoodDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NeighborhoodForUpdateDto neighborhoodDto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Neighborhood.update(AutoMapper.Mapper.Map<Neighborhood>(neighborhoodDto));
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(neighborhoodDto);
        }

       

        // POST: NeighborhoodDtoes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var obj = await _unitOfWork.Neighborhood.GetAsync(id);
           await _unitOfWork.Neighborhood.RemoveAsync(AutoMapper.Mapper.Map<Neighborhood>(obj));
            _unitOfWork.Save();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }


    }
}