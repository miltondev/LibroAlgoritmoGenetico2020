//Algoritmo genético para ubicar las reinas de un ajedrez sin que se ataquen entre sí. Operador mutación
using System;

namespace Genetico10 {
    class Program {
        static void Main() {
            int tamTablero = 15; //Tamaño del tablero cuadrado a ubicar las reinas

            //Proceso de algoritmo genético
            Poblacion objPoblacion = new Poblacion(tamTablero);
            int TotalIndividuos = 30;
            int TotalCiclos = 10000;
            int[] Reinas = objPoblacion.Proceso(TotalIndividuos, TotalCiclos);

            objPoblacion.ImprimeTablero(Reinas);
            Console.ReadKey();
        }
    }
}
