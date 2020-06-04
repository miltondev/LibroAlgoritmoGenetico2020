/* Algoritmo genético: Operador cruce */
using System;
using System.Collections.Generic;

namespace Genetico02 {
    class Poblacion {
        private readonly List<string> Individuos; //Lista de individuos
        private readonly Random azar;

        public Poblacion() {
            Individuos = new List<string>();
            azar = new Random();
        }

        public string Proceso(string cadOriginal, int numIndividuos, int numCiclos) {
            Cadena objCad = new Cadena();

            //Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                Individuos.Add(objCad.CadenaAzar(azar, cadOriginal.Length));
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
                int posAzar = azar.Next(cadOriginal.Length);
                string parteA = Individuos[indivA].Substring(0, posAzar);
                string parteB = Individuos[indivB].Substring(posAzar);
                string HijoA = parteA + parteB;

                //Evalúa la adaptación de los individuos padres e hijos
                int valorIndivA = objCad.EvaluaCadena(cadOriginal, Individuos[indivA]);
                int valorIndivB = objCad.EvaluaCadena(cadOriginal, Individuos[indivB]);
                int valorHijoA = objCad.EvaluaCadena(cadOriginal, HijoA);

                //Si los hijos son mejores que los padres, entonces los reemplaza
                if (valorHijoA > valorIndivA) Individuos[indivA] = HijoA;
                if (valorHijoA > valorIndivB) Individuos[indivB] = HijoA;
            }

            //Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            int puntajeMejor = 0;
            for (int cont = 0; cont < Individuos.Count; cont++) {
                int valorIndiv = objCad.EvaluaCadena(cadOriginal, Individuos[cont]);
                if (valorIndiv > puntajeMejor) {
                    individuoMejor = cont;
                    puntajeMejor = valorIndiv;
                }
            }
            return Individuos[individuoMejor];
        }
    }
}