using System;
using System.Collections.Generic;

namespace Tp3_GerenciamentoDeAniversarios
{
    class PessoaRep
    {
        private static List<Pessoa> Pessoas { get; set; }

        public static void PesquisarPessoa()
        {
            if (Pessoas.Count >= 1)
            {
                Console.Write("Digite o nome ou parte do nome de quem você busca:");
                var busca = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\r\nNão há pessoas na lista.\r\n");
            }

        }

        public static List<Pessoa> AdicionarPessoa()
        {
            Pessoas = new List<Pessoa>();

            Console.WriteLine("\r\nVocê escolheu **ADICIONAR NOVA PESSOA*\r\n");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            var sobrenome = Console.ReadLine();
            Console.Write("Data de Nascimento (dd/mm/yyyy): ");
            var dataNascimento = Console.ReadLine();

            if (DateTime.TryParse(dataNascimento, out DateTime parsedData))
            {
                Console.WriteLine("\r\nDeseja adicionar essa pessoa?\r\n");
                Console.WriteLine($"Nome Completo: {nome} {sobrenome}");
                Console.WriteLine($"Data do Nascimento: {parsedData} \r\n");

                int opcao;

                Console.Write("1 - Sim\r\n" +
                        "0 - Não\r\n" +
                        "\r\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao) && opcao == 0 || opcao == 1)
                {
                    switch (opcao)
                    {
                        case 1:
                            Pessoa p = new Pessoa(nome, sobrenome, DateTime.Parse(dataNascimento));
                            Pessoas.Add(p);
                            Console.WriteLine("\r\nDados adicionados com sucesso!\r\n");
                            break;

                        case 0:
                            Console.WriteLine();
                            AdicionarPessoa();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\r\nFormato incorreto de data! Tente novamente.\r\n");
            }
            return Pessoas;
        }
    }
}
