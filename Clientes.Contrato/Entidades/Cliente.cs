using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clientes.Dominio.Entidades
{
    public class Cliente
    {
        //[JsonPropertyName("cliente_id")]
        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Cep { get; private set; }
        //[JsonPropertyName("data_nascimento")]
        public DateOnly DataNascimento { get; private set; }
        public string Telefone { get; private set; }

        //public Cliente(int clienteId, string nome, string endereco, string cep, DateOnly dataNascimento, string telefone)
        //{
        //    //if (string.IsNullOrWhiteSpace(nome))
        //    //    throw new ArgumentException("O nome é obrigatório.");

        //    ClienteId = clienteId;
        //    Nome = nome;
        //    Endereco = endereco;
        //    Cep = cep;
        //    DataNascimento = dataNascimento;
        //    Telefone = telefone;
        //}

        //public void Atualizar(Cliente clienteAtualizado)
        //{
        //    if (clienteAtualizado == null)
        //        throw new ArgumentNullException(nameof(clienteAtualizado));

        //    Nome = clienteAtualizado.Nome ?? Nome;
        //    Endereco = clienteAtualizado.Endereco ?? Endereco;
        //    Cep = clienteAtualizado.Cep ?? Cep;
        //    DataNascimento = clienteAtualizado.DataNascimento != default ? clienteAtualizado.DataNascimento : DataNascimento;
        //    Telefone = clienteAtualizado.Telefone ?? Telefone;
        //}
    }
}
