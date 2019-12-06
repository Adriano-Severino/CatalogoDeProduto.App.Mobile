using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.Views.Produto;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public ObservableCollection<Produto> Produtos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ProdutoViewModel()
        {
            Title = "Browse";
            Produtos = new ObservableCollection<Produto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NovoProdutoPage, Produto>(this, "AddProduto", async (obj, produto) =>
            {
                var novoProduto = produto as Produto;
                Produtos.Add(novoProduto);
                await ProdutoDataStore.AddItemAsync(novoProduto);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Produtos.Clear();
                var produtos = await ProdutoDataStore.GetItemsAsync(true);
                foreach (var item in produtos)
                {
                    Produtos.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}