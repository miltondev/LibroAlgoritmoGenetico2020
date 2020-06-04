/* Buscar valor de X. Algoritmo genético: Operador cruce */
using System;
using System.Collections.Generic;

namespace Genetico06 {
    class Poblacion {
        private readonly List<string> Individuos; //Lista de individuos
        private readonly Random azar;

        public Poblacion() {
            Individuos = new List<string>();
            azar = new Random();
        }

        public double Proceso(Ecuacion objEcuacion, int TamanoIndividuo, int numIndividuos, int numCiclos) {

            //Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                Individuos.Add(BooleanoAzar(TamanoIndividuo));
            }

            //Proceso de algoritmo genético
            for (int ciclo = 1; ciclo <= numCiclos; ciclo++) {

                //Toma dos individuos al azar
                int indivA = azar.Next(Individuos.Count);
                int indivB;
                do {
                    indivB = azar.Next(Individuos.Count);
                } while (indivA == indivB); //Asegura que sean dos individuos distintos

                //Usa el operador cruce
                int posAzar = azar.Next(Individuos[indivA].Length);
                string parteA = Individuos[indivA].Substring(0, posAzar);
                string parteB = Individuos[indivB].Substring(posAzar);
                string HijoA = parteA + parteB;

                //Evalúa la adaptación de los dos individuos
                double valorIndivA = objEcuacion.ValorY(Individuos[indivA]);
                double valorIndivB = objEcuacion.ValorY(Individuos[indivB]);
                double valorHijoA = objEcuacion.ValorY(HijoA);

                //Si los hijos son mejores que los padres, entonces los reemplaza
                if (valorHijoA < valorIndivA) Individuos[indivA] = HijoA;
                if (valorHijoA < valorIndivB) Individuos[indivB] = HijoA;

            }

            //Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            double MenorValorY = double.MaxValue;
            for (int cont = 0; cont < Individuos.Count; cont++) {
                double valorIndiv = objEcuacion.ValorY(Individuos[cont]);
                if (valorIndiv < MenorValorY) {
                    individuoMejor = cont;
                    MenorValorY = valorIndiv;
                }
            }
            return objEcuacion.ValorX(Individuos[individuoMejor]);
        }

        //Genera un individuo booleano al azar
        private string BooleanoAzar(int Tamano) {
            string numero = "";
            for (int cont = 1; cont <= Tamano; cont++) {
                if (azar.NextDouble() < 0.5)
                    numero += "1";
                else
                    numero += "0";
            }
            return numero;
        }
    }
}