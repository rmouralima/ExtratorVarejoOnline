using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Models
{
    public class Terceiro
    {
        [JsonPropertyName("id")]
        public int IdTerceiro { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeTerceiro { get; set; }
        [JsonPropertyName("nomeFantasia")]
        public string? NomeFantasiaTerceiro { get; set; }
        [JsonPropertyName("padraoNome")]
        public string? NomePadraoTerceiro { get; set; }
        [JsonPropertyName("documento")]
        public string? DocumentoTerceiro { get; set; }
        [JsonPropertyName("tipoPessoa")]
        public string? TipoTerceiro { get; set; }
    }
}
