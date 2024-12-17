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
using Clientes.Contrato.Entidades;

namespace Clientes.Aplicacao.Servicos
{
    public class ClientesAplService : IClientesAplService
    {
        private readonly IClientesService _clientesService;

        public ClientesAplService(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public List<Cliente> ObterTodos()
        {
            var clientes = _clientesService.ObterTodos();

            return clientes;
        }

        public ClienteDto ObterPorId(int id)
        {
            var cliente = _clientesService.ObterPorId(id);

            //if (cliente == null)
            //{
            //    return null; // Retorna null se o cliente não for encontrado
            //}

            // Mapeia para o DTO (se necessário, depende da sua arquitetura)
            var clienteDto = new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Cep = cliente.Cep,
                DataNascimento = cliente.DataNascimento,
                Telefone = cliente.Telefone
            };

            return clienteDto; // Retorna o cliente mapeado para o DTO
        }

        public Cliente Adicionar(Cliente cliente)
        {
            // Chama a camada de domínio para adicionar o cliente
            return _clientesService.Adicionar(cliente);
        }

        public Cliente Editar(int id, Cliente cliente)
        {
            return _clientesService.Editar(id, cliente);
        }

        public bool Excluir(int id)
        {
            return _clientesService.Excluir(id);
        }
    }
}



