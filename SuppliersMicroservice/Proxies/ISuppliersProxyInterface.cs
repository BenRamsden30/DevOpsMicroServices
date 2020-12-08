using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThreeAmigos.Models;

namespace TheThreeAmigos.Proxies
{

    public interface ISuppliersProxyInterface
    {
        Task<List<SuppliersModel>> GetSuppliers();

        Task<SuppliersModel> GetSupplier(string Get);

        Task EditSupplier(SuppliersModel Edit);

        Task DeleteSupplier(SuppliersModel Delete);

        Task CreateSupplier(SuppliersModel Create,  string supplierID);
    }
}

