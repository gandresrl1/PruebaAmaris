using System.Net.Http.Json;

namespace DAL.Utilities
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetDataAsync<T>(string url)
        {
            T? data = default;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode) 
                {
                    data = await response.Content.ReadFromJsonAsync<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return data;
        }
    }
}
