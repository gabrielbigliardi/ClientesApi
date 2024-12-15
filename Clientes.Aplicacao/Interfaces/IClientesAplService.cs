using Clientes.Aplicacao.Dtos;
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
        //ClienteDto ObterPorId(int id);

        //// Método para adicionar um novo cliente
        //void Adicionar(ClienteDto clienteDto);

        //// Método para atualizar um cliente existente
        //void Atualizar(ClienteDto clienteDto);

        //// Método para remover um cliente por ID
        //void Remover(int id);
    }
}
