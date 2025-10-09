using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using ECommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> Companys = _unitOfWork.Company.GetAll().ToList();
            return View(Companys);
        }
        public IActionResult Upsert(int? id)
        {

            if (id != null && id != 0)
            {
                //Edit
                Company objCompany = _unitOfWork.Company.Get(u => u.Id == id);
                return View(objCompany);
            }
            else
            {

                return View(new Company());
            }


        }

        [HttpPost]
        public IActionResult Upsert(Company obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Company created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API calls

        public IActionResult GetAll()
        {
            List<Company> Companies = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = Companies });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyDeleted == null)
            {
                return Json(new { sucess = false, message = "Error in Deleting" });
            }
            _unitOfWork.Company.Remove(CompanyDeleted);
            _unitOfWork.Save();
            return Json(new { sucess = true, message = "Delete Successful" });
        }
        #endregion
    }
}
