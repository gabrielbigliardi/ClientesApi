using Clientes.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly IClientesAplService _clientesAplService;

        public ClientesController(IClientesAplService clientesAplService) 
        {
            _clientesAplService = clientesAplService;
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
    }
}
