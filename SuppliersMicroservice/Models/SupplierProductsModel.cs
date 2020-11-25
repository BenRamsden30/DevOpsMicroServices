using System;
using System.ComponentModel.DataAnnotations;

namespace TheThreeAmigos.Models
{
    public class SupplierProductssModel
    {
        [Key]
        public string SupplierProductid { get; set; }

        public string SupplierId { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double ProductPricePounds { get; set; }

    }
}