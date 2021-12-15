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
using HR.PresentationsModel.Dots.Governorate;

namespace ArmyTechTask.Controllers
{
    public class GovernoratesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public GovernoratesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: Governorates
        public ActionResult Index()
        {
            try
            {
                var obj = _unitOfWork.Governorate.GetAll();

                return View(AutoMapper.Mapper.Map<List<GovernorateDto>>(obj));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: Governorates/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var obj = await _unitOfWork.Governorate.GetAsync(id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<GovernorateDto>(obj));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: Governorates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NeighborhoodDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GovernorateForCreateDto governorateDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Governorate.AddAsync(AutoMapper.Mapper.Map<Governorate>(governorateDto));
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return View(governorateDto);
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

                var obj = await _unitOfWork.Governorate.GetAsync(id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<GovernorateForUpdateDto>(obj));
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
        public ActionResult Edit(GovernorateForUpdateDto GovernorateDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Governorate.update(AutoMapper.Mapper.Map<Governorate>(GovernorateDto));
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                return View(GovernorateDto);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: Governorates/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var emp_list = await _unitOfWork.Employee.GetAllAsync(x => x.BirthGovernorateId == id);

                if (emp_list.Count() > 0)
                {
                    return Json(new { success = false, message = "Failed, There is Employees Related with this Governorate" }, JsonRequestBehavior.AllowGet);

                }
                var obj = await _unitOfWork.Governorate.GetAsync(id);
                var nei_list = await _unitOfWork.Neighborhood.GetAllAsync(x => x.GovernorateId == id);
                await _unitOfWork.Neighborhood.RemoveRangeAsync(nei_list);
                await _unitOfWork.Governorate.RemoveAsync(id);
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
