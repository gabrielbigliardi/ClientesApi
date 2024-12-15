using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clientes.Aplicacao.Dtos
{
    public class ClienteDto
    {
        [JsonPropertyName("cliente_id")]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        [JsonPropertyName("data_nascimento")]
        public DateOnly DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
