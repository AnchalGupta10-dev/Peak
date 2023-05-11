using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Peak.Models;

namespace Peak.Controllers
{
    public class SopOrderMethodReferencesController : Controller
    {
        private readonly Stp_Oms_LiveContext _context;

        public SopOrderMethodReferencesController(Stp_Oms_LiveContext context)
        {
            _context = context;
        }

        // GET: SopOrderMethodReferences
        public async Task<IActionResult> Index()
        {
            var stp_Oms_LiveContext = _context.SopOrderMethodReferences.Include(s => s.SopSalesChannelReference);
            return View(await stp_Oms_LiveContext.ToListAsync());
        }

        // GET: SopOrderMethodReferences/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.SopOrderMethodReferences == null)
            {
                return NotFound();
            }

            var sopOrderMethodReference = await _context.SopOrderMethodReferences
                .Include(s => s.SopSalesChannelReference)
                .FirstOrDefaultAsync(m => m.SopOrderMethodReferenceId == id);
            if (sopOrderMethodReference == null)
            {
                return NotFound();
            }

            return View(sopOrderMethodReference);
        }

        // GET: SopOrderMethodReferences/Create
        public IActionResult Create()
        {
            ViewData["SopSalesChannelReferenceId"] = new SelectList(_context.SopSalesChannelReferences, "SopSalesChannelReferenceId", "SopSalesChannelReferenceId");
            return View();
        }

        // POST: SopOrderMethodReferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SopOrderMethodReferenceId,CreateScsUserId,CreateTimeStampUtc,CreateScsSqlUserId,UpdateScsUserId,UpdateTimeStampUtc,UpdateScsSqlUserId,TransactionGuid,OrderMethodCode,OrderMethodName,UserSelectable,SopSalesChannelReferenceId")] SopOrderMethodReference sopOrderMethodReference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sopOrderMethodReference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SopSalesChannelReferenceId"] = new SelectList(_context.SopSalesChannelReferences, "SopSalesChannelReferenceId", "SopSalesChannelReferenceId", sopOrderMethodReference.SopSalesChannelReferenceId);
            return View(sopOrderMethodReference);
        }

        // GET: SopOrderMethodReferences/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.SopOrderMethodReferences == null)
            {
                return NotFound();
            }

            var sopOrderMethodReference = await _context.SopOrderMethodReferences.FindAsync(id);
            if (sopOrderMethodReference == null)
            {
                return NotFound();
            }
            ViewData["SopSalesChannelReferenceId"] = new SelectList(_context.SopSalesChannelReferences, "SopSalesChannelReferenceId", "SopSalesChannelReferenceId", sopOrderMethodReference.SopSalesChannelReferenceId);
            return View(sopOrderMethodReference);
        }

        // POST: SopOrderMethodReferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SopOrderMethodReferenceId,CreateScsUserId,CreateTimeStampUtc,CreateScsSqlUserId,UpdateScsUserId,UpdateTimeStampUtc,UpdateScsSqlUserId,TransactionGuid,OrderMethodCode,OrderMethodName,UserSelectable,SopSalesChannelReferenceId")] SopOrderMethodReference sopOrderMethodReference)
        {
            if (id != sopOrderMethodReference.SopOrderMethodReferenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sopOrderMethodReference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SopOrderMethodReferenceExists(sopOrderMethodReference.SopOrderMethodReferenceId))
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
            ViewData["SopSalesChannelReferenceId"] = new SelectList(_context.SopSalesChannelReferences, "SopSalesChannelReferenceId", "SopSalesChannelReferenceId", sopOrderMethodReference.SopSalesChannelReferenceId);
            return View(sopOrderMethodReference);
        }

        // GET: SopOrderMethodReferences/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.SopOrderMethodReferences == null)
            {
                return NotFound();
            }

            var sopOrderMethodReference = await _context.SopOrderMethodReferences
                .Include(s => s.SopSalesChannelReference)
                .FirstOrDefaultAsync(m => m.SopOrderMethodReferenceId == id);
            if (sopOrderMethodReference == null)
            {
                return NotFound();
            }

            return View(sopOrderMethodReference);
        }

        // POST: SopOrderMethodReferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.SopOrderMethodReferences == null)
            {
                return Problem("Entity set 'Stp_Oms_LiveContext.SopOrderMethodReferences'  is null.");
            }
            var sopOrderMethodReference = await _context.SopOrderMethodReferences.FindAsync(id);
            if (sopOrderMethodReference != null)
            {
                _context.SopOrderMethodReferences.Remove(sopOrderMethodReference);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SopOrderMethodReferenceExists(long id)
        {
          return (_context.SopOrderMethodReferences?.Any(e => e.SopOrderMethodReferenceId == id)).GetValueOrDefault();
        }
    }
}
