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

        //public Cliente ObterPorId(int id)
        //{
        //    var cliente = _clienteRepositorio.ObterPorId(id);
        //    if (cliente == null)
        //        throw new Exception("Cliente não encontrado.");

        //    return cliente;
        //}

        //public void Adicionar(Cliente cliente)
        //{
        //    // Lógica de validação ou negócio aqui
        //    if (string.IsNullOrWhiteSpace(cliente.Nome))
        //        throw new ArgumentException("O nome do cliente é obrigatório.");

        //    _clienteRepositorio.Adicionar(cliente);
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
