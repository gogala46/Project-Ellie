﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EllieData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }

    }
}
