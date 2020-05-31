using System;

namespace Tp3_GerenciamentoDeAniversarios
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciarAniversarios();
        }

        private static void GerenciarAniversarios()
        {
            int opcao;

            do
            {
                while (true)
                {
                    Console.Write("Menu Principal\r\n" +
                        "\r\n1 - Pesquisar Pessoas\r\n" +
                            "2 - Adicionar Nova Pessoa\r\n" +
                            "0 - Sair\r\n" +
                            "\r\nEscolha uma opção: ");

                    if (int.TryParse(Console.ReadLine(), out opcao) && opcao >= 0 && opcao <= 2)
                    {
                        if (opcao != 0)
                        {
                            switch (opcao)
                            {
                                case 1:
                                    PessoaRep.PesquisarPessoa();
                                    break;
                                case 2:
                                    PessoaRep.AdicionarPessoa();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Você encerrou a sessão.");
                        }
                        break;
                    }
                    Console.WriteLine("Opção Inválida!!\r\n");
                }
            }
            while (opcao != 0);
        }
    }
}
