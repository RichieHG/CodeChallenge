using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
