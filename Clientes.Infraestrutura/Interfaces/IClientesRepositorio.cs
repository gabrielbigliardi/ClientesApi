using Clientes.Contrato.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infraestrutura.Interfaces
{
    public interface IClientesRepositorio
    {
        List<ClienteDto> ObterTodos();
        //Cliente ObterPorId(int id);
        //void Adicionar(Cliente cliente);
        //void Editar(Cliente clienteAtualizado);
        //void Excluir(int id);
    }
}
