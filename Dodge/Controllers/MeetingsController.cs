using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dodge.Models;

namespace Dodge.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly DodgeContext _context;

        public MeetingsController(DodgeContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var dodgeContext = _context.Meetings.Include(m => m.Client).Include(m => m.User);
            return View(await dodgeContext.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetings = await _context.Meetings
                .Include(m => m.Client)
                .Include(m => m.User)
                .SingleOrDefaultAsync(m => m.id == id);
            if (meetings == null)
            {
                return NotFound();
            }

            return View(meetings);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "name");
            ViewData["UserId"] = new SelectList(_context.User, "id", "name");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,subject,date,UserId,AVirtual,ClientId")] Meetings meetings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "id", meetings.ClientId);
            ViewData["UserId"] = new SelectList(_context.User, "id", "id", meetings.UserId);
            return View(meetings);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetings = await _context.Meetings.SingleOrDefaultAsync(m => m.id == id);
            if (meetings == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "name", meetings.ClientId);
            ViewData["UserId"] = new SelectList(_context.User, "id", "name", meetings.UserId);
            return View(meetings);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,subject,date,UserId,AVirtual,ClientId")] Meetings meetings)
        {
            if (id != meetings.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingsExists(meetings.id))
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
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "id", meetings.ClientId);
            ViewData["UserId"] = new SelectList(_context.User, "id", "id", meetings.UserId);
            return View(meetings);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetings = await _context.Meetings
                .Include(m => m.Client)
                .Include(m => m.User)
                .SingleOrDefaultAsync(m => m.id == id);
            if (meetings == null)
            {
                return NotFound();
            }

            return View(meetings);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetings = await _context.Meetings.SingleOrDefaultAsync(m => m.id == id);
            _context.Meetings.Remove(meetings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingsExists(int id)
        {
            return _context.Meetings.Any(e => e.id == id);
        }
    }
}
