using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ProductLineController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductLineController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductLine>>> Get()
        {
            var entidades = await _unitOfWork.PLines.GetAllAsync();
            return _mapper.Map<List<ProductLine>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductLineDto>> Get(int id)
        {
            var entidad = await _unitOfWork.PLines.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ProductLineDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductLine>> Post(ProductLineDto ProductLineDto)
        {
            var entidad = _mapper.Map<ProductLine>(ProductLineDto);
            this._unitOfWork.PLines.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ProductLineDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ProductLineDto.Id}, ProductLineDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductLineDto>> Put(int id, [FromBody] ProductLineDto ProductLineDto)
        {
            if(ProductLineDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ProductLine>(ProductLineDto);
            _unitOfWork.PLines.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ProductLineDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.PLines.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.PLines.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }