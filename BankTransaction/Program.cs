using BankingTransactions;
using BankingTransactions.Interfaces;
using BankingTransactions.Repositories;
using BankingTransactions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Configuração da injeção de dependência
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Exemplo de uso de Func
        Func<int, int, int> add = (x, y) => x + y;
        int result = add(3, 4);
        Console.WriteLine($"Resultado da soma usando Func: {result}");  // Saída: 7

        // Exemplo de uso de Task
        await ProcessTransactionsAsync();

        // Exemplo de uso de TransactionService
        var transactionService = serviceProvider.GetService<ITransactionService>();

        try
        {
            await transactionService.DepositAsync(1, 100);
            await transactionService.WithdrawAsync(1, 50);
            await transactionService.TransferAsync(1, 2, 25);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<BankingContext>(options =>
            options.UseInMemoryDatabase("BankingDatabase"));

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransactionService, TransactionService>();
    }

    private static async Task ProcessTransactionsAsync()
    {
        await Task.Run(() =>
        {
            // Simulação de processamento de transações
            Console.WriteLine("Processando transações...");
        });
    }
}
