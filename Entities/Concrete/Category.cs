﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Newtonsoft.Json;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
