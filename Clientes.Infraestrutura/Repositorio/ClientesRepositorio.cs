using AutoMapper;
using Clientes.Dominio.Entidades;
using Clientes.Infraestrutura.Dto;
using Clientes.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clientes.Infraestrutura.Repositorio
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private readonly IMapper _mapper;

        public ClientesRepositorio(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ClienteDto> ObterTodos()
        {
            string caminho = @"C:\Users\gabri\OneDrive\Documentos\Católica\PI-IV-B\clientes.json";

            // Verifica se o arquivo existe
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            // Lê o conteúdo do arquivo JSON
            var json = File.ReadAllText(caminho);

            // Define uma estrutura para deserialização do arquivo JSON
            //var dados = JsonSerializer.Deserialize<DadosClientes>(json, new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //});
            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);

            // Mapeia a lista de ClienteDto para Cliente
            var clientes = _mapper.Map<List<ClienteDto>>(dados.Clientes);

            return clientes;
        }

        //public class DadosClientes
        //{
        //    public List<ClienteDto>? Clientes { get; set; }
        //}

        //private readonly string _jsonFilePath;

        //public ClienteRepositorio(IConfiguration configuration)
        //{
        //    _jsonFilePath = configuration.GetValue<string>("JsonFilePath");
        //}

        //public IEnumerable<Cliente> ObterTodos()
        //{
        //    if (!File.Exists(_jsonFilePath))
        //        throw new FileNotFoundException("Arquivo JSON não encontrado.");

        //    var json = File.ReadAllText(_jsonFilePath);
        //    var data = JsonSerializer.Deserialize<List<Cliente>>(json);
        //    return data;
        //}

        //public Cliente ObterPorId(int id)
        //{
        //    var clientes = ObterTodos();
        //    return clientes.FirstOrDefault(c => c.ClienteId == id);
        //}

        //public void Adicionar(Cliente cliente)
        //{
        //    var clientes = ObterTodos().ToList();
        //    clientes.Add(cliente);

        //    Salvar(clientes);
        //}

        //public void Editar(Cliente clienteAtualizado)
        //{
        //    var clientes = ObterTodos().ToList();
        //    var index = clientes.FindIndex(c => c.ClienteId == clienteAtualizado.ClienteId);

        //    if (index == -1)
        //        throw new Exception("Cliente não encontrado.");

        //    clientes[index] = clienteAtualizado;
        //    Salvar(clientes);
        //}

        //public void Excluir(int id)
        //{
        //    var clientes = ObterTodos().ToList();
        //    var cliente = clientes.FirstOrDefault(c => c.ClienteId == id);

        //    if (cliente == null)
        //        throw new Exception("Cliente não encontrado.");

        //    clientes.Remove(cliente);
        //    Salvar(clientes);
        //}

        //private void Salvar(IEnumerable<Cliente> clientes)
        //{
        //    var jsonClientes = new JsonClientes { Clientes = clientes.ToList() };
        //    var json = JsonSerializer.Serialize(jsonClientes);
        //    File.WriteAllText(_jsonFilePath, json);
        //}
    }
}
