namespace CP2.Domain.Interfaces.Dtos
{
    public interface IVendedorDto
    {
        int Id { get; set; }
        string Nome { get; set; } 
        string Email { get; set; } 
        string Telefone { get; set; } 
        DateTime DataNascimento { get; set; }
        string Endereco { get; set; }
        DateTime DataContratacao { get; set; }
        decimal ComissaoPercentual { get; set; }
        decimal MetaMensal { get; set; }
        DateTime CriadoEm { get; set; }
        void Validate();
    }
}

