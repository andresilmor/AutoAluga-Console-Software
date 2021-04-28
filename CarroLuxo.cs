using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    class CarroLuxo : Viatura
    {
        private float txLuxo;

        public CarroLuxo(String Matricula, float Taxa) : base(Matricula)
        {
            txLuxo = Taxa;
        }

        public override int RegistarAluguel(Cliente ClienteX, int Dias)
        {
            if (GetPrecoDia() == 0)
            {
                Aluguer X = new Aluguer(++IdAluguer, Dias, 0, ClienteX, this);
                ViAlugueresHist.Add(X);
                ClienteX.AddAluguer(X);
                StatusChange();
                return IdAluguer;
            }
            else
            {
                Aluguer X = new Aluguer(++IdAluguer, Dias, (GetPrecoDia() + ((GetPrecoDia() * txLuxo) / 100)) * Dias, ClienteX, this);
                ViAlugueresHist.Add(X);
                ClienteX.AddAluguer(X);
                StatusChange();
                AutoAluga.AtualTot((GetPrecoDia() + ((GetPrecoDia() * txLuxo) / 100))*Dias);
                return IdAluguer;
            }
        }

        public override void Print()
        {
            Console.WriteLine(":::Carro de Luxo:::");
            base.Print();
            Console.WriteLine("Taxa: " + txLuxo + "%");
            Console.WriteLine("Preço Total: " + (GetPrecoDia()+((GetPrecoDia()*txLuxo)/100)) + "Eur");
            Console.WriteLine("Total Facturado: " + GetTotalFacturado() + "Eur");
        }

        ~CarroLuxo()
        {
            Console.WriteLine("Registo do Carro de Luxo com Matricula \"" + GetMatricula() + "\" apagado.");
        }
    }
}
