using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    sealed class Aluguer
    {
        private int Id;
        private int Dias;
        private float ValorFacturado;
        private Cliente Cliente;
        private Viatura Viatura;

        public Aluguer(int Id, int Dias, float Valor, Cliente ClienteX, Viatura ViaturaX)
        {
            this.Id = Id;
            this.Dias = Dias;
            ValorFacturado = Valor;
            Cliente = ClienteX;
            Viatura = ViaturaX;
        }

        public int GetID()
        {
            return Id;
        }

        public float GetValorFacturado()
        {
            return ValorFacturado;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Dias: " + Dias);
            Console.WriteLine("Valor Facturado: " + ValorFacturado + "Eur");
        }

        public Cliente GetCliente()
        {
            return Cliente;
        }

        public Viatura GetViatura()
        {
            return Viatura;
        }

        public static bool operator <(Aluguer AluguerA, Aluguer AluguerY)
        {
            if (AluguerA.Id < AluguerY.Id)
                return true;
            else
                return false;
        }

        public static bool operator >(Aluguer AluguerA, Aluguer AluguerY)
        {
            if (AluguerA.Id > AluguerY.Id)
                return true;
            else
                return false;
        }

        ~Aluguer()
        {
            Console.WriteLine("Registo do Aluguer com ID \"" + Id + "\" apagado.");
        }
    }
}
