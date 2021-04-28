
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    abstract class Viatura
    {
        protected static int IdAluguer = 0;
        private String Matricula;
        private static float PrecoDia;
        protected List<Aluguer> ViAlugueresHist;
        private bool Status = true;

        public Viatura(String Matricula)
        {
            this.Matricula = Matricula;
            ViAlugueresHist = new List<Aluguer>();
        }

        public Aluguer GetLastAluguer()
        {
            Aluguer X = ViAlugueresHist[0];
            foreach(Aluguer Y in ViAlugueresHist)
            {
                if(Y.GetID() > X.GetID())
                {
                    X = Y;
                }
            }
            return X;
        }
        public bool GetStatus()
        {
            return Status;
        }
        public void StatusChange()
        {
            if (Status == true)
            {
                Status = false;
                return;
            }
            Status = true;
        } 

        public float GetPrecoDia()
        {
            return PrecoDia;
        }

        public String GetMatricula()
        {
            return Matricula;
        }

        public static void SetPrecoDia(float PrecoDiaX)
        {
            PrecoDia = PrecoDiaX;   
        }

        public float GetTotalFacturado()
        {
            float Tot = 0;
            foreach (Aluguer X in ViAlugueresHist)
                Tot += X.GetValorFacturado();
            return Tot;
        }

        abstract public int RegistarAluguel(Cliente ClienteX, int Dias);

        public void MostrarAlugueres()
        {
            int cont = 0;
            foreach (Aluguer A in ViAlugueresHist)
                cont += 1;
            if(cont==0)
            {
                Console.WriteLine("A viatura com Matricula \"" + Matricula + "\" não possui histórico de alugueres.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("1.Ordem Crescente de ID");
            Console.WriteLine("2.Ordem Decrescente de ID");
            Console.WriteLine("3.Ordem Crescente por Carta de Condução");
            Console.WriteLine("4.Ordem Decrescente por Carta de Condução");
            Console.WriteLine("Opção: ");
            String opcS = Console.ReadLine();
            byte opc;
            while (byte.TryParse(opcS, out opc) == false || opc < 1 || opc > 4)
            {
                Console.WriteLine("Opção Inválida! Escolha uma opção: ");
                opcS = Console.ReadLine();
            }
            Console.Clear();
            List <Aluguer> AluguerVi = new List<Aluguer>();
            foreach (Aluguer V1 in ViAlugueresHist)
                AluguerVi.Add(V1);
            switch (opc)
            {
                case 1:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerVi[j] < AluguerVi[i])
                            {
                                Aluguer V = AluguerVi[i];
                                AluguerVi[i] = AluguerVi[j];
                                AluguerVi[j] = V;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerVi[j] > AluguerVi[i])
                            {
                                Aluguer V = AluguerVi[i];
                                AluguerVi[i] = AluguerVi[j];
                                AluguerVi[j] = V;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerVi[j].GetCliente().GetCarta() < AluguerVi[i].GetCliente().GetCarta())
                            {
                                Aluguer V = AluguerVi[i];
                                AluguerVi[i] = AluguerVi[j];
                                AluguerVi[j] = V;
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (AluguerVi[j].GetCliente().GetCarta() > AluguerVi[i].GetCliente().GetCarta())
                            {
                                Aluguer V = AluguerVi[i];
                                AluguerVi[i] = AluguerVi[j];
                                AluguerVi[j] = V;
                            }
                        }
                    }
                    break;
            }
            foreach (Aluguer AA in AluguerVi)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(":::Cliente::: ");
                Console.WriteLine("Nome: " + AA.GetCliente().GetNome());
                Console.WriteLine("Carta de Condução: " + AA.GetCliente().GetCarta());
                AA.Print();
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("Matricula: " + Matricula);
        }

        public static bool operator <(Viatura ViaturaX, Viatura ViaturaY)
        {
            float totA = 0;
            float totY = 0;
            foreach (Aluguer A in ViaturaX.ViAlugueresHist)
                totA += A.GetValorFacturado();
            foreach (Aluguer Y in ViaturaY.ViAlugueresHist)
                totY += Y.GetValorFacturado();
            if (totA < totY)
                return true;
            else
                return false;
        }

        public static bool operator >(Viatura ViaturaX, Viatura ViaturaY)
        {
            float totA = 0;
            float totY = 0;
            foreach (Aluguer A in ViaturaX.ViAlugueresHist)
                totA += A.GetValorFacturado();
            foreach (Aluguer Y in ViaturaY.ViAlugueresHist)
                totY += Y.GetValorFacturado();
            if (totA > totY)
                return true;
            else
                return false;
        }
    }
}
