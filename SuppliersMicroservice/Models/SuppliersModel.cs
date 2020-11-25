using System;
using System.ComponentModel.DataAnnotations;

namespace TheThreeAmigos.Models
{
    public class SuppliersModel
    {
        [Key]
        public string SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierContactNumber { get; set; }

    }
}
