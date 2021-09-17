using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Dev_Proj_Gym.Data;
using Web_Dev_Proj_Gym.Models;

namespace Web_Dev_Proj_Gym.Controllers
{
    public class CustomerTrainingsController : Controller
    {
        private readonly Web_Dev_Proj_GymContext _context;

        public CustomerTrainingsController(Web_Dev_Proj_GymContext context)
        {
            _context = context;
        }

        // GET: CustomerTrainings
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerTrainings.ToListAsync());
        }

        // GET: CustomerTrainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTrainings = await _context.CustomerTrainings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customerTrainings == null)
            {
                return NotFound();
            }

            return View(customerTrainings);
        }

        // GET: CustomerTrainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTrainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Timing")] CustomerTrainings customerTrainings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerTrainings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerTrainings);
        }

        // GET: CustomerTrainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTrainings = await _context.CustomerTrainings.FindAsync(id);
            if (customerTrainings == null)
            {
                return NotFound();
            }
            return View(customerTrainings);
        }

        // POST: CustomerTrainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Timing")] CustomerTrainings customerTrainings)
        {
            if (id != customerTrainings.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerTrainings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTrainingsExists(customerTrainings.ID))
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
            return View(customerTrainings);
        }

        // GET: CustomerTrainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTrainings = await _context.CustomerTrainings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customerTrainings == null)
            {
                return NotFound();
            }

            return View(customerTrainings);
        }

        // POST: CustomerTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerTrainings = await _context.CustomerTrainings.FindAsync(id);
            _context.CustomerTrainings.Remove(customerTrainings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTrainingsExists(int id)
        {
            return _context.CustomerTrainings.Any(e => e.ID == id);
        }
    }
}
