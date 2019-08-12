using LittileCRM.Entities;
using LittileCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittileCRM.Controllers
{
    public class ManagmentController : Controller
    {
        private LittleCRMContext _context;
        public ManagmentController(LittleCRMContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Employee()
        {
            var model = _context.Emplyee.Select(m => new EmployeeModel { Id = m.Id, LastName = m.LastName, Name = m.Name, PositionName = m.Position.Name });
            return View(model);
        }

        public IActionResult PositionsList()
        {
            var model = _context.Position.Select(m => new PositionModel { Name = m.Name });
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            ViewBag.Position = _context.Position.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Emplyee emplyee = new Emplyee { LastName = employeeModel.LastName, Name = employeeModel.Name, PositionId = employeeModel.PositionId };
                _context.Emplyee.Add(emplyee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employee", "Managment");
            }
            return View(employeeModel);
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            ViewBag.Position = _context.Position.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            var employee = _context.Emplyee.Where(e => e.Id == id)
                .Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    LastName = e.LastName,
                    Name = e.Name,
                    PositionId = e.PositionId
                }).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Emplyee emplyee = new Emplyee
                {
                    Id = employeeModel.Id,
                    LastName = employeeModel.LastName,
                    Name = employeeModel.Name,
                    PositionId = employeeModel.PositionId
                };
                _context.Emplyee.Add(emplyee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employee", "Managment");
            }
            return View(employeeModel);
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            ViewBag.Position = _context.Position.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            var employee = _context.Emplyee.Where(e => e.Id == id)
                .Select(e => new EmployeeModel
                {
                    Id = e.Id,
                    LastName = e.LastName,
                    Name = e.Name,
                    PositionId = e.PositionId,
                    PositionName = e.Position.Name
                }).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Emplyee emplyee = new Emplyee { Id = employeeModel.Id, LastName = employeeModel.LastName, Name = employeeModel.Name, PositionId = employeeModel.PositionId };
                _context.Emplyee.Remove(emplyee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Employee", "Managment");
            }
            return View(employeeModel);
        }
    }
}
