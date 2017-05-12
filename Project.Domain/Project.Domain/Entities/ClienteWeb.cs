namespace Project.Domain.Entities
{
    public class ClienteWeb
    {
        public int ClienteWebId { get; set; }
        public string ClientChave { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
