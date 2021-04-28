using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    class Utilitario : Viatura
    {
        public Utilitario(String Matricula) : base(Matricula)
        { }

        public override int RegistarAluguel(Cliente ClienteX, int Dias)
        {
            Aluguer X = new Aluguer(++IdAluguer, Dias, GetPrecoDia()*Dias, ClienteX, this);
            ViAlugueresHist.Add(X);
            ClienteX.AddAluguer(X);
            StatusChange();
            AutoAluga.AtualTot(GetPrecoDia() * Dias);
            return IdAluguer;
        }

        public override void Print()
        {
            Console.WriteLine(":::Utilitário:::");
            base.Print();
            Console.WriteLine("Preço Total: " + GetPrecoDia() + "Eur");
            Console.WriteLine("Total Facturado: " + GetTotalFacturado() + "Eur");
        }

        ~Utilitario()
        {
            Console.WriteLine("Registo do Utilitário com Matricula \"" + GetMatricula() + "\" apagado.");
        }
    }
}
