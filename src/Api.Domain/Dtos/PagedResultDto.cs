using System.Text.Json.Serialization;
using Api.Domain.Dtos.Field;

namespace Api.Domain.Dtos
{
    public class PagedResultDto<T>
    {
        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10;

        [JsonPropertyName("hasNext")]
        public bool HasNext { get; set; } = true;
    }
}