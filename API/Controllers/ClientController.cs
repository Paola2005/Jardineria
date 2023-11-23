using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            var client = await _unitOfWork.Clients.GetAllAsync();
            return _mapper.Map<List<ClientDto>>(client);
        }


        [HttpGet("GetUniqueClientCodesWithPaymentsIn2008")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetUniqueClientCodesWithPaymentsIn2008()
        {
            try
            {
                var clientCodes = _unitOfWork.Clients.GetUniqueClientCodesWithPaymentsIn2008();
                return Ok(clientCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener códigos de cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        } 



     [HttpGet("GetClientsWithoutPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetClientsWithoutPayments()
        {
            try
            {
                var clientCodes = _unitOfWork.Clients.GetClientsWithoutPayments();
                return Ok(clientCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener códigos de cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        } 



      [HttpGet("GetClientsWithoutPaymentsAndRepresentativesWithCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetClientsWithoutPaymentsAndRepresentativesWithCity()
        {
            try
            {
                var clientCodes = _unitOfWork.Clients.GetClientsWithoutPaymentsAndRepresentativesWithCity();
                return Ok(clientCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener códigos de cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        } 

       [HttpGet("GetClientsWithPaymentsAndRepresentativesWithCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetClientsWithPaymentsAndRepresentativesWithCity()
        {
            try
            {
                var clientCodes = _unitOfWork.Clients.GetClientsWithPaymentsAndRepresentativesWithCity();
                return Ok(clientCodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener códigos de cliente: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


    [HttpGet("GetClientsWithRepresentativesAndOfficeCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<int>> GetClientsWithRepresentativesAndOfficeCity()
        {
            try
            {
                var clientCodes = _unitOfWork.Clients.GetClientsWithRepresentativesAndOfficeCity();
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
public async Task<ActionResult<ClientDto>> Get(int id)
{
    var client = await _unitOfWork.Clients.GetByIdAsync(id);
    if (client == null)
        return NotFound();
    return _mapper.Map<ClientDto>(client);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Client>> Post(ClientDto clientDto)
{
    var client = _mapper.Map<Client>(clientDto);
    _unitOfWork.Clients.Add(client);
    await _unitOfWork.SaveAsync();
    if (client == null)
        return BadRequest();
    clientDto.Id = client.Id;
    return CreatedAtAction(nameof(Post), new { id = clientDto.Id }, clientDto);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto clientDto)
{
    if (clientDto == null)
        return NotFound();
    if (clientDto.Id == 0)
        clientDto.Id = id;
    if (clientDto.Id != id)
        return BadRequest();
    var client = await _unitOfWork.Clients.GetByIdAsync(id);
    _mapper.Map(clientDto, client);
    //client.FechaModificacion = DateTime.Now;
    _unitOfWork.Clients.Update(client);
    await _unitOfWork.SaveAsync();
    return _mapper.Map<ClientDto>(client);
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<IActionResult> Delete(int id)
{
    var client = await _unitOfWork.Clients.GetByIdAsync(id);
    if (client == null)
        return NotFound();
    _unitOfWork.Clients.Remove(client);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}
