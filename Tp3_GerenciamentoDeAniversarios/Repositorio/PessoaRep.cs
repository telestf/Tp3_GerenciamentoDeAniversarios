﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tp3_GerenciamentoDeAniversarios
{
    class PessoaRep
    {
        private static List<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa("Thyago", "Teles", DateTime.Parse("11/05/1989")),
            new Pessoa("Candida", "Teles", DateTime.Parse("24/05/1962")),
            new Pessoa("Gabrielle", "Teles", DateTime.Parse("29/12/1996")),
            new Pessoa("Alexandre", "Ferreira", DateTime.Parse("21/07/1989")),
            new Pessoa("Fulano", "Fulano", DateTime.Now.AddDays(-1))
        };

        public static void PesquisarPessoa()
        {
            List<Pessoa> Linq = new List<Pessoa>();

            if (Pessoas.Count >= 1)
            {
                Console.WriteLine("\r\nPessoas cadastradas:\r\n");
                foreach (var pessoa in Pessoas)
                {
                    Console.WriteLine($"{pessoa.Nome} {pessoa.Sobrenome}");
                }

                Console.Write("\r\nDigite o nome ou parte do nome de quem você busca: ");
                var busca = Console.ReadLine().ToLower();
                IEnumerable<Pessoa> consulta = Pessoas.Where(p => p.Nome.ToLower().Contains(busca) || p.Sobrenome.ToLower().Contains(busca));

                Console.WriteLine();

                int i = 1;

                foreach (var resultado in consulta)
                {
                    Linq.Add(resultado);
                    Console.WriteLine($"{i} - {resultado.Nome} {resultado.Sobrenome}");
                    i++;
                }

                if(Linq.Count >=1)
                {
                    Console.Write("\r\nSelecione a opção desejada para visualizar os dados da pessoa escolhida: ");

                    if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= Linq.Count)
                    {
                        Console.WriteLine($"\r\nDados da pessoa escolhida:\r\nNome completo: {Linq[escolha - 1].Nome} {Linq[escolha - 1].Sobrenome}\r\nData de nascimento: {Linq[escolha - 1].DataNascimento:dd/MM/yyyy}\r\n{Linq[escolha - 1].CalcularAniversario()}\r\n");
                    }
                    else
                    {
                        Console.WriteLine("\r\nOpção Inválida!!\r\n");
                    }
                }
                else
                {
                    Console.WriteLine("\r\nA busca não encontrou resultados\r\n");
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
            Console.Write("Data de Nascimento (no formato dd/MM/yyyy): ");
            var dataNascimento = Console.ReadLine();

            if (DateTime.TryParse(dataNascimento, out DateTime parsedData))
            {
                Console.WriteLine("\r\nDeseja adicionar essa pessoa?\r\n");
                Console.WriteLine($"Nome Completo: {nome} {sobrenome}");
                Console.WriteLine($"Data do Nascimento: {parsedData:dd/MM/yyyy} \r\n");

                Console.Write("1 - Sim\r\n" +
                        "0 - Não\r\n" +
                        "\r\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
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
                        default:
                            Console.WriteLine("\r\nOpção Inválida!!\r\n");
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
