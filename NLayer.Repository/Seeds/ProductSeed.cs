﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product() {
                Id = 1,
                CategoryId =1,
                Name="qelem1",
                Price = 100,
                Stock = 20,
                CreatedDate = DateTime.Now,
            
                
            },
            new Product()
            {
                Id = 2,
                CategoryId = 2,
                Name = "qelem3",
                Price = 200,
                Stock = 30,
                CreatedDate = DateTime.Now,


            },
            new Product()
            {
                Id = 3,
                CategoryId = 3,
                Name = "qelem4",
                Price = 400,
                Stock = 50,
                CreatedDate = DateTime.Now,
            },
            new Product()
            {
                Id = 4,
                CategoryId = 4,
                Name = "qelem5",
                Price = 600,
                Stock = 30,
                CreatedDate = DateTime.Now,
            }
            );
        }
    }
}
