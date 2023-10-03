using System.ComponentModel.DataAnnotations;

namespace devio_fundamentos.Model;

public class Fornecedor
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter de {2} e {1} caracteres", MinimumLength = 3)]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, ErrorMessage = "O campo {0} precisa ter de {2} e {1} caracteres", MinimumLength = 11)]
    public string? Documento { get; set; }
    public int TipoFornecedor { get; set; }
    public bool Ativo { get; set; }
}