using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Models
{
    public class ContasPagar
    {
        [JsonPropertyName("id")]
        public int IdContasPagar { get; set; }

        [JsonPropertyName("entidade")]
        public EntidadeContasPagar EntidadeContasPagar { get; set; }

        [JsonPropertyName("terceiro")]
        public TerceiroContasPagar TerceiroContasPagar { get; set; }

        [JsonPropertyName("dataVencimento")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime VencimentoContasPagar { get; set; }

        [JsonPropertyName("valor")]
        public decimal ValorContasPagar { get; set; }

        [JsonPropertyName("dataEmissao")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime EmissaoContasPagar { get; set; }

        [JsonPropertyName("numeroParcela")]
        public int ParcelaContasPagar { get; set; }

        [JsonPropertyName("totalParcelas")]
        public int TotalParcelasContasPagar { get; set; }

        [JsonPropertyName("valorTotalParcelas")]
        public decimal ValorTotalContasPagar { get; set; }

        [JsonPropertyName("numeroDocumento")]
        public string? NumeroDocumentoContasPagar { get; set; }

        [JsonPropertyName("tipoDocumento")]
        public string? TipoDocumentoContasPagar { get; set; }

        [JsonPropertyName("baixada")]
        public bool BaixaContasPagar { get; set; }

        [JsonPropertyName("valorBaixado")]
        public decimal ValorBaixaContasPagar { get; set; }

        [JsonPropertyName("dataBaixa")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime DataBaixaContasPagar { get; set; }

        [JsonPropertyName("contaContabilCredito")]
        public string? ContaContabilCreditoContasPagar { get; set; }

        [JsonPropertyName("classificacoesContabeis")]
        public List<ClassContabeisContasPagar> ClassificacoesContabeisContasPagar { get; set; } = new();
    }

    public class EntidadeContasPagar
    {
        [JsonPropertyName("id")]
        public int IdEntidadeContasPagar { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeEntidadeContasPagar { get; set; }
    }

    public class TerceiroContasPagar
    {
        [JsonPropertyName("id")]
        public int IdTerceiroContasPagar { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeTerceiroContasPagar { get; set; }
    }

    public class ClassContabeisContasPagar
    {
        [JsonPropertyName("contaContabil")]
        public string? contaContabilContasPagar { get; set; }
        [JsonPropertyName("porcentagemApropriada")]
        public decimal porcentagemApropriadaContasPagar { get; set; }
    }
}
