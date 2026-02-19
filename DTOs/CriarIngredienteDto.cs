namespace SmartMenu.Api.DTOs
{
    public class CriarIngredienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal EstoqueAtual { get; set; }
        public string Unidade { get; set; } = "UN";
        public decimal PrecoAdicional { get; set; }
    }
}
