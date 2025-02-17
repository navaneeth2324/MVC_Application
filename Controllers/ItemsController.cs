using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Application.Data;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Context _context;
        public ItemsController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.Include(s=>s.SerialNumber)
                                            .Include(c=>c.Category)
                                            .Include(ic => ic.ItemClients)
                                            .ThenInclude(c => c.Client)
                                            .ToListAsync();
            return View(items);
        }
        public IActionResult Create()
        {
            ViewData["Categories"]=new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(int id)
        {
            
                var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

