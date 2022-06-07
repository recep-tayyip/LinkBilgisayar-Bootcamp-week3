using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Entities.Concrete
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
