using Microsoft.EntityFrameworkCore;
using SuppliersMicroservice.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheThreeAmigos.Models;
using TheThreeAmigos.Proxies;

namespace TheThreeAmigosCorp.Proxies
{


    public class RealSuppliersProxy : ISuppliersProxyInterface
    {
        private readonly SuppliersMicroserviceContext _context;

        public RealSuppliersProxy(SuppliersMicroserviceContext context)
        {
            _context = context;
        }

        public Task CreateSupplier(SuppliersModel Create, string supplierID)
        {
            return Task.Run(async () => {
                _context.Add(Create);
                await _context.SaveChangesAsync();
            });
        }

        public Task DeleteSupplier(SuppliersModel Delete)
        {
            return Task.Run(async () =>
            {
                _context.SuppliersModel.Remove(Delete);
                await _context.SaveChangesAsync();
            });
        }

        public Task EditSupplier(SuppliersModel Edit)
        {
            return Task.Run(async () =>
            {
                    _context.Update(Edit);
                    await _context.SaveChangesAsync();
            });
        }

        public async Task<SuppliersModel> GetSupplier(string Get)
        {
            return await _context.SuppliersModel
                .FirstOrDefaultAsync(m => m.SupplierId == Get); 
        }

        public async Task<List<SuppliersModel>> GetSuppliers()
        {
            return await _context.SuppliersModel.ToListAsync();
        }
    }
}
