/* Buscar la ruta en un tablero para visitar determinados puntos. Uso del operador mutación */
using System;

namespace Genetico08 {
    class Program {
        static void Main() {
            //Genera el tablero con los puntos obligados puestos al azar
            int Filas = 10;
            int Columnas = 20;
            int PuntosObligados = 15;
            Tablero objTablero = new Tablero(Filas, Columnas, PuntosObligados);
            objTablero.ImprimeTabla();

            //Proceso de algoritmo genético
            Poblacion objPoblacion = new Poblacion();
            int TamanoIndividuo = 100;
            int TotalIndividuos = 70;
            int TotalCiclos = 10000;
            string MejorIndiv = objPoblacion.Proceso(objTablero, TamanoIndividuo, TotalIndividuos, TotalCiclos);

            //Muestra el individuo mejor adaptado
            Console.WriteLine(MejorIndiv);
            objTablero.HaceCamino(MejorIndiv);
            objTablero.ImprimeTabla();
            Console.ReadKey();
        }
    }
}
