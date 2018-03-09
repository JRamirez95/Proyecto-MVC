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
    public class SupportTicketsController : Controller
    {
        private readonly DodgeContext _context;

        public SupportTicketsController(DodgeContext context)
        {
            _context = context;
        }

        // GET: SupportTickets
        public async Task<IActionResult> Index()
        {
            var dodgeContext = _context.SupportTickets.Include(s => s.Client);
            return View(await dodgeContext.ToListAsync());
        }

        // GET: SupportTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTickets = await _context.SupportTickets
                .Include(s => s.Client)
                .SingleOrDefaultAsync(m => m.id == id);
            if (supportTickets == null)
            {
                return NotFound();
            }

            return View(supportTickets);
        }

        // GET: SupportTickets/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "name");
            return View();
        }

        // POST: SupportTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,subject,problem,who,ClientId,state")] SupportTickets supportTickets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportTickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "id", supportTickets.ClientId);
            return View(supportTickets);
        }

        // GET: SupportTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTickets = await _context.SupportTickets.SingleOrDefaultAsync(m => m.id == id);
            if (supportTickets == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "name", supportTickets.ClientId);
            return View(supportTickets);
        }

        // POST: SupportTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,subject,problem,who,ClientId,state")] SupportTickets supportTickets)
        {
            if (id != supportTickets.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportTickets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTicketsExists(supportTickets.id))
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
            ViewData["ClientId"] = new SelectList(_context.Cliente, "id", "id", supportTickets.ClientId);
            return View(supportTickets);
        }

        // GET: SupportTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTickets = await _context.SupportTickets
                .Include(s => s.Client)
                .SingleOrDefaultAsync(m => m.id == id);
            if (supportTickets == null)
            {
                return NotFound();
            }

            return View(supportTickets);
        }

        // POST: SupportTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportTickets = await _context.SupportTickets.SingleOrDefaultAsync(m => m.id == id);
            _context.SupportTickets.Remove(supportTickets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTicketsExists(int id)
        {
            return _context.SupportTickets.Any(e => e.id == id);
        }
    }
}
