using ExtratorVarejoOnline.Services;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            await ExecutarServicosAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Encerrando execução.");
        }
    }

    private static async Task ExecutarServicosAsync()
    {
        Console.WriteLine("Iniciando exportações do Contas a receber...");
        var contasReceberService = new ContasReceberService();
        await contasReceberService.ExecutarAsync();
        Console.WriteLine("Exportações do Contas a Receber finalizado!");

        Console.WriteLine("Iniciando exportações do Contas a Pagar...");
        var contasPagarService = new ContasPagarService();
        await contasPagarService.ExecutarAsync();
        Console.WriteLine("Exportações do Contas a Pagar finalizado!");

        Console.WriteLine("Iniciando exportações do cadastro de Terceiros...");
        var TerceirosService = new TerceiroServices();
        await TerceirosService.ExecutarAsync();
        Console.WriteLine("Exportações do Contas a Pagar finalizado!");

        Console.WriteLine("Iniciando exportações do cadastro de Contas Contabeis...");
        var ContasContabeisService = new ContasContabeisService();
        await TerceirosService.ExecutarAsync();
        Console.WriteLine("Exportações das Contas Contabeis finalizado!");

        Console.WriteLine("Arquivos Exportados com sucesso na Pasta Exportações!");
        Console.WriteLine($"Arquivo gerado: {Path.Combine(Environment.CurrentDirectory, "Exportações")}");
        Console.WriteLine("Processo concluído com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}


