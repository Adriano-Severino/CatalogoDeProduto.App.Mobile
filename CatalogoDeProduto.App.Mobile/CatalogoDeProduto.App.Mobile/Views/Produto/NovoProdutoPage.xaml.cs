using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.Views.Produto
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NovoProdutoPage : ContentPage
    {
        public Models.Produto Produto { get; set; }

        public NovoProdutoPage()
        {
            InitializeComponent();

           Produto = new Models.Produto
            {
                Titulo = "Novo Produto",
                Description = "This is an item description. de produto"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddProduto", Produto);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}