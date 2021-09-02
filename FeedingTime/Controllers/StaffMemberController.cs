using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeedingTime.Data;
using FeedingTime.Models;

namespace FeedingTime.Controllers
{
    public class StaffMemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffMemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffMember
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffMembers.ToListAsync());
        }

        // GET: StaffMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers
                .FirstOrDefaultAsync(m => m.StaffMemberID == id);
            if (staffMembers == null)
            {
                return NotFound();
            }

            return View(staffMembers);
        }

        // GET: StaffMember/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffMembersID,FirstName,LastName,Age,EnclosureWorkingAt,Sex,Roles,DateEmployed,PhoneNum")] StaffMember staffMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffMembers);
        }

        // GET: StaffMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers.FindAsync(id);
            if (staffMembers == null)
            {
                return NotFound();
            }
            return View(staffMembers);
        }

        // POST: StaffMember/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffMembersID,FirstName,LastName,Age,EnclosureWorkingAt,Sex,Roles,DateEmployed,PhoneNum")] StaffMember staffMembers)
        {
            if (id != staffMembers.StaffMemberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffMembersExists(staffMembers.StaffMemberID))
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
            return View(staffMembers);
        }

        // GET: StaffMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers
                .FirstOrDefaultAsync(m => m.StaffMemberID == id);
            if (staffMembers == null)
            {
                return NotFound();
            }

            return View(staffMembers);
        }

        // POST: StaffMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffMembers = await _context.StaffMembers.FindAsync(id);
            _context.StaffMembers.Remove(staffMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffMembersExists(int id)
        {
            return _context.StaffMembers.Any(e => e.StaffMemberID == id);
        }
    }
}
