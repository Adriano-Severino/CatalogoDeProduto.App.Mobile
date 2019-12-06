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

namespace CatalogoDeProduto.App.Mobile.Views.Categoria
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CategoriaPage : ContentPage
    {
        CategoriaViewModel viewModel;

        public CategoriaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriaViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categoria = args.SelectedItem as Models.Categoria;
            if (categoria == null)
                return;

            await Navigation.PushAsync(new CategoriaDetailPage(new CategoriaDetailViewModel(categoria)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NovaCategoriaPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categorias.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}