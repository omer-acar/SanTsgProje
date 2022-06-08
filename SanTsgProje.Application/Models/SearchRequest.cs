using System;
using System.Collections.Generic;
using System.Text;

namespace SanTsgProje.Application.Models
{
    public class SearchRequest
    {
        public int ProductType { get; set; } = 2;
        public string Query { get; set; }
        public string Culture { get; set; }

    }
}
