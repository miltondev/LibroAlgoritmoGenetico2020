/* Búsqueda del máximo. Algoritmo genético: Operador mutación */
using System;

namespace Genetico04 {
    class Program {
        static void Main() {
            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 50;
            int TotalCiclos = 1000;
            double MejorIndiv = objPoblacion.Proceso(TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine("X = " + MejorIndiv.ToString());
            Console.ReadKey();
        }
    }
}
