using ExtratorVarejoOnline.Models;
using ExtratorVarejoOnline.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtratorVarejoOnline.Services
{
    public class ContasReceberService
    {
        public async Task ExecutarAsync()
        {
            string token = TokenProvider.ObterToken();
            var todasContasReceber = new List<ContasReceber>();
            int inicioContasReceber = 0;
            int quantidadeContasReceber = 300;
            bool continuarContasReceber = true;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Cookie", "LB=erp02");

            while (continuarContasReceber)
            {
                var url = $"https://integrador.varejonline.com.br/apps/api/contas-receber/?inicio={inicioContasReceber}&quantidade={quantidadeContasReceber}&token={token}";
                var jsonBody = $"{{\"token\":\"{token}\"}}";
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                //Console.WriteLine($"Requisitando lançamentos de Contas a Pagar a partir do titulo {inicioContasReceber}.Por favor aguarde...");

                var response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lancamentosContasReceber = ConversorJsonContasReceber.Converter(json);

                    //Console.WriteLine($"→ Primeiro ID retornado: {lancamentosContasReceber.FirstOrDefault()?.IdContasReceber}");
                    //Console.WriteLine($"📄 Lançamentos retornados: {lancamentosContasReceber.Count}");
                    Console.WriteLine($"Requisitando lançamentos de Contas a Receber a partir do titulo {lancamentosContasReceber.FirstOrDefault()?.IdContasReceber}. Por favor aguarde...");

                    todasContasReceber.AddRange(lancamentosContasReceber);

                    if (lancamentosContasReceber.Count < quantidadeContasReceber)
                    {
                        continuarContasReceber = false;
                    }
                    else
                    {
                        inicioContasReceber += quantidadeContasReceber;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    Console.WriteLine($"Conteúdo do erro: {errorContent}");
                    continuarContasReceber = false;

                }
            }


            Console.WriteLine($"[Contas a Receber] Total acumulado: {todasContasReceber.Count}");
            ExportadorCsv.ExportarContasReceber(todasContasReceber);

        }
    }
}
