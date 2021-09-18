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
    public class SuperAdminsController : Controller
    {
        private readonly Web_Dev_Proj_GymContext _context;

        public SuperAdminsController(Web_Dev_Proj_GymContext context)
        {
            _context = context;
        }

        // GET: SuperAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperAdmin.ToListAsync());
        }

        // GET: SuperAdmins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmin
                .FirstOrDefaultAsync(m => m.SMUserName == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // GET: SuperAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SMUserName,SMpassword")] SuperAdmin superAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superAdmin);
        }

        // GET: SuperAdmins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmin.FindAsync(id);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return View(superAdmin);
        }

        // POST: SuperAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SMUserName,SMpassword")] SuperAdmin superAdmin)
        {
            if (id != superAdmin.SMUserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperAdminExists(superAdmin.SMUserName))
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
            return View(superAdmin);
        }

        // GET: SuperAdmins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.SuperAdmin
                .FirstOrDefaultAsync(m => m.SMUserName == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // POST: SuperAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var superAdmin = await _context.SuperAdmin.FindAsync(id);
            _context.SuperAdmin.Remove(superAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperAdminExists(string id)
        {
            return _context.SuperAdmin.Any(e => e.SMUserName == id);
        }
    }
}
