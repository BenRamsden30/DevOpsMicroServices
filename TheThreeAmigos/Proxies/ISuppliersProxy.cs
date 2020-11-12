using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThreeAmigos.Models;

namespace TheThreeAmigosCorp.Proxies
{
    public interface ISuppliersProxy
    {
        Task<List<SuppliersModel>> GetSuppliers();

        Task<SuppliersModel> GetSupplier(string Get);

        Task EditSupplier(SuppliersModel Edit);

        Task DeleteSupplier(SuppliersModel Delete);
    }

    public class FakeSuppliersProxy : ISuppliersProxy
    {
        List<SuppliersModel> suppliers;

        public FakeSuppliersProxy()
        {
            suppliers = new List<SuppliersModel>() {
            new SuppliersModel() {SupplierId = "1", SupplierName = "Test", SupplierAddress = "42 Wallabe Way Sydney", SupplierEmail = "Test@The3Amigos.net", SupplierContactNumber = "01642012041"}
            };
        }

        public FakeSuppliersProxy(List<SuppliersModel> suppliers)
        {
            this.suppliers = suppliers;
        }





        public Task DeleteSupplier(SuppliersModel supplier)
        {
            return Task.Run(() => {
                suppliers.RemoveAll(s => s.SupplierId == supplier.SupplierId);
            });
        }

        public Task EditSupplier(SuppliersModel supplier)
        {
            return Task.Run(() => {
                suppliers.RemoveAll(s => s.SupplierId == supplier.SupplierId);
                suppliers.Add(supplier);
            });
        }

        public Task<SuppliersModel> GetSupplier(string supplierid)
        {
            return Task.FromResult(suppliers.Find(s => s.SupplierId == supplierid));
        }

        public Task<List<SuppliersModel>> GetSuppliers()
        {
            return Task.FromResult(suppliers);
        }
    }
}
