using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTo>().ReverseMap();
            CreateMap<Category, CategoryDTo>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTo>().ReverseMap();
            CreateMap<ProductUpdateDTo, Product>();
            CreateMap<Product, ProductWithCategoryDTo>();
            CreateMap<Category, CategoryWithProductsDTo>();
        }
    }
}
