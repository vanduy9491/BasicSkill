using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasicSkillProject.Models;

namespace BasicSkillProject.Controllers
{
    public class EventRegitsController : Controller
    {
        private readonly ShakaiDBContext _context;

        public EventRegitsController(ShakaiDBContext context)
        {
            _context = context;
        }

        // GET: EventRegits
        public async Task<IActionResult> Index()
        {
            var shakaiDBContext = _context.EventRegits.Include(e => e.Event).Include(e => e.User);
            List<EventRegit> eventRegits = new List<EventRegit>();
            foreach (var item in shakaiDBContext)
            {
                eventRegits.Add(item);
            }
            return View(eventRegits);
        }

        // GET: EventRegits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegit = await _context.EventRegits
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventRegit == null)
            {
                return NotFound();
            }

            return View(eventRegit);
        }

        // GET: EventRegits/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "EventName");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: EventRegits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,UserId,SchoolYear,SchoolActivitie,OwnAction,PowerExerted,DevelopedCapacity,WhatWasThought,CommentId,Status")] EventRegit eventRegit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventRegit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "EventName", eventRegit.EventId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", eventRegit.UserId);
            return View(eventRegit);
        }

        // GET: EventRegits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegit = await _context.EventRegits.FindAsync(id);
            if (eventRegit == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "EventName", eventRegit.EventId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", eventRegit.UserId);
            return View(eventRegit);
        }

        // POST: EventRegits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventId,UserId,SchoolYear,SchoolActivitie,OwnAction,PowerExerted,DevelopedCapacity,WhatWasThought,CommentId,Status")] EventRegit eventRegit)
        {
            if (id != eventRegit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventRegit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventRegitExists(eventRegit.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "EventName", eventRegit.EventId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", eventRegit.UserId);
            return View(eventRegit);
        }

        // GET: EventRegits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventRegit = await _context.EventRegits
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventRegit == null)
            {
                return NotFound();
            }

            return View(eventRegit);
        }

        // POST: EventRegits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventRegit = await _context.EventRegits.FindAsync(id);
            _context.EventRegits.Remove(eventRegit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventRegitExists(int id)
        {
            return _context.EventRegits.Any(e => e.Id == id);
        }
    }
}
