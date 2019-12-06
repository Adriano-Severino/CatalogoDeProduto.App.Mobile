using System;

using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.ViewModels
{
    public class CategoriaDetailViewModel : BaseViewModel
    {
        public Categoria Categoria { get; set; }
        public CategoriaDetailViewModel(Categoria categoria = null)
        {
            Title = categoria?.Titulo;
            Categoria = categoria;
        }
    }
}
