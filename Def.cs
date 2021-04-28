using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    static class Def
    {
        public static void Menu()
        {
            Console.WriteLine("_Criando AutoAluga_");
            Console.WriteLine("Preço do Dia (Número Real):");
            String preS = (Console.ReadLine());
            float pre;
            while (float.TryParse(preS, out pre) == false || pre < 0)
            {
                Console.WriteLine("Valor Inválido! Reintroduza o Preço do Dia: ");
                preS = Console.ReadLine();
            }
            AutoAluga AutoAluga = new AutoAluga(pre);
            Console.Clear();
            Console.WriteLine();
            if (pre == 0)
            {
                Console.WriteLine("AVISO: Ao indicar o valor 0 como o Preço do Dia, está dizendo que os alugueres serão grátis.");
            }
            Console.WriteLine("AutoAluga criada com sucesso! Preço do Dia Atual: " + pre + "Eur.");
            Console.WriteLine();
            byte opc = 15;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1.Adicionar Cliente");
                Console.WriteLine("2.Adicionar Utilitário");
                Console.WriteLine("3.Adicionar Carro de Luxo");
                Console.WriteLine("4.Definir Preço de Dia");
                Console.WriteLine("5.Registar Aluguer");
                Console.WriteLine("6.Mostrar Histórico Cliente");
                Console.WriteLine("7.Mostrar Histórico Viatura");
                Console.WriteLine("8.Mostrar Total Facturado");
                Console.WriteLine("9.Mostrar Total Facturado duma Viatura");
                Console.WriteLine("10.Listar Todas Viaturas");
                Console.WriteLine("11.Listar Todos Clientes");
                Console.WriteLine("12.Remover Cliente");
                Console.WriteLine("13.Remover Viatura");
                Console.WriteLine("14.Devolver Viatura");
                Console.WriteLine("15.Terminar");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Opção:");
                string opcS = Console.ReadLine();
                while (byte.TryParse(opcS, out opc) == false || opc < 1 || opc > 15)
                {
                    Console.WriteLine("Opção Inválida! Escolha uma opção: ");
                    opcS = Console.ReadLine();
                }
                switch (opc)
                {
                    case 1: 
                        AutoAluga = MAdicionarCliente(AutoAluga);
                        break;
                    case 2: 
                        AutoAluga = MAdicionarUtilitario(AutoAluga);
                        break;
                    case 3: 
                        AutoAluga = MAdicionarCarroLuxo(AutoAluga);
                        break;
                    case 4: 
                        AutoAluga = MDefinirPrecoDia(AutoAluga);
                        break;
                    case 5: 
                        AutoAluga = MRegistarAluguel(AutoAluga);
                        break;
                    case 6: 
                        MMostrarHistoricoCliente(AutoAluga);
                        break;
                    case 7: 
                        MMostrarHistoricoViatura(AutoAluga);
                        break;
                    case 8: 
                        MMostrarTotalFacturado(AutoAluga);
                        break;
                    case 9: 
                        MMostrarTotalFacturadDumaViatura(AutoAluga);
                        break;
                    case 10: 
                        MListarTodasAsViaturas(AutoAluga);
                        break;
                    case 11: 
                        MListarTodosOsClientes(AutoAluga);
                        break;
                    case 12:
                        AutoAluga = MRemoverCliente(AutoAluga);
                        break;
                    case 13:
                        AutoAluga = MRemoverViatura(AutoAluga);
                        break;
                    case 14:
                        AutoAluga = MDevolverViatura(AutoAluga);
                        break;
                }
            } while (opc != 15);
        }

        public static AutoAluga MAdicionarCliente(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Número da Carta de Condução: ");
            String CartaS = Console.ReadLine();
            long Carta;
            while (long.TryParse(CartaS, out Carta) == false || Carta < 0)
            {
                Console.WriteLine("Valor Inválido! Escolha um valor: ");
                CartaS = Console.ReadLine();
            }
            Console.WriteLine("Nome:");
            String Nome = Console.ReadLine();
            while (CheckString(Nome) == false)
            {
                Console.WriteLine("Espaço em branco! Nome: ");
                Nome = Console.ReadLine();
            }
            Console.WriteLine();
            if (AA.AddCliente(Carta, Nome) == false)
            {
                Console.WriteLine("Cliente já existente!");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine("Cliente Adicionado com Sucesso!");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MAdicionarUtilitario(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Matricula: ");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            if (AA.AddUtilitario(Matricula) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Viatura já existente!");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine();
            Console.WriteLine("Utilitário Adicionado com Sucesso!");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MAdicionarCarroLuxo(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Matricula: ");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            Console.WriteLine("Taxa: ");
            String TaxaS = Console.ReadLine();
            float Taxa;
            while (float.TryParse(TaxaS, out Taxa) == false || Taxa < 0)
            {
                Console.WriteLine("Valor Inválida! Escolha o valor da taxa: ");
                TaxaS = Console.ReadLine();
            }
            Console.WriteLine();
            if (AA.AddCarroLuxo(Matricula, Taxa) == false)
            {
                Console.WriteLine("Viatura já existente!");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine("Carro de Luxo Adicionado com Sucesso!");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MDefinirPrecoDia(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Redefinir Preço do Dia: ");
            String PreS = Console.ReadLine();
            float pre;
            while (float.TryParse(PreS, out pre) == false || pre < 0)
            {
                Console.WriteLine("Valor Inválido! Reintroduza o Preço do Dia: ");
                PreS = Console.ReadLine();
            }
            AA.SetPrecoDia(pre);
            Console.WriteLine();
            if (pre == 0)
            {
                Console.WriteLine("AVISO: Ao indicar o valor 0 como o Preço do Dia, está dizendo que os alugueres serão grátis.");
            }
            Console.WriteLine("Preço do Dia Redefinido para " + pre + "Eur");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MRegistarAluguel(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Carta de Condução: ");
            String CartaS = Console.ReadLine();
            long Carta;
            while (long.TryParse(CartaS, out Carta) == false || Carta < 0)
            {
                Console.WriteLine("Valor Inválido! Reintroduza a Carta de Condução: ");
                CartaS = Console.ReadLine();
            }
            Console.WriteLine("Matricula: ");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            Console.WriteLine("Nº de Dias: ");
            String DiasS = Console.ReadLine();
            int Dias;
            while (int.TryParse(DiasS, out Dias) == false || Dias <= 0)
            {
                Console.WriteLine("Valor Inválido! Reintroduza o Nº de Dias : ");
                DiasS = Console.ReadLine();
            }
            int id = AA.RegistarAluguel(Carta, Matricula, Dias);
            if (id != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Aluguer Registado com Sucesso! ID: " + id);
            }
            Console.WriteLine();
            return AA;
        }
        
        public static void MMostrarHistoricoCliente (AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Carta de Condução: ");
            String CartaS = Console.ReadLine();
            long Carta;
            while (long.TryParse(CartaS, out Carta) == false || Carta < 0)
            {
                Console.WriteLine("Valor Inválido! Reintroduza a Carta de Condução: ");
                CartaS = Console.ReadLine();
            }
            AA.MostrarAlugueresCliente(Carta);
        }

        public static void MMostrarHistoricoViatura (AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Matricula:");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            AA.MostrarAlugueresViatura(Matricula);
        }

        public static void MMostrarTotalFacturado (AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine();
            AA.MostrarTotalFacturado();
            Console.WriteLine();
        }

        public static void MMostrarTotalFacturadDumaViatura (AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Matricula:");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            AA.MostrarTotalFacturadoViatura(Matricula);
        }

        public static void MListarTodasAsViaturas(AutoAluga AA)
        {
            Console.Clear();
            AA.ListarTodasViaturas();
        }

        public static void MListarTodosOsClientes(AutoAluga AA)
        {
            Console.Clear();
            AA.ListarTodosClientes();
        }

        public static AutoAluga MRemoverCliente(AutoAluga AA) 
        {
            Console.Clear();
            Console.WriteLine("Insira a Carta de Condução do Cliente que deseja remover:");
            String CartaS = Console.ReadLine();
            long Carta;
            while (long.TryParse(CartaS, out Carta)==false)
            {
                Console.WriteLine("Valor Inválido! Insira de novo de Carta de Condução:");
                CartaS = Console.ReadLine();
            }
            Console.WriteLine();
            if (AA.RemoverCliente(Carta)==true)
            {
                Console.WriteLine("Cliente com Carta de Condução \"" + Carta + "\" removido.");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine("Impossivel de remover Cliente com Carta de Condução \"" + Carta + "\".");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MRemoverViatura(AutoAluga AA) 
        {
            Console.Clear();
            Console.WriteLine("Insira a Matricula da viatura que deseja remover:");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            Console.WriteLine();
            if (AA.RemoverViatura(Matricula)==true)
            {
                Console.WriteLine("Viatura com Matricula \"" + Matricula + "\" removida.");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine("Impossivel de remover Viatura com Matricula \"" + Matricula + "\".");
            Console.WriteLine();
            return AA;
        }

        public static AutoAluga MDevolverViatura(AutoAluga AA)
        {
            Console.Clear();
            Console.WriteLine("Insira a Matricula da Viatura a devolver:");
            String Matricula = Console.ReadLine();
            while (CheckString(Matricula) == false)
            {
                Console.WriteLine("Espaço em branco! Matricula: ");
                Matricula = Console.ReadLine();
            }
            bool Suc = AA.DevolverViatura(Matricula);
            if (Suc == true)
            {
                Console.WriteLine();
                Console.WriteLine("Viatura devolvida com Sucesso!");
                Console.WriteLine();
                return AA;
            }
            Console.WriteLine();
            Console.WriteLine("Viatura com matricula \"" + Matricula + "\" não pode ser devolvida.\n(Possiveis Erros: Inexistência dessa Viatura / Não se encontra alugada)");
            Console.WriteLine();
            return AA;
        }

        public static bool CheckString(String S)
        {
            int Y = 0;
            int X = 0;
            foreach(Char C in S)
            {
                X += 1;
                if (C.ToString() == " ")
                    Y += 1;
            }
            return (X == Y) ? false : true;
            //if (X == Y)
            //    return false;
            //return true;
        }
    }

}
