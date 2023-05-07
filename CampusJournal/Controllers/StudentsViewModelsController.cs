using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampusJournal.Data;
using CampusJournal.Models;

namespace CampusJournal.Controllers
{
    public class StudentsViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentsViewModels
        public async Task<IActionResult> Index()
        {
              return _context.StudentsViewModel != null ? 
                          View(await _context.StudentsViewModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentsViewModel'  is null.");
        }

        // GET: StudentsViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentsViewModel == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // GET: StudentsViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentIndexNumber,firstName,lastName,email,PhoneNumber,DateOfBirth,Address,City")] StudentsViewModel studentsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsViewModel);
        }

        // GET: StudentsViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentsViewModel == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel.FindAsync(id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }
            return View(studentsViewModel);
        }

        // POST: StudentsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentIndexNumber,firstName,lastName,email,PhoneNumber,DateOfBirth,Address,City")] StudentsViewModel studentsViewModel)
        {
            if (id != studentsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsViewModelExists(studentsViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentsViewModel);
        }

        // GET: StudentsViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentsViewModel == null)
            {
                return NotFound();
            }

            var studentsViewModel = await _context.StudentsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsViewModel == null)
            {
                return NotFound();
            }

            return View(studentsViewModel);
        }

        // POST: StudentsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentsViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentsViewModel'  is null.");
            }
            var studentsViewModel = await _context.StudentsViewModel.FindAsync(id);
            if (studentsViewModel != null)
            {
                _context.StudentsViewModel.Remove(studentsViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsViewModelExists(int id)
        {
          return (_context.StudentsViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
