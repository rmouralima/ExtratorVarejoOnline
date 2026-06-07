using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Models
{
    public class ContasReceber
    {
        [JsonPropertyName("id")]
        public int IdContasReceber { get; set; }

        [JsonPropertyName("entidade")]
        public EntidadeContasReceber EntidadeContasReceber { get; set; }

        [JsonPropertyName("terceiro")]
        public TerceiroContasReceber TerceiroContasReceber { get; set; }

        [JsonPropertyName("dataVencimento")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime VencimentoContasReceber { get; set; }

        [JsonPropertyName("valor")]
        public decimal ValorContasReceber { get; set; }

        [JsonPropertyName("dataEmissao")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime EmissaoContasReceber { get; set; }

        [JsonPropertyName("numeroParcela")]
        public int ParcelaContasReceber { get; set; }

        [JsonPropertyName("totalParcelas")]
        public int TotalParcelasContasReceber { get; set; }

        [JsonPropertyName("valorTotalParcelas")]
        public decimal ValorTotalContasReceber { get; set; }

        [JsonPropertyName("numeroDocumento")]
        public string? NumeroDocumentoContasReceber { get; set; }

        [JsonPropertyName("tipoDocumento")]
        public string? TipoDocumentoContasReceber { get; set; }

        [JsonPropertyName("baixada")]
        public bool BaixaContasReceber { get; set; }

        [JsonPropertyName("valorBaixado")]
        public decimal ValorBaixadoContasReceber { get; set; }

        [JsonPropertyName("dataBaixa")]
        [JsonConverter(typeof(Utils.DateTimeCustomConverter))]
        public DateTime DataBaixaContasReceber { get; set; }

        [JsonPropertyName("contaContabilCredito")]
        public string? ContaContabilCreditoContasReceber { get; set; }

        [JsonPropertyName("classificacoesContabeis")]
        public List<ClassContabeisContasReceber> ClassificacoesContabeisContasReceber { get; set; } = new();

    }

    public class EntidadeContasReceber
    {
        [JsonPropertyName("id")]
        public int IdEntidadeContasReceber { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeEntidadeContasReceber { get; set; }
    }

    public class TerceiroContasReceber
    {
        [JsonPropertyName("id")]
        public int IdTerceiroContasReceber { get; set; }
        [JsonPropertyName("nome")]
        public string? NomeTerceiroContasReceber { get; set; }
    }

    public class ClassContabeisContasReceber
    {
        [JsonPropertyName("contaContabil")]
        public string? contaContabilContasReceber { get; set; }
        [JsonPropertyName("porcentagemApropriada")]
        public decimal porcentagemApropriadaContasReceber { get; set; }
    }


}
