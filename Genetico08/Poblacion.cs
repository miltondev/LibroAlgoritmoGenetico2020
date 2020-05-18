/* Buscar la ruta en un tablero para visitar determinados puntos. Uso del operador mutación */
using System;
using System.Collections.Generic;


namespace Genetico08 {
    class Poblacion {
        private readonly List<string> Individuos; //Lista de individuos
        private readonly Random azar;

        public Poblacion() {
            Individuos = new List<string>();
            azar = new Random();
        }

        public string Proceso(Tablero objTablero, int TamanoIndividuo, int numIndividuos, int numCiclos) {

            //Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                Individuos.Add(RutaAzar(TamanoIndividuo));
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
                double valorIndivA = objTablero.EvaluaRuta(Individuos[indivA]);
                double valorIndivB = objTablero.EvaluaRuta(Individuos[indivB]);

                //El mejor individuo reemplaza al peor y la copia se muta
                if (valorIndivA < valorIndivB) {
                    Individuos[indivB] = Individuos[indivA];
                    Muta(indivB);
                }
                else {
                    Individuos[indivA] = Individuos[indivB];
                    Muta(indivA);
                }
            }

            //Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            int MenorValorY = 99999;
            for (int cont = 0; cont < Individuos.Count; cont++) {
                int valorIndiv = objTablero.EvaluaRuta(Individuos[cont]);
                if (valorIndiv < MenorValorY) {
                    individuoMejor = cont;
                    MenorValorY = valorIndiv;
                }
            }
            return Individuos[individuoMejor];
        }

        //Genera un individuo ruta al azar
        private string RutaAzar(int Tamano) {
            string ruta = "";
            string permite = "SE";
            for (int cont = 1; cont <= Tamano; cont++) {
                int pos = azar.Next(permite.Length);
                ruta += permite[pos];
                switch (permite[pos]) {
                    case 'N': permite = "NEO"; break;
                    case 'S': permite = "SEO"; break;
                    case 'E': permite = "ENS"; break;
                    case 'O': permite = "ONS"; break;
                }
            }
            return ruta;
        }

        //Muta individuos
        private void Muta(int individuo) {
            string permite = "";
            char[] cambia = Individuos[individuo].ToCharArray();
            int posAzar = azar.Next(Individuos[individuo].Length);
            switch (cambia[posAzar]) {
                case 'N': permite = "SEO"; break;
                case 'S': permite = "NEO"; break;
                case 'E': permite = "NSO"; break;
                case 'O': permite = "NSE"; break;
            }
            int nuevo = azar.Next(permite.Length);
            cambia[posAzar] = permite[nuevo];
            Individuos[individuo] = new string(cambia);
        }
    }
}
