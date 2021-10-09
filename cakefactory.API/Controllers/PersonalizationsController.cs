using cakefactory.API.Data;
using cakefactory.API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace cakefactory.API.Controllers
{
    public class PersonalizationsController : Controller
    {
        private readonly DataContext _context;

        public PersonalizationsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Personalizations.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personalization personalization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(personalization);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta personalización");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(personalization);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personalization personalization = await _context.Personalizations.FindAsync(id);
            if (personalization == null)
            {
                return NotFound();
            }

            return View(personalization);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Personalization personalization)
        {
            if (id != personalization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalization);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta personalización");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(personalization);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personalization personalization = await _context.Personalizations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalization == null)
            {
                return NotFound();
            }
            _context.Personalizations.Remove(personalization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        private bool PersonalizationExists(int id)
        {
            return _context.Personalizations.Any(e => e.Id == id);
        }
    }
}
