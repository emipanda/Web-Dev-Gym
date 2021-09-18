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
    public class BranchManagersController : Controller
    {
        private readonly Web_Dev_Proj_GymContext _context;

        public BranchManagersController(Web_Dev_Proj_GymContext context)
        {
            _context = context;
        }

        // GET: BranchManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BranchManager.ToListAsync());
        }

        // GET: BranchManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchManager = await _context.BranchManager
                .FirstOrDefaultAsync(m => m.ID == id);
            if (branchManager == null)
            {
                return NotFound();
            }

            return View(branchManager);
        }

        // GET: BranchManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BMID,BMUserName,BMPassword,BMName")] BranchManager branchManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchManager);
        }

        // GET: BranchManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchManager = await _context.BranchManager.FindAsync(id);
            if (branchManager == null)
            {
                return NotFound();
            }
            return View(branchManager);
        }

        // POST: BranchManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BMUserName,BMPassword,BMName")] BranchManager branchManager)
        {
            if (id != branchManager.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchManagerExists(branchManager.ID))
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
            return View(branchManager);
        }

        // GET: BranchManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchManager = await _context.BranchManager
                .FirstOrDefaultAsync(m => m.ID == id);
            if (branchManager == null)
            {
                return NotFound();
            }

            return View(branchManager);
        }

        // POST: BranchManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchManager = await _context.BranchManager.FindAsync(id);
            _context.BranchManager.Remove(branchManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchManagerExists(int id)
        {
            return _context.BranchManager.Any(e => e.ID == id);
        }
    }
}
