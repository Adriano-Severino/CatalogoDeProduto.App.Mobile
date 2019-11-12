using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.Services
{
    public class MockDataStore : IDataStore<Categoria>
    {
        readonly List<Categoria> categorias;

        public MockDataStore()
        {
            categorias = new List<Categoria>()
            {
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "First item", Description="This is an item description." },
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "Second item", Description="This is an item description." },
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "Third item", Description="This is an item description." },
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "Fourth item", Description="This is an item description." },
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "Fifth item", Description="This is an item description." },
                new Categoria { Id = Guid.NewGuid().ToString(), Titulo = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Categoria categoria)
        {
            categorias.Add(categoria);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Categoria categoria)
        {
            var oldItem = categorias.Where((Categoria arg) => arg.Id == categoria.Id).FirstOrDefault();
            categorias.Remove(oldItem);
            categorias.Add(categoria);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = categorias.Where((Categoria arg) => arg.Id == id).FirstOrDefault();
            categorias.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Categoria> GetItemAsync(string id)
        {
            return await Task.FromResult(categorias.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Categoria>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categorias);
        }
    }
}