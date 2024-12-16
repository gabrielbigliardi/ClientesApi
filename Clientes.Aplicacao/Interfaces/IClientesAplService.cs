using Clientes.Contrato.Dto;
using Clientes.Contrato.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Interfaces
{
    public interface IClientesAplService
    {
        // Método para obter todos os clientes
        IEnumerable<ClienteDto> ObterTodos();

        //// Método para obter um cliente por ID
        ClienteDto ObterPorId(int id);

        //// Método para adicionar um novo cliente
        Cliente Adicionar(Cliente cliente);

        //// Método para atualizar um cliente existente
        Cliente Editar(int id, Cliente clienteDto);

        //// Método para remover um cliente por ID
        bool Excluir(int id);
    }
}
