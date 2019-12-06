using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatalogoDeProduto.App.Mobile.Models;
using CatalogoDeProduto.App.Mobile.Views.Categoria;
using CatalogoDeProduto.App.Mobile.ViewModels;

namespace CatalogoDeProduto.App.Mobile.Views.Produto
{
    [DesignTimeVisible(false)]
    public partial class ProdutoPage : ContentPage
    {
        ProdutoViewModel viewModel;

        public ProdutoPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProdutoViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var produto = args.SelectedItem as Models.Produto;
            if (produto == null)
                return;

            await Navigation.PushAsync(new ProdutoDetailPage(new ProdutoDetailViewModel(produto)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NovoProdutoPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Produtos.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}