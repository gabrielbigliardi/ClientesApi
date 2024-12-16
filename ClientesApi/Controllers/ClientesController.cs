using AutoMapper;
using Clientes.Aplicacao.Interfaces;
using Clientes.Aplicacao.Servicos;
using Clientes.Contrato.Dto;
using Clientes.Contrato.Entidades;
using Clientes.Contrato.Map;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly IClientesAplService _clientesAplService;
        private readonly IMapper _mapper;

        public ClientesController(IClientesAplService clientesAplService, IMapper mapper) 
        {
            _clientesAplService = clientesAplService;
            _mapper = mapper;
        }

        [HttpGet("ConsultarTodos")]
        public IActionResult ConsultarTodos()
        {
            try
            {
               var clientes = _clientesAplService.ObterTodos();

                return Ok(clientes);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("ConsultarPorId/{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            try
            {
                var clientes = _clientesAplService.ObterPorId(id);

                return Ok(clientes);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }


        [HttpPost]
        public IActionResult Adicionar([FromBody] ClienteDto clienteDto)
        {
            try
            {
                // Converte ClienteDto (view) para Cliente (domínio)
                var cliente = _mapper.Map<Cliente>(clienteDto);

                // Chama a camada de aplicação para adicionar o cliente
                var clienteCriado = _clientesAplService.Adicionar(cliente);

                // Converte Cliente (domínio) de volta para ClienteDto (view)
                var clienteCriadoDto = _mapper.Map<ClienteDto>(clienteCriado);

                return CreatedAtAction(nameof(ConsultarPorId), new { id = clienteCriadoDto.ClienteId }, clienteCriadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public IActionResult Teste([FromBody] Cliente clienteDto)
        //{
        //    try
        //    {
        //        return Ok(clienteDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        // PUT api/cliente/{id}
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                // Chama a camada de aplicação para atualizar o cliente
                var clienteAtualizado = _clientesAplService.Editar(id, cliente);

                if (clienteAtualizado == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                return Ok(clienteAtualizado); // Retorna o cliente atualizado com o novo ID
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        //DELETE api/cliente/{id}
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var resultado = _clientesAplService.Excluir(id);

                if (!resultado)
                {
                    return NotFound("Cliente não encontrado.");
                }

                return NoContent(); // Retorna 204 No Content caso a exclusão seja bem-sucedida
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
