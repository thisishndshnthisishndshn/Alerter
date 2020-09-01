using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alerter.DataAccess.Concrete.EfCore;
using Alerter.Entities;

namespace Alerter.WebUI.Controllers
{
    public class TargetUrlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TargetUrlController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TargetUrl
        public async Task<IActionResult> Index()
        {
            return View(await _context.TargetUrls.ToListAsync());
        }

        // GET: TargetUrl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetUrl = await _context.TargetUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetUrl == null)
            {
                return NotFound();
            }

            return View(targetUrl);
        }

        // GET: TargetUrl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TargetUrl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Url,Name")] TargetUrl targetUrl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(targetUrl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(targetUrl);
        }

        // GET: TargetUrl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetUrl = await _context.TargetUrls.FindAsync(id);
            if (targetUrl == null)
            {
                return NotFound();
            }
            return View(targetUrl);
        }

        // POST: TargetUrl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Url,Name")] TargetUrl targetUrl)
        {
            if (id != targetUrl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(targetUrl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetUrlExists(targetUrl.Id))
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
            return View(targetUrl);
        }

        // GET: TargetUrl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetUrl = await _context.TargetUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetUrl == null)
            {
                return NotFound();
            }

            return View(targetUrl);
        }

        // POST: TargetUrl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var targetUrl = await _context.TargetUrls.FindAsync(id);
            _context.TargetUrls.Remove(targetUrl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetUrlExists(int id)
        {
            return _context.TargetUrls.Any(e => e.Id == id);
        }
    }
}
