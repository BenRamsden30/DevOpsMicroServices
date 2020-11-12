using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheThreeAmigos.Data;
using TheThreeAmigos.Models;

namespace TheThreeAmigos.Controllers
{
    public class SupplierssModelsController : Controller
    {
        private readonly TheThreeAmigosContext _context;

        public SupplierssModelsController(TheThreeAmigosContext context)
        {
            _context = context;
        }

        // GET: SupplierssModels
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.SuppliersModel.ToListAsync());
        }

        // GET: SupplierssModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierssModel = await _context.SuppliersModel
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplierssModel == null)
            {
                return NotFound();
            }

            return Ok(supplierssModel);
        }



        // POST: SupplierssModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,SupplierAddress,SupplierEmail,SupplierContactNumber")] SuppliersModel supplierssModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierssModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(supplierssModel);
        }



        // POST: SupplierssModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierId,SupplierName,SupplierAddress,SupplierEmail,SupplierContactNumber")] SuppliersModel supplierssModel)
        {
            if (id != supplierssModel.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierssModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierssModelExists(supplierssModel.SupplierId))
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
            return Ok(supplierssModel);
        }


        // POST: SupplierssModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var supplierssModel = await _context.SuppliersModel.FindAsync(id);
            _context.SuppliersModel.Remove(supplierssModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierssModelExists(string id)
        {
            return _context.SuppliersModel.Any(e => e.SupplierId == id);
        }
    }
}
