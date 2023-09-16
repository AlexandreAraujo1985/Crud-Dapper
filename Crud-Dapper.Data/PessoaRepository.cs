using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Crud_Dapper.Data
{
    public class PessoaRepository : BaseParametros<Pessoa>
    {
        public void InserirPessoa(Pessoa pessoa)
        {
            using var connection = new ConnectionBase().Connection;

            connection.Execute(@"INSERT INTO 
                                     [TB_PESSOA]
                                 VALUES(
                                     @NOME,
                                     @CPF,
                                     @DATA_NASCIMENTO)", ObterParametros(pessoa));
        }

        public Pessoa ObterPessoa(int id)
        {
            using var connection = new ConnectionBase().Connection;

            var pessoa = connection.QueryFirst<Pessoa>("SELECT * FROM [TB_PESSOA] WHERE ID = @ID", new { ID = id });

            return pessoa;
        }

        public IEnumerable<Pessoa> ObterPessoas()
        {
            using var connection = new ConnectionBase().Connection;

            var pessoas = connection.Query<Pessoa>("SELECT * FROM [TB_PESSOA]");

            return pessoas;
        }

        public void AlterarPessoa(Pessoa pessoa)
        {
            using var connection = new ConnectionBase().Connection;

            connection.Execute("UPDATE [TB_PESSOA] SET [CPF] = @CPF WHERE ID = @ID",
                new
                {
                    ID = pessoa.PessoaId,
                    pessoa.CPF,
                });
        }

        public void DeletarPessoa(int id)
        {
            using var connection = new ConnectionBase().Connection;

            connection.Execute("DELETE [TB_PESSOA] WHERE ID = @ID", new { ID = id });
        }
    }
}
