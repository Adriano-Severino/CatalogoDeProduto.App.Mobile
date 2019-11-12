using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.Services
{
    public class AzureDataStore : IDataStore<Categoria>
    {
        HttpClient client;
        IEnumerable<Categoria> categorias;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            categorias = new List<Categoria>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Categoria>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"categorias");
                categorias = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Categoria>>(json));
            }

            return categorias;
        }

        public async Task<Categoria> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"categorias/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Categoria>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Categoria categoria)
        {
            if (categoria == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(categoria);

            var response = await client.PostAsync($"categorias", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Categoria categoria)
        {
            if (categoria == null || categoria.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(categoria);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"categorias/{categoria.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"categorias/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
