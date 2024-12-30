
using static System.Net.WebRequestMethods;

namespace KadelDemo.Services
{
    public class KadelPropertyServiceMock : IKadelPropertyService
    {
        private PropertyItem[] properties;
        private readonly HttpClient _httpClient;

        public KadelPropertyServiceMock(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<List<PropertyItem>> GetPropertyAsync()
        {            
            //Mock server url - https://ab6bcd3c-2916-4675-a79d-5cdf69448852.mock.pstmn.io
            var response = await _httpClient.GetAsync("https://ab6bcd3c-2916-4675-a79d-5cdf69448852.mock.pstmn.io/getkadelproperty");
            response.EnsureSuccessStatusCode();
            var properties = await response.Content.ReadFromJsonAsync<IEnumerable<PropertyItem>>();
            return properties?.ToList()!;            
        }
        
    }
}
