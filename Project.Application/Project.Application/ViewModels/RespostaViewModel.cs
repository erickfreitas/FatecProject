namespace Project.Application.ViewModels
{
    public class RespostaViewModel
    {

        public int RespostaId { get; set; }

        public string Descricao { get; set; }

        public string UsuarioId{ get; set; }
        public PerguntaViewModel PerguntaViewModel { get; set; }
    }
}
