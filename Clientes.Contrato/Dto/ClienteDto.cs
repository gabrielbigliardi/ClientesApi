using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clientes.Contrato.Dto
{
    public class ClienteDto
    {
        [JsonPropertyName("cliente_id")]
        public int ClienteId { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("endereco")]
        public string Endereco { get; set; }

        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("data_nascimento")]
        public DateOnly DataNascimento { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }
    }
}
