using System;

using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Categoria Categoria { get; set; }
        public ItemDetailViewModel(Categoria categoria = null)
        {
            Title = categoria?.Titulo;
            Categoria = categoria;
        }
    }
}
