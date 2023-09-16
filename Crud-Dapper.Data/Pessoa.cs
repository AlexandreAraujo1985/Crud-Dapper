namespace Crud_Dapper.Data
{
    public class Pessoa
    {
        [Column("ID")]
        public int PessoaId { get; set; }
        [Column("NOME")]
        public string? Nome { get; set; }
        [Column("CPF")]
        public string? CPF { get; set; }
        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }
    }
}