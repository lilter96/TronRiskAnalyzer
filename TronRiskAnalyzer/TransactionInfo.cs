using System.Text.Json.Serialization;

namespace TronRiskAnalyzer
{
    public class TransactionInfo
    {
        [JsonPropertyName("riskTransaction")]
        public bool Risk { get; set; }
    }
}
