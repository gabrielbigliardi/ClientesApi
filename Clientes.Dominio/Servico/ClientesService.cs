using AutoMapper;
using Clientes.Contrato.Entidades;
using Clientes.Dominio.Interfaces;
using Clientes.Contrato.Dto;
using Clientes.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Dominio.Servico
{
    public class ClientesService : IClientesService
    {

        private readonly IClientesRepositorio _clientesRepositorio;
        private readonly IMapper _mapper;

        public ClientesService(IClientesRepositorio clienteRepositorio, IMapper mapper)
        {
            _clientesRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public List<Cliente> ObterTodos()
        {
            var clients = _mapper.Map<List<Cliente>>(_clientesRepositorio.ObterTodos());
            return clients;
        }

        public Cliente ObterPorId(int id)
        {
            // Obtém o ClienteDto da camada de infraestrutura
            var clienteDto = _clientesRepositorio.ObterPorId(id);

            if (clienteDto == null)
                throw new Exception("Cliente não encontrado.");

            // Converte ClienteDto para Cliente usando o AutoMapper
            var cliente = _mapper.Map<Cliente>(clienteDto);

            return cliente;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            // Converte Cliente (domínio) para ClienteDto (infraestrutura)
            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            // Chama a infraestrutura para adicionar o cliente
            var clienteDtoCriado = _clientesRepositorio.Adicionar(clienteDto);

            // Converte ClienteDto de volta para Cliente
            return _mapper.Map<Cliente>(clienteDtoCriado);
        }

        public Cliente Editar(int id, Cliente cliente)
        {
            // Converte Cliente (domínio) para ClienteDto (infraestrutura)
            var clienteDto = _mapper.Map<ClienteDto>(cliente);
            // Primeiro, busca o cliente _clientesRepositorio o id fornecido
            var clienteExistente = _clientesRepositorio.ObterPorId(id);

            if (clienteExistente == null)
            {
                return null; // Cliente não encontrado
            }

            // Atualiza os dados do cliente existente com os novos dados
            clienteExistente.Nome = clienteDto.Nome;
            clienteExistente.Endereco = clienteDto.Endereco;
            clienteExistente.Cep = clienteDto.Cep;
            clienteExistente.DataNascimento = clienteDto.DataNascimento;
            clienteExistente.Telefone = clienteDto.Telefone;

            var clienteDtoEditado = _clientesRepositorio.Editar(clienteExistente);

            // Salva a atualização no repositório
            return _mapper.Map<Cliente>(clienteDtoEditado);
        }


        public bool Excluir(int id)
        {
            var clienteExistente = _clientesRepositorio.ObterPorId(id);

            if (clienteExistente == null)
            {
                return false; // Cliente não encontrado
            }

            // Chama a camada de infraestrutura para excluir o cliente
            return _clientesRepositorio.Excluir(id);
        }

        //private int GerarNovoId()
        //{
        //    var clientesExistentes = _clientesRepositorio.ObterTodos();
        //    return clientesExistentes.Any() ? clientesExistentes.Max(c => c.ClienteId) + 1 : 1;
        //}

        //public void Editar(int id, Cliente clienteAtualizado)
        //{
        //    // Lógica de validação ou negócio aqui
        //    var cliente = _clienteRepositorio.ObterPorId(id);
        //    if (cliente == null)
        //        throw new Exception("Cliente não encontrado.");

        //    cliente.Atualizar(clienteAtualizado);
        //    _clienteRepositorio.Editar(cliente);
        //}

        //public void Excluir(int id)
        //{
        //    _clienteRepositorio.Excluir(id);
        //}
    }
}
