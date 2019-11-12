using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.Views;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Categorias = new ObservableCollection<Categoria>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Categoria>(this, "AddCategoria", async (obj, categoria) =>
            {
                var novaCategoria = categoria as Categoria;
                Categorias.Add(novaCategoria);
                await DataStore.AddItemAsync(novaCategoria);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categorias.Clear();
                var categorias = await DataStore.GetItemsAsync(true);
                foreach (var item in categorias)
                {
                   Categorias.Add(item);
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