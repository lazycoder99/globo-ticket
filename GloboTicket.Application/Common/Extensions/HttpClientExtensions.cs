using System.Text;
using Newtonsoft.Json;

namespace GloboTicket.Application.Common.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<(HttpResponseMessage message, string body)> PostRequestAsync<T>(
            this HttpClient httpClient, string url, T model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            var body = await response.Content.ReadAsStringAsync();

            return (response, body);
        }

        public static async Task<(HttpResponseMessage message, string body)> GetRequestAsync(
            this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            return (response, body);
        }

        public static async Task<(HttpResponseMessage message, string body)> DeleteRequestAsync(
            this HttpClient httpClient, string url)
        {
            var response = await httpClient.DeleteAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            return (response, body);
        }
    }
}
