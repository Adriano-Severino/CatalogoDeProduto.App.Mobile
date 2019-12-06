using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.ViewModels;

namespace CatalogoDeProduto.App.Mobile.Views.Produto
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ProdutoDetailPage : ContentPage
    {
        ProdutoDetailViewModel viewModel;

        public ProdutoDetailPage(ProdutoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ProdutoDetailPage()
        {
            InitializeComponent();

            var produto = new Models.Produto
            {
                Titulo = "Item 1 produto",
                Description = "This is an item description categoria."
            };

            viewModel = new ProdutoDetailViewModel(produto);
            BindingContext = viewModel;
        }
    }
}