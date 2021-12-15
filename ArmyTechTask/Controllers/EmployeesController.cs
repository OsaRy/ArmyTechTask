using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HR.PresentationsModel;
using AutoMapper;
using HR.DataAccess.IRepository;
using HR.PresentationsModel.Dots.Employee;
using HR.DomainModels;

namespace HR.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

    
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var employees = await _unitOfWork.Employee.GetAllAsync(includeProperties: "CompanyJob,CareerField,Governorate,Neighborhood");

                //Mapping Using AutoMapper
                var emp = AutoMapper.Mapper.Map<List<EmployeeDto>>(employees).OrderBy(x => x.CompanyJob.JobArrangement);
                return View(emp);

            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message});
            }
        }
        [HttpGet]      
        [ChildActionOnly]
        public ActionResult Form()
        {
            try
            {
                ViewBag.CareerFieldId = new SelectList(_unitOfWork.CareerField.GetAll(), "ID", "Name");
                ViewBag.CompanyJobId = new SelectList(_unitOfWork.CompanyJob.GetAll(), "ID", "Name");
                ViewBag.BirthGovernorateId = new SelectList(_unitOfWork.Governorate.GetAll(), "ID", "Name");
                ViewBag.BirthNeighborhoodId = new SelectList(_unitOfWork.Neighborhood.GetAll(), "ID", "Name");
                ViewBag.Qualification = _unitOfWork.Qualification.GetAll();

                return PartialView();
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employee.GetAsync(id);
                var emp = AutoMapper.Mapper.Map<EmployeeForUpdateDto>(employee);
                emp.QualificationsSelected = employee.EmployeeQualifications.Select(x => x.QualificationId).ToArray();

                return Json(new { success = true, obj = emp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var QualForRemove = await _unitOfWork.EmployeeQualification.GetAllAsync(x => x.EmployeeId == id);

                await _unitOfWork.EmployeeQualification.RemoveRangeAsync(QualForRemove);
                await _unitOfWork.Employee.RemoveAsync(id);
                _unitOfWork.Save();


                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(EmployeeForCreateDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = AutoMapper.Mapper.Map<Employee>(employee);
                    _unitOfWork.Employee.AddAsync(obj);
                    _unitOfWork.Save();
                    List<EmployeeQualification> list = new List<EmployeeQualification>();
                    foreach (var item in employee.QualificationsSelected)
                    {
                        var qual = new EmployeeQualification();
                        qual.EmployeeId = obj.ID;
                        qual.QualificationId = item;
                        list.Add(qual);

                    }
                    _unitOfWork.EmployeeQualification.AddRange(list);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Employee Saved." }, JsonRequestBehavior.AllowGet);

                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }

        }
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeForUpdateDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = AutoMapper.Mapper.Map<Employee>(employee);
                    _unitOfWork.Employee.update(obj);
                    var QualForRemove = await _unitOfWork.EmployeeQualification.GetAllAsync(x => x.EmployeeId == obj.ID);

                    await _unitOfWork.EmployeeQualification.RemoveRangeAsync(QualForRemove);

                    List<EmployeeQualification> list = new List<EmployeeQualification>();
                    foreach (var item in employee.QualificationsSelected)
                    {
                        var qual = new EmployeeQualification();
                        qual.EmployeeId = obj.ID;
                        qual.QualificationId = item;
                        list.Add(qual);

                    }
                    await _unitOfWork.EmployeeQualification.AddRange(list);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Employee Saved." }, JsonRequestBehavior.AllowGet);

                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }


        }



        #region API CALLS
        [HttpGet]
        public async Task<ActionResult> GovChanged(int id)
        {
            try
            {
                _unitOfWork.ProxyCreationEnabled();
                var neighborhood = await _unitOfWork.Neighborhood.GetAllAsync(x => x.GovernorateId == id);

                return Json(neighborhood, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetEmpQuals(int id)
        {
            try
            {
                _unitOfWork.ProxyCreationEnabled();
                var neighborhood = await _unitOfWork.Qualification.GetAllAsync(x => x.EmployeeQualifications.Any(z => z.EmployeeId == id));

                return Json(neighborhood, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        #endregion
    }
}
