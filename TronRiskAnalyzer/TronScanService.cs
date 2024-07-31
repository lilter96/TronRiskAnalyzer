using System.Text.Json;

namespace TronRiskAnalyzer
{
    public class TronScanService(HttpClient httpClient)
    {
        public async Task<TransactionInfo> GetTransactionInfoAsync(string transactionHash)
        {
            var url = $"https://apilist.tronscan.org/api/transaction-info?hash={transactionHash}";
            HttpResponseMessage response;

            try
            {
                response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync($"Ошибка при получении данных: {ex.Message}");
                throw;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transactionInfo = JsonSerializer.Deserialize<TransactionInfo>(jsonResponse);

            return transactionInfo;
        }
    }
}
