using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Models
{
    public class ContasContabeis
    {
        [JsonPropertyName("id")]
        public int IdContaContabil { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeContaContabil { get; set; }

        [JsonPropertyName("acesso")]
        public string? AcessoContaContabil { get; set; }

        [JsonPropertyName("natureza")]
        public string? NaturezaContaContabil { get; set; }

        [JsonPropertyName("tipoConta")]
        public string? TipoContaContabil { get; set; }

        [JsonPropertyName("classificador")]
        public string? ClassificadorContaContabil { get; set; }

        [JsonPropertyName("contaAcessoExterna")]
        public string? ContaAcessoExternaContaContabil { get; set; }
    }    
}
