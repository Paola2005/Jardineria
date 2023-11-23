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
public class PostalCodeController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostalCodeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PostalCode>>> Get()
        {
            var entidades = await _unitOfWork.PCodes.GetAllAsync();
            return _mapper.Map<List<PostalCode>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostalCodeDto>> Get(int id)
        {
            var entidad = await _unitOfWork.PCodes.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<PostalCodeDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostalCode>> Post(PostalCodeDto PostalCodeDto)
        {
            var entidad = _mapper.Map<PostalCode>(PostalCodeDto);
            this._unitOfWork.PCodes.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            PostalCodeDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = PostalCodeDto.Id}, PostalCodeDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostalCodeDto>> Put(int id, [FromBody] PostalCodeDto PostalCodeDto)
        {
            if(PostalCodeDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<PostalCode>(PostalCodeDto);
            _unitOfWork.PCodes.Update(entidades);
            await _unitOfWork.SaveAsync();
            return PostalCodeDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.PCodes.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.PCodes.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
