/* Buscar valor de X. Algoritmo genético: Operador mutación */
using System;
using System.Collections.Generic;

namespace Genetico05 {
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

                //Evalúa la adaptación de los dos individuos
                double valorIndivA = objEcuacion.ValorY(Individuos[indivA]);
                double valorIndivB = objEcuacion.ValorY(Individuos[indivB]);

                //Si individuo A está mejor adaptado que B entonces: Elimina B + Duplica A + Modifica duplicado
                if (valorIndivA < valorIndivB) {
                    CopiayMuta(indivB, indivA);
                }
                else { //Caso contrario: Elimina A + Duplica B + Modifica duplicado
                    CopiayMuta(indivA, indivB);
                }
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

        //Copia el ganador sobre el perdedor y modifica la copia
        private void CopiayMuta(int indPerdedor, int indGanador) {
            //Copia el inviduo ganador sobre el perdedor
            Individuos[indPerdedor] = Individuos[indGanador];

            //Muta la copia
            char[] numeros = Individuos[indPerdedor].ToCharArray();
            int pos = azar.Next(Individuos[indPerdedor].Length);
            if (numeros[pos] == '0')
                numeros[pos] = '1';
            else
                numeros[pos] = '0';
            Individuos[indPerdedor] = new string(numeros);
        }
    }
}