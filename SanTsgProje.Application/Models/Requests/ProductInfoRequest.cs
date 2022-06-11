using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models.Requests
{
    public class ProductInfoRequest
    {
        public int ProductType { get; set; } = 2;
        public int OwnerProduct { get; set; } = 2;
        public string Product { get; set; }
        public string Culture { get; set; } = "en-US";

    }
}
