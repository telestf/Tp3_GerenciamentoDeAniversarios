using System;

namespace Tp3_GerenciamentoDeAniversarios
{
    class Pessoa
    {
        public string Nome;
        public string Sobrenome;
        public DateTime DataNascimento;

        public Pessoa(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public void CalcularAniversario()
        {
            DateTime comemoracaoAniversario = new DateTime(DateTime.Now.Year, DataNascimento.Month, DataNascimento.Day);
            TimeSpan contagemDias = comemoracaoAniversario - DateTime.Now;
            if(contagemDias.Days > 0)
            {
                Console.WriteLine($"Falta(m) {contagemDias.Days} dia(s) para o aniversário deste ano.");
            }
            else if (contagemDias.Days == 0)
            {
                Console.WriteLine("Hoje é o dia do aniversário.");
            }
            else
            {
                Console.WriteLine($"O aniversário deste ano foi há {contagemDias.Days} dia(s).");
            }

        }
    }
}
