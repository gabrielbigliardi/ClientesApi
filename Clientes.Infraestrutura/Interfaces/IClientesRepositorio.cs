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
        ClienteDto ObterPorId(int id);
        ClienteDto Adicionar(ClienteDto clienteDto);
        ClienteDto Editar(ClienteDto clienteAtualizado);
        bool Excluir(int id);
    }
}
