namespace Project.Domain.Entities
{
    public class Endereco
    {
        public string EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
