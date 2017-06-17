using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Project.Application.ViewModels
{
    public class UsuarioImagemViewModel
    {
        public UsuarioImagemViewModel(HttpPostedFileBase imagem, string usuarioId)
        {
            UsuarioId = usuarioId;
            ImagemCaminho = string.Format("~/Images/Users/{0}.{1}", Guid.NewGuid().ToString(), imagem.FileName.Substring(imagem.FileName.LastIndexOf('.') + 1));
        }

        [Key]
        public string UsuarioId { get; set; }
        public string ImagemCaminho { get; set; }
    }
}
