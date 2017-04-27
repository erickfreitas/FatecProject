using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Project.Application.ViewModels
{
    public class ProdutoImagemViewModel
    {
        public ProdutoImagemViewModel()
        {

        }

        public ProdutoImagemViewModel(HttpPostedFileBase imagem, int produtoId)
        {
            ProdutoId = produtoId;
            Destaque = false;
            Caminho = string.Format("~/Images/Products/{0}.{1}", Guid.NewGuid().ToString(), imagem.FileName.Substring(imagem.FileName.LastIndexOf('.') + 1));
        }

        [Key]
        public int ProdutoImagemId { get; set; }

        [Required]
        public string Caminho { get; set; }

        [Required]
        public bool Destaque { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }
    }
}
