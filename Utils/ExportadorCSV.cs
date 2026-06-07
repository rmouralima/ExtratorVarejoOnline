using ExtratorVarejoOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ExtratorVarejoOnline.Utils
{
    public static class ExportadorCsv
    {
        public static void ExportarContasReceber(List<ContasReceber> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("A lista está vazia ou nula. Nenhum dado para exportar.");
            var sb = new StringBuilder();

            sb.AppendLine("IdContasReceber;" +
                "IdEntidadeContasReceber;" +
                "NomeEntidadeContasReceber;" +
                "IdTerceiroContasReceber;" +
                "NomeTerceiroContasReceber;" +
                "VencimentoContasReceber;" +
                "ValorContasReceber;" +
                "EmissaoContasReceber;" +
                "ParcelaContasReceber;" +
                "TotalParcelasContasReceber;" +
                "ValorTotalContasReceber;" +
                "NumeroDocumentoContasReceber;" +
                "TipoDocumentoContasReceber;" +
                "BaixaContasReceber;" +
                "ValorBaixadoContasReceber," +
                "DataBaixaContasReceber,"
                /*"ContaContabilCreditoContasReceber"*/);


            string FormatarCampo(string valor) =>
                "\"" + valor.Replace("\"", "\"\"") + "\"";

            //string classContabeis = string.Join(" | ", c.ClassificacoesContabeisContasReceber.Select(cc =>
            //    $"{cc.contaContabilContasReceber} ({cc.porcentagemApropriadaContasReceber})"));


            foreach (var c in lista)
            {
                sb.AppendLine(string.Join(";", new[]
                {
                    FormatarCampo(c.IdContasReceber.ToString()),
                    FormatarCampo(c.EntidadeContasReceber?.IdEntidadeContasReceber.ToString() ?? ""),
                    FormatarCampo(c.EntidadeContasReceber?.NomeEntidadeContasReceber ?? ""),
                    FormatarCampo(c.TerceiroContasReceber?.IdTerceiroContasReceber.ToString() ?? ""),
                    FormatarCampo(c.TerceiroContasReceber?.NomeTerceiroContasReceber ?? ""),
                    c.VencimentoContasReceber.ToString("dd/MM/yyyy"),
                    FormatarCampo(c.ValorContasReceber.ToString("F2")),
                    c.EmissaoContasReceber.ToString("dd/MM/yyyy"),
                    FormatarCampo(c.ParcelaContasReceber.ToString()),
                    FormatarCampo(c.TotalParcelasContasReceber.ToString()),
                    FormatarCampo(c.ValorTotalContasReceber.ToString("F2")),
                    FormatarCampo(c.NumeroDocumentoContasReceber ?? ""),
                    FormatarCampo(c.TipoDocumentoContasReceber ?? ""),
                    c.BaixaContasReceber ? "Sim" : "Não",
                    FormatarCampo(c.ValorBaixadoContasReceber.ToString("F2")),
                    c.DataBaixaContasReceber.ToString("dd/MM/yyyy"),
                    //FormatarCampo(classContabeis),
                }));
            }

            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportações");
            Directory.CreateDirectory(pasta);
            string nomeArquivo = "ContasReceber.csv";
            string caminho = Path.Combine(pasta, nomeArquivo);
            File.WriteAllText(caminho, sb.ToString(), new UTF8Encoding(true));
            Console.WriteLine($"Recebi {lista.Count} itens para exportar do Contas a Receber.");
            Console.WriteLine("Iniciando criação do arquivo CSV do Contas a Receber...");
            Console.WriteLine("Arquivo CSV do Contas a Receber gerado com sucesso na pasta Exportações!!!");



        }

        public static void ExportarContasaPagar(List<ContasPagar> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("A lista está vazia ou nula. Nenhum dado para exportar.");
            var sb = new StringBuilder();


            sb.AppendLine("IdContasPagar;" +
                "IdEntidadeContasPagar;" +
                "EntidadeContasPagar;" +
                "IdTerceiroContasPagar;" +
                "TerceiroContasPagar;" +
                "VencimentoContasPagar;" +
                "ValorContasPagar;" +
                "EmissaoContasPagar;" +
                "ParcelaContasPagar;" +
                "TotalParcelasContasPagar;" +
                "ValorTotalContasPagar;" +
                "NumeroDocumentoContasPagar;" +
                "TipoDocumentoContasPagar;" +
                "BaixaContasPagar;" +
                "ValorBaixaContasPagar;" +
                "DataBaixaContasPagar"
                );
            string FormatarCampo(string valor) =>
                 "\"" + valor.Replace("\"", "\"\"") + "\"";

            foreach (var c in lista)
            {
                sb.AppendLine(string.Join(";", new[]
                {
                    FormatarCampo(c.IdContasPagar.ToString()),
                    FormatarCampo(c.EntidadeContasPagar?.IdEntidadeContasPagar.ToString() ?? ""),
                    FormatarCampo(c.EntidadeContasPagar?.NomeEntidadeContasPagar ?? ""),
                    FormatarCampo(c.TerceiroContasPagar?.IdTerceiroContasPagar.ToString() ?? ""),
                    FormatarCampo(c.TerceiroContasPagar?.NomeTerceiroContasPagar ?? ""),
                    c.VencimentoContasPagar.ToString("dd/MM/yyyy"),
                    FormatarCampo(c.ValorTotalContasPagar.ToString("F2")),
                    c.EmissaoContasPagar.ToString("dd/MM/yyyy"),
                    FormatarCampo(c.ParcelaContasPagar.ToString()),
                    FormatarCampo(c.TotalParcelasContasPagar.ToString()),
                    FormatarCampo(c.ValorTotalContasPagar.ToString("F2")),
                    FormatarCampo(c.NumeroDocumentoContasPagar ?? ""),
                    FormatarCampo(c.TipoDocumentoContasPagar ?? ""),
                    c.BaixaContasPagar ? "Sim" : "Não",
                    FormatarCampo(c.ValorBaixaContasPagar.ToString("F2")),
                    c.DataBaixaContasPagar.ToString("dd/MM/yyyy")
                    ,
                }));
            }
            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportações");
            Directory.CreateDirectory(pasta);
            string nomeArquivo = "ContasPagar.csv";
            string caminho = Path.Combine(pasta, nomeArquivo);
            File.WriteAllText(caminho, sb.ToString(), new UTF8Encoding(true));
            Console.WriteLine($"Recebi {lista.Count} itens para exportar do Contas a Pagar.");
            Console.WriteLine("Iniciando criação do arquivo CSV do Contas a Pagar...");
            Console.WriteLine("Arquivo CSV do Contas a Pagar gerado com sucesso na pasta Exportações!!!");



        }

        public static void ExportarTerceiros(List<Terceiro> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("A lista está vazia ou nula. Nenhum dado para exportar.");
            var sb = new StringBuilder();


            sb.AppendLine("IdTerceiro;" +
                "NomeTerceiro;" +
                "NomeFantasiaTerceiro;" +
                "NomePadraoTerceiro;" +
                "DocumentoTerceiro;" +
                "TipoTerceiro");
            string FormatarCampo(string valor) =>
                 "\"" + valor.Replace("\"", "\"\"") + "\"";

            foreach (var c in lista)
            {
                sb.AppendLine(string.Join(";", new[]
                {
                    FormatarCampo(c.IdTerceiro.ToString()),
                    FormatarCampo(c.NomeTerceiro?.ToString() ?? ""),
                    FormatarCampo(c.NomeFantasiaTerceiro?.ToString() ?? ""),
                    FormatarCampo(c.NomePadraoTerceiro?.ToString() ?? ""),
                    FormatarCampo(c.DocumentoTerceiro?.ToString()  ?? ""),
                    FormatarCampo(c.TipoTerceiro?.ToString()  ?? ""),
                }));
            }
            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportações");
            Directory.CreateDirectory(pasta);
            string nomeArquivo = "Terceiros.csv";
            string caminho = Path.Combine(pasta, nomeArquivo);
            File.WriteAllText(caminho, sb.ToString(), new UTF8Encoding(true));
            Console.WriteLine($"Recebi {lista.Count} itens para exportar de Terceiros.");
            Console.WriteLine("Iniciando criação do arquivo CSV do Terceiros...");
            Console.WriteLine("Arquivo CSV do Terceiros gerado com sucesso na pasta Exportações!!!");

        }

        public static void ExportarContasContabeis(List<ContasContabeis> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("A lista está vazia ou nula. Nenhum dado para exportar.");
            var sb = new StringBuilder();


            sb.AppendLine("IdContaContabil;" +
                "NomeContaContabil;" +
                "AcessoContaContabil;" +
                "NaturezaContaContabil;" +
                "TipoContaContabil;" +
                "ClassificadorContaContabil;" +
                "ContaAcessoExternaContaContabil");


            string FormatarCampo(string valor) =>
                 "\"" + valor.Replace("\"", "\"\"") + "\"";


            foreach (var c in lista)
            {
                sb.AppendLine(string.Join(";", new[]
                {
                    FormatarCampo(c.IdContaContabil.ToString()),
                    FormatarCampo(c.NomeContaContabil?.ToString() ?? ""),
                    FormatarCampo(c.NaturezaContaContabil?.ToString() ?? ""),
                    FormatarCampo(c.TipoContaContabil?.ToString() ?? ""),
                    FormatarCampo(c.ClassificadorContaContabil?.ToString()  ?? ""),
                    FormatarCampo(c.ContaAcessoExternaContaContabil?.ToString()  ?? ""),
                }));
            }
            string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exportações");
            Directory.CreateDirectory(pasta);
            string nomeArquivo = "ContasContabeis.csv";
            string caminho = Path.Combine(pasta, nomeArquivo);
            File.WriteAllText(caminho, sb.ToString(), new UTF8Encoding(true));
            Console.WriteLine($"Recebi {lista.Count} itens para exportar de Contas Contabeis.");
            Console.WriteLine("Iniciando criação do arquivo CSV do Contas Contabeis...");
            Console.WriteLine("Arquivo CSV do Contas Contabeis gerado com sucesso na pasta Exportações!!!");

        }
    }


}
