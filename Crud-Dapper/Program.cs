using Crud_Dapper.Data;

namespace Crud_Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoaRepository = new PessoaRepository();

            Console.WriteLine("Incluindo Dados********************************************************************");

            pessoaRepository.InserirPessoa(new Pessoa
            {
                Nome = "Alexandre",
                CPF = "XXXXXXXXXX1",
                DataNascimento = DateTime.Parse("01/01/1910"),
            });

            pessoaRepository.InserirPessoa(new Pessoa
            {
                Nome = "Nair",
                CPF = "XXXXXXXXXX2",
                DataNascimento = DateTime.Parse("01/01/1911"),
            });

            Console.WriteLine("Alterando Dados********************************************************************");

            pessoaRepository.AlterarPessoa(new Pessoa { PessoaId = 1, CPF = "XXXXXXXXXX3" });

            Console.WriteLine("Excluindo Dados********************************************************************");

            pessoaRepository.DeletarPessoa(3);

            Console.WriteLine("Pesquisando Pessoal com Id = 1*****************************************************");
            var pessoa = pessoaRepository.ObterPessoa(1);

            Console.WriteLine($"Nome:{pessoa.Nome}\nCPF:{pessoa.CPF} \nData Nascimento:{pessoa.DataNascimento.Date}");

            Console.WriteLine("Pesquisando Todas as Pessoas*******************************************************");

            var pessoas = pessoaRepository.ObterPessoas();

            pessoas.ToList().ForEach(pessoa =>
            {
                Console.WriteLine($"Nome:{pessoa.Nome}\nCPF:{pessoa.CPF} \nData Nascimento:{pessoa.DataNascimento.Date}");
            });

            Console.ReadLine();
        }
    }
}