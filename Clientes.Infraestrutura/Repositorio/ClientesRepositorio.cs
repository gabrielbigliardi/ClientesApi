using AutoMapper;
using Clientes.Contrato.Response;
using Clientes.Contrato.Dto;
using Clientes.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Clientes.Contrato.Entidades;

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

            // Desserializa os dados existentes para ClienteResponse
            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);

            // Mapeia a lista de ClienteDto para Cliente
            var clientes = _mapper.Map<List<ClienteDto>>(dados.Clientes);

            return clientes;
        }

        public ClienteDto ObterPorId(int id)
        {
            string caminho = @"C:\Users\gabri\OneDrive\Documentos\Católica\PI-IV-B\clientes.json";

            // Verifica se o arquivo existe
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            // Lê o conteúdo do arquivo JSON
            var json = File.ReadAllText(caminho);

            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);

            var clientes = _mapper.Map<List<ClienteDto>>(dados.Clientes);

            return clientes.FirstOrDefault(c => c.ClienteId == id); // Retorna o cliente encontrado ou null
        }





        public ClienteDto Adicionar(ClienteDto clienteDto)
        {
            string caminho = @"C:\Users\gabri\OneDrive\Documentos\Católica\PI-IV-B\clientes.json";

            // Verifica se o arquivo existe
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            // Lê o conteúdo do arquivo JSON
            var json = File.ReadAllText(caminho);

            // Desserializa os dados existentes para ClienteResponse
            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);


            // Se não existir dados, cria uma nova lista
            var listaClientes = dados?.Clientes ?? new List<ClienteDto>();

            // Gera um novo ID para o cliente
            clienteDto.ClienteId = listaClientes.Max(c => c.ClienteId) + 1;

            // Adiciona o cliente à lista
            listaClientes.Add(clienteDto);

            // Salva de volta no arquivo JSON
            File.WriteAllText(caminho, JsonSerializer.Serialize(new ClienteResponse { Clientes = listaClientes }));

            // Retorna o cliente com o ID gerado
            return clienteDto;
        }







        public ClienteDto Editar(ClienteDto clienteDto)
        {
            string caminho = @"C:\Users\gabri\OneDrive\Documentos\Católica\PI-IV-B\clientes.json";

            // Verifica se o arquivo existe
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            // Lê o conteúdo do arquivo JSON
            var json = File.ReadAllText(caminho);

            // Desserializa os dados existentes para ClienteResponse
            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);

            // Verifica se a lista de clientes existe
            var listaClientes = dados?.Clientes ?? new List<ClienteDto>();

            // Encontra o cliente existente
            var clienteExistente = listaClientes.FirstOrDefault(c => c.ClienteId == clienteDto.ClienteId);

            if (clienteExistente != null)
            {
                // Substitui o cliente antigo pelos dados atualizados
                listaClientes.Remove(clienteExistente);
                listaClientes.Add(clienteDto);
            }

            // Salva as alterações de volta no arquivo JSON
            File.WriteAllText(caminho, JsonSerializer.Serialize(new ClienteResponse { Clientes = listaClientes }));

            return clienteDto;
        }







        public bool Excluir(int id)
        {
            string caminho = @"C:\Users\gabri\OneDrive\Documentos\Católica\PI-IV-B\clientes.json";

            // Verifica se o arquivo existe
            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            // Lê o conteúdo do arquivo JSON
            var json = File.ReadAllText(caminho);

            var dados = JsonSerializer.Deserialize<ClienteResponse>(json);

            // Verifica se a lista de clientes existe
            var listaClientes = dados?.Clientes ?? new List<ClienteDto>();

            // Busca o cliente que será excluído
            var clienteParaExcluir = listaClientes.FirstOrDefault(c => c.ClienteId == id);

            if (clienteParaExcluir == null)
            {
                return false; // Cliente não encontrado
            }

            // Remove o cliente da lista
            listaClientes.Remove(clienteParaExcluir);

            // Salva as alterações de volta no arquivo JSON
            File.WriteAllText(caminho, JsonSerializer.Serialize(new ClienteResponse { Clientes = listaClientes }));

            return true; // Cliente excluído com sucesso
        }







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
