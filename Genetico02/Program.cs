/* Algoritmo genético: Operador cruce */
using System;

namespace Genetico02 {
    class Program {
        static void Main() {
            string cadOriginal = "Estoy probando un algoritmo genético";

            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 2000;
            int TotalCiclos = 90000;
            string MejorIndiv = objPoblacion.Proceso(cadOriginal, TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine(MejorIndiv);
            Console.ReadKey();
        }
    }
}
