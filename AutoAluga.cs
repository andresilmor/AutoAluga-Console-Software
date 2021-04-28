using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    sealed class AutoAluga : IAutoAluga
    {
        private List<Viatura> Viaturas;
        private List<Cliente> Clientes;
        private static float Tot = 0;

        public AutoAluga(float PrecoDia)
        {
            Viaturas = new List<Viatura>();
            Clientes = new List<Cliente>();
            SetPrecoDia(PrecoDia);
        }

        public static void AtualTot(float X)
        {
            Tot += X;
        }
        public void SetPrecoDia(float PrecoDia)
        {
            Viatura.SetPrecoDia(PrecoDia);
        }

        public bool AddCliente(long Carta, String Nome)
        {
            if (FindCliente(Carta) != null)
                return false;
            Clientes.Add(new Cliente(Carta, Nome));
            return true;
        }

        public bool AddUtilitario(String Matricula)
        {
            Viatura X = FindViatura(Matricula);
            if (X != null)
                return false;
            Viaturas.Add(new Utilitario(Matricula));
            return true;
        }

        public bool AddCarroLuxo(String Matricula, float Taxa)
        {
            Viatura X = FindViatura(Matricula);
            if (X != null)
                return false;
            Viaturas.Add(new CarroLuxo(Matricula, Taxa));
            return true;
        }

        public Cliente FindCliente(long Carta)
        {
            foreach (Cliente ClienteX in Clientes)
            {
                if (ClienteX.GetCarta() == Carta)
                    return ClienteX;
            }
            return null;
        }

        public Viatura FindViatura(String Matricula)
        {
            foreach (Viatura ViaturaX in Viaturas)
            {
                if (ViaturaX.GetMatricula() == Matricula)
                    return ViaturaX;
            }
            return null;
        }

        public int RegistarAluguel(long Carta, String Matricula, int Dias)
        {
            Cliente X = FindCliente(Carta);
            if (X != null)
            {
                Viatura Y = FindViatura(Matricula);
                if (Y != null)
                {
                    if (Y.GetStatus() == true)
                        return Y.RegistarAluguel(X, Dias);
                    Console.WriteLine();
                    Console.WriteLine("Viatura com Matricula \"" + Matricula + "\" indisponivel.");
                    return 0;
                }
                Console.WriteLine();
                Console.WriteLine("Viatura com Matricula \"" + Matricula + "\" não encontrada.");
                return 0;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Cliente com Carta de Condução \"" + Carta + "\" não encontrado.");
            }
            return 0;
        }

        public void MostrarAlugueresCliente(long Carta) 
        {
            Cliente X = FindCliente(Carta);
            if (X != null)
            {
                Console.WriteLine();
                Console.WriteLine("Histórico de: " + X.GetNome() + " (Carta de Condução: " + Carta + ")");
                X.MostrarAlugueres();
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Cliente com a Carta de Condução \"" + Carta + "\" não encontrado.");
            Console.WriteLine();
        }

        public void MostrarAlugueresViatura(String Matricula)  
        {
            Viatura X = FindViatura(Matricula);
            if (X != null)
            {
                Console.WriteLine();
                if (X is Utilitario)
                    Console.WriteLine(":::Utilitário:::");
                else if (X is CarroLuxo)
                    Console.WriteLine(":::Carro de Luxo:::");
                Console.WriteLine("Histórico da Viatura: " + X.GetMatricula());
                X.MostrarAlugueres();
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Viatura com a Matricula \"" + Matricula + "\" não encontrada.");
            Console.WriteLine();
        }

        public void MostrarTotalFacturadoViatura(String Matricula)
        {
            Viatura X = FindViatura(Matricula);
            Console.WriteLine();
            if (X != null)
            {
                if (X is Utilitario)
                    Console.WriteLine(":::Utilitário:::");
                else
                    Console.WriteLine(":::Carro de Luxo:::");
                Console.WriteLine("Matricula: " + Matricula);
                Console.WriteLine("Total Facturado: " + X.GetTotalFacturado() + "Eur");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Viatura com a matricula \"" + Matricula + "\" não encontrada.");
            Console.WriteLine();
        }

        public void MostrarTotalFacturado()
        {
            float tot = 0;
            foreach (Viatura X in Viaturas)
                tot = tot += X.GetTotalFacturado();
            Console.WriteLine("Total Facturado desde Fundação: " + AutoAluga.Tot + "Eur");
            Console.WriteLine("Total Facturado (Com Viaturas Disponiveis): " + tot + "Eur");
        }

        public void ListarTodasViaturas() 
        {
            int cont = 0;
            foreach (Viatura X in Viaturas)
                cont += 1;
            if (cont == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma viatura encontrada.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("1.Ordem Crescente por Total Facturado");
            Console.WriteLine("2.Ordem Decrescente por Total Facturado");
            Console.WriteLine();
            Console.WriteLine("3.Ordem Crescente por Total Facturado (Só Utilitários)");
            Console.WriteLine("4.Ordem Decrescente por Total Facturado (Só Utilitários)");
            Console.WriteLine();
            Console.WriteLine("5.Ordem Crescente por Total Facturado (Só Carros de Luxo)");
            Console.WriteLine("6.Ordem Decrescente por Total Facturado (Só Carros de Luxo)");
            Console.WriteLine();
            Console.WriteLine("Opção: ");
            String opcS = Console.ReadLine();
            byte opc;
            while (byte.TryParse(opcS, out opc) == false || opc < 1 || opc > 6)
            {
                Console.WriteLine("Opção Inválida! Escolha uma opção: ");
                opcS = Console.ReadLine();
            }
            Console.Clear();
            List<Viatura> DuplaV = new List<Viatura>();
            foreach (Viatura V1 in Viaturas)
                DuplaV.Add(V1);
            if(opc == 2 || opc == 4 || opc == 6)
                for (int i = 0; i < cont; i++)
                {
                    for (int j = i; j < cont; j++)
                    {
                        if (DuplaV[j] > DuplaV[i])
                        {
                            Viatura W = DuplaV[i];
                            DuplaV[i] = DuplaV[j];
                            DuplaV[j] = W;
                        }
                    }
                }
            else if(opc == 1 || opc == 3 || opc == 5)
                for (int i = 0; i < cont; i++)
                {
                    for (int j = i; j < cont; j++)
                    {
                         if (DuplaV[j] < DuplaV[i])
                         {
                             Viatura W = DuplaV[i];
                             DuplaV[i] = DuplaV[j];
                             DuplaV[j] = W;
                         }
                    }
                }
            if (opc == 3 || opc == 4)
            {
                foreach (Viatura VV in DuplaV)
                {
                    if (VV is Utilitario)
                    {
                        Console.WriteLine("------------------------------------");
                        VV.Print();
                        return;
                    }
                }
            }
            else if (opc == 5 || opc == 6)
            {
                foreach (Viatura VV in DuplaV)
                {
                    if (VV is CarroLuxo)
                    {
                        Console.WriteLine("------------------------------------");
                        VV.Print();
                        return;
                    }
                }
            }
            foreach (Viatura VV in DuplaV)
            {
                Console.WriteLine("------------------------------------");
                VV.Print();
            }
        }

        public void ListarTodosClientes()
        {
            int cont = 0;
            foreach (Cliente X in Clientes)
                cont += 1;
            if (cont == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum cliente encontrado.");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("1.Ordem Crescente por Total Gasto");
            Console.WriteLine("2.Ordem Decrescente por Total Gasto");
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
            List<Cliente> DuplaC = new List<Cliente>();
            foreach (Cliente C1 in Clientes)
                DuplaC.Add(C1);
            switch (opc)
            {
                case 2:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (DuplaC[j] > DuplaC[i])
                            {
                                Cliente W = DuplaC[i];
                                DuplaC[i] = DuplaC[j];
                                DuplaC[j] = W;
                            }
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (DuplaC[j] < DuplaC[i])
                            {
                                Cliente W = DuplaC[i];
                                DuplaC[i] = DuplaC[j];
                                DuplaC[j] = W;
                            }
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (DuplaC[j].GetCarta() > DuplaC[i].GetCarta())
                            {
                                Cliente W = DuplaC[i];
                                DuplaC[i] = DuplaC[j];
                                DuplaC[j] = W;
                            }
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < cont; i++)
                    {
                        for (int j = i; j < cont; j++)
                        {
                            if (DuplaC[j].GetCarta() < DuplaC[i].GetCarta())
                            {
                                Cliente W = DuplaC[i];
                                DuplaC[i] = DuplaC[j];
                                DuplaC[j] = W;
                            }
                        }
                    }
                    break;
            }
            foreach (Cliente CC in DuplaC)
            {
                Console.WriteLine("------------------------------------");
                CC.Print();
            }
        }

        public bool RemoverCliente(long Carta) 
        {
            Cliente X = FindCliente(Carta);
            if (X != null && X.GetAlugadosNum() == 0)
            {
                Clientes.Remove(FindCliente(Carta));
                return true;
            }
            return false;
        }

        public bool RemoverViatura(String Matricula) 
        {
            Viatura X = FindViatura(Matricula);
            if (X != null && X.GetStatus() == true)
            {
                Viaturas.Remove(X);
                return true;
            }
            return false;
        }

        public bool DevolverViatura(String Matricula)
        {
            Viatura X = FindViatura(Matricula);
            if(X==null)
            {
                return false;
            }
            if (X.GetStatus() == false)
            {
                X.GetLastAluguer().GetCliente().MenosAl();
                X.StatusChange();
                return true;
            }
            return false;
        }
    }
}