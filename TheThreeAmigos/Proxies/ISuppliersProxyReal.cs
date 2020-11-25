using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheThreeAmigos.Data;
using TheThreeAmigos.Models;
using TheThreeAmigos.Proxies;

namespace TheThreeAmigosCorp.Proxies
{


    public class RealSuppliersProxy : ISuppliersProxyReal
    {
        private readonly TheThreeAmigosContext _context;

        public RealSuppliersProxy(TheThreeAmigosContext context)
        {
            _context = context;
        }

        public Task CreateSupplier(SuppliersModel Create)
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
                .FirstOrDefaultAsync(m => m.SupplierId == Get); ;
        }

        public async Task<List<SuppliersModel>> GetSuppliers()
        {
            return await _context.SuppliersModel.ToListAsync();
        }
    }
}
