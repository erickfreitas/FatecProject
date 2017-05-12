using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Infra.CrossCutting.Identity.Model
{
    [Table("ClientesWeb")]
    public class ClienteWeb
    {
        [Key]
        public int ClienteWebId { get; set; }
        public string ClientChave { get; set; }
        public string UsuarioId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}