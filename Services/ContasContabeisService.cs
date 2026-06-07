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
    public class ContasContabeisService
    {
        public async Task ExecutarAsync()
        {
            string token = TokenProvider.ObterToken();
            var todosContasContabeis = new List<ContasContabeis>();
            int inicioContasContabeis = 0;
            int quantidadeContasContabeis = 300;
            bool continuarContasContabeis = true;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Cookie", "LB=erp02");

            while (continuarContasContabeis)
            {
                var url = $"https://integrador.varejonline.com.br/apps/api/conta-contabil?inicio={inicioContasContabeis}&quantidade={quantidadeContasContabeis}&token={token}";
                var jsonBody = $"{{\"token\":\"{token}\"}}";
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                Console.WriteLine($"Requisitando cadastro de Contas Contabeis a partir do ID {inicioContasContabeis}.Por favor aguarde...");

                var response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lancamentosContasContabeis = ConversorJsonContasContabeis.Converter(json);

                    Console.WriteLine($"Requisitando mais cadastros de conta contabeis a partir do ID {lancamentosContasContabeis.FirstOrDefault()?.IdContaContabil}. Por favor aguarde...");

                    todosContasContabeis.AddRange((IEnumerable<ContasContabeis>)lancamentosContasContabeis);

                    if (lancamentosContasContabeis.Count < quantidadeContasContabeis)
                    {
                        continuarContasContabeis = false;
                    }
                    else
                    {
                        inicioContasContabeis += quantidadeContasContabeis;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    Console.WriteLine($"Conteúdo do erro: {errorContent}");
                    continuarContasContabeis = false;

                }
            }


            Console.WriteLine($"Cadastro de Terceiros Total acumulado: {todosContasContabeis.Count}");
            ExportadorCsv.ExportarContasContabeis(todosContasContabeis);

        }
    }
}
