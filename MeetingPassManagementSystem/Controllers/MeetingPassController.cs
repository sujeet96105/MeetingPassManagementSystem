using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetingPassManagementSystem.Models;
using MeetingPassManagementSystem.Services;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MeetingPassManagementSystem.Controllers
{
    public class MeetingPassController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MeetingPassController> _logger;

        public MeetingPassController(ApplicationDbContext context, ILogger<MeetingPassController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var database = _context.MeetingPasses.ToList();
            return View(database);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MeetingPass model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Automatically set CreatedDate to current date and time
                    model.CreatedDate = DateTime.Now;

                    _context.MeetingPasses.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating meeting pass");
                    ModelState.AddModelError("", $"There was an error creating the meeting pass: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("", "The form is not valid. Please check the input data.");
            }

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var meetingPass = _context.MeetingPasses.Find(id);
            if (meetingPass == null)
            {
                return NotFound();
            }
            return View(meetingPass);
        }

        [HttpPost]
        public IActionResult Edit(MeetingPass model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.MeetingPasses.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating meeting pass");
                    ModelState.AddModelError("", "There was an error updating the meeting pass. Please try again.");
                }
            }
            else
            {
                ModelState.AddModelError("", "The form is not valid. Please check the input data.");
            }

            return View(model);
        }

        // GET: MeetingPass/Delete/5
        public IActionResult Delete(int id)
        {
            var meetingPass = _context.MeetingPasses.Find(id);
            if (meetingPass == null)
            {
                return NotFound();
            }
            return View(meetingPass);
        }

        // POST: MeetingPass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var meetingPass = _context.MeetingPasses.Find(id);
            if (meetingPass == null)
            {
                return NotFound();
            }

            _context.MeetingPasses.Remove(meetingPass);
            _context.SaveChanges();

            // Reset the identity seed
            _context.Database.ExecuteSqlRaw("EXEC ResetIdentity");

            return RedirectToAction("Index");
        }


    }
}
