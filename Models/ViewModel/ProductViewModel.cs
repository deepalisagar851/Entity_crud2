using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_crud_2.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Descr { get; set; }
        public int Category { get; set; }
    }
}