using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.Views.Categoria;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CategoriaViewModel()
        {
            Title = "Browse";
            Categorias = new ObservableCollection<Categoria>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NovaCategoriaPage, Categoria>(this, "AddCategoria", async (obj, categoria) =>
            {
                var novaCategoria = categoria as Categoria;
                Categorias.Add(novaCategoria);
                await CategoriaDataStore.AddItemAsync(novaCategoria);
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
                var categorias = await CategoriaDataStore.GetItemsAsync(true);
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