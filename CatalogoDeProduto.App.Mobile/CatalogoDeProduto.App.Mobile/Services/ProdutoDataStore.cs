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
    public class ProdutoDataStore : IDataStore<Produto>
    {
        HttpClient client;
        IEnumerable<Produto> produtos;

        public ProdutoDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            produtos = new List<Produto>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Produto>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"produtos");
                produtos = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Produto>>(json));
            }

            return produtos;
        }

        public async Task<Produto> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"produtos/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Produto>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Produto produto)
        {
            if (produto == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(produto);

            var response = await client.PostAsync($"produtos", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Produto produto)
        {
            if (produto == null ||produto.Id == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(produto);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"produtos/{produto.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"produtos/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
