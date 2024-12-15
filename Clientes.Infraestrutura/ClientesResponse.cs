using Clientes.Infraestrutura.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clientes.Infraestrutura
{
    public class ClienteResponse
    {
        [JsonPropertyName("clientes")]
        public List<ClienteDto> Clientes { get; set; }
    }
}
