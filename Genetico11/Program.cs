//Algoritmo genético para generar Sudokus completos. Operador mutación
using System;

namespace Genetico11 {
    class Program {
        static void Main() {
            //Proceso de algoritmo genético
            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 50;
            int[] individuo = objPoblacion.Proceso(TotalIndividuos);

            objPoblacion.ImprimeSudoku(individuo);
            Console.ReadKey();
        }
    }
}
