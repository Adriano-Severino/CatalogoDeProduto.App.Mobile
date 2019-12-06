using System;

using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class ProdutoDetailViewModel : BaseViewModel
    {
        public Produto Produto { get; set; }
        public ProdutoDetailViewModel(Produto produto = null)
        {
            Title = produto?.Titulo;
            Produto = produto;
        }
    }
}