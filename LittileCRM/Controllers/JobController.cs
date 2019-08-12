using LittileCRM.Entities;
using LittileCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = LittileCRM.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LittileCRM.Controllers
{
    public class JobController : Controller
    {
        private LittleCRMContext _context;
        public JobController(LittleCRMContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Task()
        {
            var role = _context.User.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            var roleName = _context.Role.FirstOrDefault(r => r.Id == role.RoleId).Name;
            IQueryable<TaskModel> task;
            switch (roleName)
            {
                case "Manager":
                    task = _context.Task
                        .Select(t => new TaskModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            ComplexityId = t.ComplexityId,
                            ComplexityName = t.Complexity.Name,
                            Description = t.Description,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            DonePercent = t.DonePercent,
                            EmployeeId = t.EmplyeeId,
                            EmployeedName = t.Emplyee.LastName + t.Emplyee.Name
                        });
                    return View(task);
                    break;
                case "Emplyee":
                    task = _context.Task
                        .Where(t => t.Emplyee.Id == role.EmplyeeId)
                        .Select(t => new TaskModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            ComplexityId = t.ComplexityId,
                            ComplexityName = t.Complexity.Name,
                            Description = t.Description,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            DonePercent = t.DonePercent,
                            EmployeeId = t.EmplyeeId,
                            EmployeedName = t.Emplyee.LastName + t.Emplyee.Name
                        });
                    return View(task);
                    break;

            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Employee = _context.Emplyee
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            ViewBag.Complexity = _context.Complexity
                .Select(m => new SelectListItem
                {
                    Text =  m.Name,
                    Value = m.Id.ToString()
                });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTask(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                Task task = new Task
                {
                    Id = taskModel.Id,
                    Name = taskModel.Name,
                    ComplexityId = taskModel.ComplexityId,
                    Description = taskModel.Description,
                    StartDate = taskModel.StartDate,
                    EndDate = taskModel.EndDate,
                    DonePercent = taskModel.DonePercent,
                    EmplyeeId = taskModel.EmployeeId
                };
                _context.Task.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Task", "Job");
            }
            return View(taskModel);
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewBag.Employee = _context.Emplyee
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            ViewBag.Complexity = _context.Complexity
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            var task = _context.Task
                        .Where(t => t.Id ==id)
                        .Select(t => new TaskModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            ComplexityId = t.ComplexityId,
                            ComplexityName = t.Complexity.Name,
                            Description = t.Description,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            DonePercent = t.DonePercent,
                            EmployeeId = t.EmplyeeId,
                            EmployeedName = t.Emplyee.LastName + t.Emplyee.Name
                        }).FirstOrDefault();
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTask(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                Task task = new Task
                {
                    Id = taskModel.Id,
                    Name = taskModel.Name,
                    ComplexityId = taskModel.ComplexityId,
                    Description = taskModel.Description,
                    StartDate = taskModel.StartDate,
                    EndDate = taskModel.EndDate,
                    DonePercent = taskModel.DonePercent,
                    EmplyeeId = taskModel.EmployeeId
                };
                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Task", "Job");
            }
            return View(taskModel);
        }
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            ViewBag.Employee = _context.Emplyee
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            ViewBag.Complexity = _context.Complexity
                .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                });
            var task = _context.Task
                        .Where(t => t.Id == id)
                        .Select(t => new TaskModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            ComplexityId = t.ComplexityId,
                            ComplexityName = t.Complexity.Name,
                            Description = t.Description,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            DonePercent = t.DonePercent,
                            EmployeeId = t.EmplyeeId,
                            EmployeedName = t.Emplyee.LastName + t.Emplyee.Name
                        }).FirstOrDefault();
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                Task task = new Task
                {
                    Id = taskModel.Id,
                    Name = taskModel.Name,
                    ComplexityId = taskModel.ComplexityId,
                    Description = taskModel.Description,
                    StartDate = taskModel.StartDate,
                    EndDate = taskModel.EndDate,
                    DonePercent = taskModel.DonePercent,
                    EmplyeeId = taskModel.EmployeeId
                };
                _context.Entry(task).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("Task", "Job");
            }
            return View(taskModel);
        }
        public IActionResult ReportTask(List<int> task)
        {
            return resultTask(task);
        }
        public FileContentResult resultTask(List<int> task)
        {
            var stream = new MemoryStream();
            //PageSize.A4.Rotate() чтобы страница была альбомный
            var pdfDoc = new Document(PageSize.A4.Rotate());
            var pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            pdfWriter.SetLinearPageMode();

            //regionsFont использутся при написании основного текста
            var regionsFont = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, true, 10);
            var regionsFontBold = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, true, 10, Font.BOLD);
            //smallFont использутся при написании основного текста таблицы
            var smallFont = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, true, 8);
            var watermarkFont = FontFactory.GetFont(@"C:\Windows\Fonts\helvetica.ttf", BaseFont.IDENTITY_H, true, 40, Font.BOLD, new GrayColor(0.75f));

            PdfPTable table = new PdfPTable(7); 
            table.WidthPercentage = 100;
            PdfPCell cell;
            PdfPCell Watermark = new PdfPCell(new Phrase("Test", watermarkFont));
            Watermark.BorderWidth = 0;

            cell = new PdfPCell(new Phrase("Отчет по задачам", regionsFontBold));
            cell.Colspan = 7;
            cell.BorderWidth = 0;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" ", regionsFontBold));
            cell.Colspan = 7;
            cell.BorderWidth = 0;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase("Название задачи", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Описание задачи", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Сложность задачи", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Работник", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Начало", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Конец", regionsFont));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Сделано в %", regionsFont));
            table.AddCell(cell);

            var _task = _context.Task.Where(t => task.Contains(t.Id));

            foreach (var i in _task)
            {
                cell = new PdfPCell(new Phrase(i.Name, regionsFont));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(i.Description, regionsFont));
                table.AddCell(cell);

                var ComplexityName = _context.Complexity.FirstOrDefault(c => c.Id == i.ComplexityId).Name;
                cell = new PdfPCell(new Phrase(ComplexityName, regionsFont));
                table.AddCell(cell);

                var EmployeedName = _context.Emplyee.FirstOrDefault(e => e.Id == i.EmplyeeId).LastName + " " + _context.Emplyee.FirstOrDefault(e => e.Id == i.EmplyeeId).Name;
                cell = new PdfPCell(new Phrase(EmployeedName, regionsFont));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(i.StartDate.ToString(), regionsFont));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(i.EndDate.ToString(), regionsFont));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(i.DonePercent.ToString(), regionsFont));
                table.AddCell(cell);
            }

            pdfDoc.Add(table);
            pdfDoc.Close();
            return File(stream.GetBuffer(), "Application/pdf");
        }
    }
}
