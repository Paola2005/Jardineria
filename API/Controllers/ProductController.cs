using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var product = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(product);
        }

        
       [HttpGet("GetProductsNoOrderWithInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsNoOrderWithInfo()
        {
            var product = await _unitOfWork.Products.GetProductsNoOrderWithInfo();
            return Ok(product);
        } 
        

        
       [HttpGet("GetProductRangesPerClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetProductRangesPerClient()
        {
            try
            {
                var clientCodes = _unitOfWork.Products.GetProductRangesPerClient();
                return Ok(clientCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener códigos de cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        } 
        

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Get(string id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();
            return _mapper.Map<ProductDto>(product);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Post(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();
            if (product == null) return BadRequest();
            productDto.Id = product.Id;
            return CreatedAtAction(nameof(Post), new { id = productDto.Id }, productDto);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Put(string id, [FromBody] ProductDto productDto)
        {
            if (productDto == null) return NotFound();
            if (productDto.Id == null) productDto.Id = id;
            if (productDto.Id != id) return BadRequest();
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            _mapper.Map(productDto, product);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
