using System;
using System.Collections.Generic;
using System.Text;

namespace SlnVivero.Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool State { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<Product> Products { get; set; }
    }
}
