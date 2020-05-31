using System;
using System.Collections.Generic;
using System.Linq;

namespace Tp3_GerenciamentoDeAniversarios
{
    class PessoaRep
    {
        private static List<Pessoa> Pessoas = new List<Pessoa>();

        public static void PesquisarPessoa()
        {
            if (Pessoas.Count >= 1)
            {
                Console.Write("\r\nDigite o nome ou parte do nome de quem você busca: ");
                var busca = Console.ReadLine().ToLower();
                IEnumerable<Pessoa> consulta = Pessoas.Where(p => p.Nome.ToLower().Contains(busca) || p.Sobrenome.ToLower().Contains(busca));
                int i = 1;

                Console.WriteLine();
                foreach (var resultado in consulta)
                {
                    Console.WriteLine($"{i} - {resultado.Nome} {resultado.Sobrenome}");
                    i++;
                }
                Console.Write("\r\nSelecione a opção desejada para visualizar os dados da pessoa escolhida: ");

                if(int.TryParse(Console.ReadLine(), out int escolha))
                {
                    Console.WriteLine($"\r\nDados da pessoa escolhida:\r\nNome completo: {Pessoas[escolha-1].Nome} {Pessoas[escolha -1].Sobrenome}\r\nData de nascimento: {Pessoas[escolha-1].DataNascimento}\r\n{Pessoas[escolha-1].CalcularAniversario()}\r\n");
                }
            }
            else
            {
                Console.WriteLine("\r\nNão há pessoas na lista.\r\n");
            }

        }

        public static List<Pessoa> AdicionarPessoa()
        {
            Console.WriteLine("\r\nVocê escolheu **ADICIONAR NOVA PESSOA*\r\n");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            var sobrenome = Console.ReadLine();
            Console.Write("Data de Nascimento (mm/dd/yyyy): ");
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
