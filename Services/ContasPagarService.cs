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
    public class ContasPagarService
    {

        public async Task ExecutarAsync()
        {
            string token = TokenProvider.ObterToken();
            var todasContasPagar = new List<ContasPagar>();
            int inicioContasPagar = 0;
            int quantidadeContasPagar = 300;
            bool continuarContasPagar = true;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Cookie", "LB=erp02");


            while (continuarContasPagar)
            {
                var url = $"https://integrador.varejonline.com.br/apps/api/contas-pagar/?inicio={inicioContasPagar}&quantidade={quantidadeContasPagar}&token={token}";
                var jsonBody = $"{{\"token\":\"{token}\"}}";
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");



                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lancamentosContasPagar = ConversorJsonContasPagar.Converter(json);


                    Console.WriteLine($"Requisitando lançamentos de Contas a Pagar a partir do titulo {lancamentosContasPagar.FirstOrDefault()?.IdContasPagar}. Por favor aguarde...");


                    todasContasPagar.AddRange(lancamentosContasPagar);

                    if (lancamentosContasPagar.Count < quantidadeContasPagar)
                    {
                        continuarContasPagar = false;
                    }
                    else
                    {
                        inicioContasPagar += quantidadeContasPagar;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    Console.WriteLine($"Conteúdo do erro: {errorContent}");
                    continuarContasPagar = false;

                }
            }

            Console.WriteLine($"[Contas a Pagar] Total acumulado: {todasContasPagar.Count}");
            ExportadorCsv.ExportarContasaPagar(todasContasPagar);
        }
    }
}
