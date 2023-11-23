using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class MethodPaymentController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MethodPaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MethodPayment>>> Get()
        {
            var entidades = await _unitOfWork.Methods.GetAllAsync();
            return _mapper.Map<List<MethodPayment>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodPaymentDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Methods.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<MethodPaymentDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MethodPayment>> Post(MethodPaymentDto MethodPaymentDto)
        {
            var entidad = _mapper.Map<MethodPayment>(MethodPaymentDto);
            this._unitOfWork.Methods.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            MethodPaymentDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = MethodPaymentDto.Id}, MethodPaymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodPaymentDto>> Put(int id, [FromBody] MethodPaymentDto MethodPaymentDto)
        {
            if(MethodPaymentDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<MethodPayment>(MethodPaymentDto);
            _unitOfWork.Methods.Update(entidades);
            await _unitOfWork.SaveAsync();
            return MethodPaymentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Methods.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Methods.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
