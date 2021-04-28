using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    class Cliente
    {
        private long Carta;
        private String Nome;
        private List<Aluguer> CliAlugueresHist;
        private int Alugados = 0;

        public Cliente(long Carta, String Nome)
        {
            this.Carta = Carta;
            this.Nome = Nome;
            CliAlugueresHist = new List<Aluguer>();
        }

        public int GetAlugadosNum()
        {
            return Alugados;
        }

        public void MaisAl()
        {
            Alugados += 1;
        }

        public void MenosAl()
        {
            Alugados -= 1;
        }

        public long GetCarta()
        {
            return Carta;
        }

        public String GetNome()
        {
            return Nome;
        }

        public void AddAluguer(Aluguer X)
        {
            CliAlugueresHist.Add(X);
            MaisAl();   
        }

        public float TotalGasto()
        {
            float Tot = 0;
            foreach (Aluguer A in CliAlugueresHist)
                Tot += A.GetValorFacturado();
            return Tot;
        }

        public void MostrarAlugueres()
        {
            int cont = 0;
            foreach (Aluguer A in CliAlugueresHist)
                cont += 1;
            if(cont==0)
            {
                Console.WriteLine("O cliente com a Carta de Condução \"" + Carta + "\" não possui histórico de alugueres.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("1.Ordem Crescente de ID");
            Console.WriteLine("2.Ordem Decrescente de ID");
            Console.WriteLine("Opção: ");
            String opcS = Console.ReadLine();
            byte opc;
            while (byte.TryParse(opcS, out opc) == false || opc < 1 || opc > 2)
            {
                Console.WriteLine("Opção Inválida! Escolha uma opção: ");
                opcS = Console.ReadLine();
            }
            Console.Clear();
            List <Aluguer> AluguerCli = new List<Aluguer>();
            foreach (Aluguer A1 in CliAlugueresHist)
                AluguerCli.Add(A1);
            switch (opc)
            {
                case 1:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerCli[j] < AluguerCli[i])
                            {
                                Aluguer Y = AluguerCli[i];
                                AluguerCli[i] = AluguerCli[j];
                                AluguerCli[j] = Y;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerCli[j] > AluguerCli[i])
                            {
                                Aluguer Y = AluguerCli[i];
                                AluguerCli[i] = AluguerCli[j];
                                AluguerCli[j] = Y;
                            }
                        }
                    }
                    break;
            }
            foreach (Aluguer AA in AluguerCli)
            {
                Console.WriteLine("------------------------------------");
                if (AA.GetViatura() is Utilitario)
                    Console.WriteLine(":::Utilitário:::");
                else
                    Console.WriteLine(":::Carro de Luxo:::");
                Console.WriteLine("Matricula: " + AA.GetViatura().GetMatricula());
                AA.Print();
            }  
        }

        public void Print()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Carta de Condução: " + Carta);
            Console.WriteLine("Registo de Gastos: " + TotalGasto() + "Eur");
        }

        public static bool operator <(Cliente ClienteA, Cliente ClienteY)
        {
            float totA = 0;
            float totY = 0;
            foreach (Aluguer A in ClienteA.CliAlugueresHist)
                totA += A.GetValorFacturado();
            foreach (Aluguer Y in ClienteY.CliAlugueresHist)
                totY += Y.GetValorFacturado();
            if (totA < totY)
                return true;
            else
                return false;
        }

        public static bool operator >(Cliente ClienteA, Cliente ClienteY)
        {
            float totA = 0;
            float totY = 0;
            foreach (Aluguer A in ClienteA.CliAlugueresHist)
                totA += A.GetValorFacturado();
            foreach (Aluguer Y in ClienteY.CliAlugueresHist)
                totY += Y.GetValorFacturado();
            if (totA > totY)
                return true;
            else
                return false;
        }

        ~Cliente()
        {
            Console.WriteLine("Registo do Cliente com Carta de Condução \"" + GetCarta() + "\" apagado.");
        }
    }
}
