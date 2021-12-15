using System;
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
            try
            {
                var obj = _unitOfWork.Neighborhood.GetAll();

                return View(AutoMapper.Mapper.Map<List<NeighborhoodDto>>(obj));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: NeighborhoodDtoes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
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
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: NeighborhoodDtoes/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.GovernorateId = new SelectList(_unitOfWork.Governorate.GetAll(), "ID", "Name");

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // POST: NeighborhoodDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NeighborhoodForCreateDto neighborhoodDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Neighborhood.AddAsync(AutoMapper.Mapper.Map<Neighborhood>(neighborhoodDto));
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return View(neighborhoodDto);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: NeighborhoodDtoes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ViewBag.GovernorateId = new SelectList(_unitOfWork.Governorate.GetAll(), "ID", "Name");

                var obj = await _unitOfWork.Neighborhood.GetAsync(id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<NeighborhoodForUpdateDto>(obj));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // POST: NeighborhoodDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NeighborhoodForUpdateDto neighborhoodDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Neighborhood.update(AutoMapper.Mapper.Map<Neighborhood>(neighborhoodDto));
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                return View(neighborhoodDto);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

       

        // POST: NeighborhoodDtoes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var obj = await _unitOfWork.Neighborhood.GetAsync(id);
                await _unitOfWork.Neighborhood.RemoveAsync(id);
                _unitOfWork.Save();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


    }
}
