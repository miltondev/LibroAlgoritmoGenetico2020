using System;

namespace Genetico01 {
    class Program {
        static void Main() {
            string cadOriginal = "Estoy probando un algoritmo genético";

            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 50;
            int TotalCiclos = 10000;
            string MejorIndiv = objPoblacion.Proceso(cadOriginal, TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine(MejorIndiv);
            Console.ReadKey();
        }
    }
}
