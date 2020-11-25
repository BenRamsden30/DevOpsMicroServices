using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheThreeAmigos.Models;
using TheThreeAmigos.Proxies;

namespace TheThreeAmigos.Controllers
{
    public class SupplierssModelsController : Controller
    {
        private readonly ISuppliersProxyInterface _context;

        public SupplierssModelsController(ISuppliersProxyInterface context)
        {
            _context = context;
        }
        [HttpGet("/Suppliers")]
        // GET: SupplierssModels
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.GetSuppliers());
        }

        [HttpGet("/SuppliersDetails/{id}")]
        // GET: SupplierssModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierssModel = await _context.GetSupplier(id);
            if (supplierssModel == null)
            {
                return NotFound();
            }

            return Ok(supplierssModel);
        }



        // POST: SupplierssModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost ("/CreateSupplier")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,SupplierAddress,SupplierEmail,SupplierContactNumber")] SuppliersModel supplierssModel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateSupplier(supplierssModel);
                return RedirectToAction(nameof(Index));
            }
            return Ok(supplierssModel);
        }



        // POST: SupplierssModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost ("/EditSuppliers")]
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

                    await _context.EditSupplier(supplierssModel);
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
        [HttpPost ("/DeleteSuppliers/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var suppliersModel = await _context.GetSupplier(id);
            await _context.DeleteSupplier(suppliersModel);
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierssModelExists(string id)
        {
            return _context.GetSupplier(id) != null;
        }
    }
}
