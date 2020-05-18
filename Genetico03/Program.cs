/* Algoritmo genético: Operador cruce y mutación */
using System;

namespace Genetico03 {
    class Program {
        static void Main() {
            string cadOriginal = "Estoy probando un algoritmo genético";

            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 2000;
            int TotalCiclos = 100000;
            string MejorIndiv = objPoblacion.Proceso(cadOriginal, TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine(MejorIndiv);
            Console.ReadKey();
        }
    }
}
