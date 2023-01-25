using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductsService
    {
        Task Add(ProductDTO product);
        Task<IEnumerable<ProductDTO>> Get();
        Task<ProductDTO> Get(Guid id);
        Task Delete(Guid id);
        Task Update(Guid id, ProductDTO product);
    }
}
