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
public class StatusController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Status>>> Get()
        {
            var entidades = await _unitOfWork.Status.GetAllAsync();
            return _mapper.Map<List<Status>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatusDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Status.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<StatusDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Status>> Post(StatusDto StatusDto)
        {
            var entidad = _mapper.Map<Status>(StatusDto);
            this._unitOfWork.Status.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            StatusDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = StatusDto.Id}, StatusDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StatusDto>> Put(int id, [FromBody] StatusDto StatusDto)
        {
            if(StatusDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Status>(StatusDto);
            _unitOfWork.Status.Update(entidades);
            await _unitOfWork.SaveAsync();
            return StatusDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Status.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Status.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }