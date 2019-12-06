using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.ViewModels;

namespace CatalogoDeProduto.App.Mobile.Views.Categoria
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CategoriaDetailPage : ContentPage
    {
        CategoriaDetailViewModel viewModel;

        public CategoriaDetailPage(CategoriaDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public CategoriaDetailPage()
        {
            InitializeComponent();

            var categoria = new Models.Categoria
            {
                Titulo = "Item 1 categoria",
                Description = "This is an item description categoria."
            };

            viewModel = new CategoriaDetailViewModel(categoria);
            BindingContext = viewModel;
        }
    }
}