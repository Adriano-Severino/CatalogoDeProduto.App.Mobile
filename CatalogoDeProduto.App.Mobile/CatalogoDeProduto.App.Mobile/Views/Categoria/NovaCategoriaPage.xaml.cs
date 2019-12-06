using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatalogoDeProduto.App.Mobile.Models;

namespace CatalogoDeProduto.App.Mobile.Views.Categoria
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NovaCategoriaPage : ContentPage
    {
        public Models.Categoria Categoria { get; set; }

        public NovaCategoriaPage()
        {
            InitializeComponent();

            Categoria = new Models.Categoria
            {
                Titulo = "Novo Categoria",
                Description = "This is an item description de categoria."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCategoria", Categoria);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}