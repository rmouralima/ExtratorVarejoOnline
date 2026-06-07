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
    public class TerceiroServices
    {
        public async Task ExecutarAsync()
        {
            string token = TokenProvider.ObterToken();
            var todosTerceiros = new List<Terceiro>();
            int inicioTerceiros = 0;
            int quantidadeTerceiros = 300;
            bool continuarTerceiros = true;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Cookie", "LB=erp02");

            while (continuarTerceiros)
            {
                var url = $"https://integrador.varejonline.com.br/apps/api/terceiros?inicio={inicioTerceiros}&quantidade={quantidadeTerceiros}&token={token}";
                var jsonBody = $"{{\"token\":\"{token}\"}}";
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                Console.WriteLine($"Requisitando cadastro de Terceiros a partir do ID {inicioTerceiros}.Por favor aguarde...");

                var response = await client.GetAsync(url);


                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lancamentosTerceiros = ConversorJsonTerceiros.Converter(json);

                    Console.WriteLine($"Requisitando mais cadastros de terceiros a partir do ID {lancamentosTerceiros.FirstOrDefault()?.IdTerceiro}. Por favor aguarde...");

                    todosTerceiros.AddRange(lancamentosTerceiros);

                    if (lancamentosTerceiros.Count < quantidadeTerceiros)
                    {
                        continuarTerceiros = false;
                    }
                    else
                    {
                        inicioTerceiros += quantidadeTerceiros;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    Console.WriteLine($"Conteúdo do erro: {errorContent}");
                    continuarTerceiros = false;

                }
            }


            Console.WriteLine($"Cadastro de Terceiros Total acumulado: {todosTerceiros.Count}");
            ExportadorCsv.ExportarTerceiros(todosTerceiros);

        }
    }
}
