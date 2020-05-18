/* Búsqueda del máximo de una función.
 * Algoritmo genético: Operador mutación */
using System;
using System.Collections.Generic;

namespace Genetico04 {
    class Poblacion {
        private readonly List<double> Individuos; //Lista de individuos
        private readonly Random azar;

        public Poblacion() {
            Individuos = new List<double>();
            azar = new Random();
        }

        public double Proceso(int numIndividuos, int numCiclos) {

            //Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                Individuos.Add(azar.NextDouble());
            }

            //Proceso de algoritmo genético
            for (int ciclo = 1; ciclo <= numCiclos; ciclo++) {

                //Toma dos individuos al azar
                int indivA = azar.Next(Individuos.Count);
                int indivB;
                do {
                    indivB = azar.Next(Individuos.Count);
                } while (indivA == indivB); //Asegura que sean dos individuos distintos

                //Evalúa la adaptación de los dos individuos
                double valorIndivA = EvaluaEcuacion(Individuos[indivA]);
                double valorIndivB = EvaluaEcuacion(Individuos[indivB]);

                //Si individuo A está mejor adaptado que B entonces: Elimina B + Duplica A + Modifica duplicado
                if (valorIndivA > valorIndivB) {
                    Individuos[indivB] = MutaValor(Individuos[indivA]);
                }
                else { //Caso contrario: Elimina A + Duplica B + Modifica duplicado
                    Individuos[indivA] = MutaValor(Individuos[indivB]);
                }
            }

            //Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            double puntajeMejor = double.MinValue;
            for (int cont = 0; cont < Individuos.Count; cont++) {
                double valorIndiv = EvaluaEcuacion(Individuos[cont]);
                if (valorIndiv > puntajeMejor) {
                    individuoMejor = cont;
                    puntajeMejor = valorIndiv;
                }
            }
            return Individuos[individuoMejor];
        }

        //Retorna el valor de Y de la ecuación dado el valor de X
        private double EvaluaEcuacion(double x) {
            double y = 2 * Math.Pow(x, 6) - 7 * Math.Pow(x, 5);
            y = y - 6 * Math.Pow(x, 4) + 5 * Math.Pow(x, 3);
            y = y - x * x + 3 * x + 3;
            return y;
        }

        //Muta un valor sumando o restando al azar un valor del tipo 0.1, 0.01, 0.001
        private double MutaValor(double x) {
            int potencia = azar.Next(7) + 1;
            double cambio = 1 / Math.Pow(10, potencia);
            if (azar.NextDouble() < 0.5) {
                return x + cambio;
            }
            return x - cambio;
        }
    }
}
