/* Buscar valor de X. Algoritmo genético: Operador cruce y mutación */
using System;

namespace Genetico07 {
    class Program {
        static void Main() {
            double minValorX = -3;
            double maxValorX = 2;
            Ecuacion objEcuacion = new Ecuacion();
            objEcuacion.Rango(minValorX, maxValorX);

            Poblacion objPoblacion = new Poblacion();
            int TamanoIndividuo = 30;
            int TotalIndividuos = 50;
            int TotalCiclos = 150000;
            double MejorIndiv = objPoblacion.Proceso(objEcuacion, TamanoIndividuo, TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine(MejorIndiv);
            Console.ReadKey();
        }
    }
}

