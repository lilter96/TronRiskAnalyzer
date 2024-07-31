namespace TronRiskAnalyzer
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string transactionHash = string.Empty;

            if (args.Length > 0)
            {
                transactionHash = args[0];
            }
            else
            {
                Console.WriteLine("Хэш транзакции не был передан как аргумент.");
                Console.Write("Пожалуйста, введите хэш транзакции: ");
                transactionHash = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(transactionHash))
                {
                    Console.WriteLine("Хэш транзакции не был введен. Используется дефолтное значение.");
                    transactionHash = "853793d552635f533aa982b92b35b00e63a1c1add062c099da2450a15119bcb2";
                }
            }

            using var httpClient = new HttpClient();
            var tronScanService = new TronScanService(httpClient);

            try
            {
                var transactionInfo = await tronScanService.GetTransactionInfoAsync(transactionHash);
                Console.WriteLine($"Информация о транзакции для хэша {transactionHash}:");
                Console.WriteLine($"Уровень риска: {transactionInfo.Risk}");
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync($"Ошибка при обработке транзакции: {ex.Message}");
            }
        }
    }
}
