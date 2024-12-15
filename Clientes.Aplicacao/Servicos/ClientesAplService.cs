using Clientes.Contrato.Dto;
using Clientes.Aplicacao.Interfaces;
using Clientes.Dominio.Interfaces;
using Clientes.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Servicos
{
    public class ClientesAplService : IClientesAplService
    {
        private readonly IClientesService _clientesService;

        public ClientesAplService(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public IEnumerable<ClienteDto> ObterTodos()
        {
            var clientes = _clientesService.ObterTodos();

            return clientes.Select(cliente => new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Cep = cliente.Cep,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone
            });
        }
    }
}
