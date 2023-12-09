using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTo>>(products.ToList());
            return CreateActionResult(CustomResponseDTo<List<ProductDTo>>.Success(200, productsDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDTo>(product);
            return CreateActionResult(CustomResponseDTo<ProductDTo>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTo productDTo)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDTo));
            var productsDto = _mapper.Map<ProductDTo>(product);
            return CreateActionResult(CustomResponseDTo<ProductDTo>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTo productDTo)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDTo));
            return CreateActionResult(CustomResponseDTo<NoContentDTo>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTo<List<NoContentDTo>>.Success(204));
        }

    }
}
