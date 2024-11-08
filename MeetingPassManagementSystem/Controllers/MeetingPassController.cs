using Microsoft.AspNetCore.Mvc;
using MeetingPassManagementSystem.Models;
using MeetingPassManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;




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
            var meetingPasses = _context.MeetingPass.ToList();
            TempData["MeetingPassData"] = JsonConvert.SerializeObject(meetingPasses);
            return View(meetingPasses);
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

                    _context.MeetingPass.Add(model);
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
            try
            {
                var meetingPass = _context.MeetingPass.Find(id);
                if (meetingPass == null)
                {
                    _logger.LogWarning("Meeting pass with ID {id} not found", id);
                    return NotFound($"Meeting pass with ID {id} not found.");
                }

                _logger.LogInformation("Retrieved meeting pass: {@MeetingPass}", meetingPass); // Log the meeting pass details

                return View(meetingPass);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving meeting pass with ID {id}", id);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }


        [HttpPost]
        public IActionResult Edit(MeetingPass model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.MeetingPass.Attach(model);
                    _context.Entry(model).State = EntityState.Modified;
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
            var meetingPass = _context.MeetingPass.Find(id);
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
            var meetingPass = _context.MeetingPass.Find(id);
            if (meetingPass == null)
            {
                return NotFound();
            }

            _context.MeetingPass.Remove(meetingPass);
            _context.SaveChanges();

            // Reset the identity seed
           // _context.Database.ExecuteSqlRaw("EXEC ResetIdentity");

            return RedirectToAction("Index");
        }

        public JsonResult GetData(DateTime? startDate, DateTime? endDate)
        {
            // Start with the base query
            var query = _context.MeetingPass.AsQueryable();

            // Apply the date filters if provided, ensuring both start and end dates are inclusive
            if (startDate.HasValue)
            {
                query = query.Where(mp => mp.CreatedDate.HasValue && mp.CreatedDate.Value.Date >= startDate.Value.Date);
            }
            if (endDate.HasValue)
            {
                query = query.Where(mp => mp.CreatedDate.HasValue && mp.CreatedDate.Value.Date <= endDate.Value.Date);
            }

            // Group the filtered data by year, month, and day, and get the pass count
            var groupedData = query
                .GroupBy(mp => new
                {
                    Year = mp.CreatedDate.Value.Year,
                    Month = mp.CreatedDate.Value.Month,
                    Day = mp.CreatedDate.Value.Day
                })
                .Select(g => new
                {
                    Date = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day).ToString("yyyy-MM-dd"),  // Date string for JavaScript
                    PassCount = g.Count()
                })
                .ToList();

            return Json(groupedData);
        }

    }

}