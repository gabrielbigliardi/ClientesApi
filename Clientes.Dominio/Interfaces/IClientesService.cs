using Clientes.Contrato.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Dominio.Interfaces
{
    public interface IClientesService
    {
        // Métodos de negócio relacionados à entidade Cliente
        List<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
        Cliente Adicionar(Cliente cliente);
        Cliente Editar(int id, Cliente cliente);
        bool Excluir(int id);
    }
}
