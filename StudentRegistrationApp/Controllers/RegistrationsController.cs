using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationApp.Models;

namespace StudentRegistrationApp.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly StudentRegistrationDbContext _context;

        public RegistrationsController(StudentRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var registrations = await _context.Registrations
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToListAsync();

            return View(registrations);
        }

        public IActionResult Create()
        {
            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName");
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);

            return View(registration);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);

            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName", registration.StudentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);

            return View(registration);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var registration = await _context.Registrations
                .Include(r => r.Student)
                .Include(r => r.Course)
                .FirstOrDefaultAsync(r => r.RegistrationId == id);

            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}