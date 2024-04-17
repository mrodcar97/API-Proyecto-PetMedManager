using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.ApiClient.Models;

namespace Veterinaria.ApiClient
{
    public class VeterinariaApiCientServices
    {
        private readonly HttpClient _httpClient;
        public VeterinariaApiCientServices(ApiCientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<Usuario>?> GetUsuarios()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>?>("/api/Usuario");
        }
    }
}
    
