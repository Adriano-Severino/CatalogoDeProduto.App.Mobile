using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoDeProduto.App.Mobile.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Image { get; set; }

        public int Quantidade { get; set; }

        public DateTime CriarData { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public string Description { get; set; }
    }
}
