using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoDeProduto.App.Mobile.Models
{
   public class Categoria
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

       public IEnumerable<Produto> Produto { get; set; }

        public string Description { get; set; }
       
    }
}
