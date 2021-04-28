using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoAluga
{
    interface IAutoAluga
    {
        void SetPrecoDia(float PrecoDia);

        bool AddCliente(long Carta, String Nome);

        bool AddUtilitario(String Matricula);

        bool AddCarroLuxo(String Matricula, float Taxa);

        int RegistarAluguel(long Carta, String Matricula, int Dias);

        void MostrarAlugueresCliente(long Carta);

        void MostrarAlugueresViatura(String Matricula);

        void MostrarTotalFacturadoViatura(String Matricula);

        void MostrarTotalFacturado();

        void ListarTodasViaturas();

        void ListarTodosClientes();

        bool RemoverCliente(long Carta);

        bool RemoverViatura(String Matricula);

        bool DevolverViatura(String Matricula);
    }
}
