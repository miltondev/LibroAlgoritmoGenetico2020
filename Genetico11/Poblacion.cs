//Algoritmo genético para generar Sudokus completos. Operador mutación
using System;
using System.Collections.Generic;

namespace Genetico11 {
    class Poblacion {
        private List<int[]> Individuo;
        private Random azar;

        public Poblacion() {
            Individuo = new List<int[]>();
            azar = new Random();
        }

        public int[] Proceso(int numIndividuos) {

            //Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                int[] valor = new int[81];
                for (int num = 0; num < valor.Length; num++) {
                    valor[num] = azar.Next(1, 10);
                }
                Individuo.Add(valor);
            }

            //Proceso de algoritmo genético
            ValidaSudoku objValida = new ValidaSudoku();
            while (true) {

                //Toma dos conjuntos de individuos al azar
                int indivA = azar.Next(Individuo.Count);
                int indivB;
                do {
                    indivB = azar.Next(Individuo.Count);
                } while (indivA == indivB); //Asegura que sean dos conjuntos distintos

                //Evalúa la adaptación de los dos conjuntos
                int valorIndividuoA = objValida.EvaluaSudoku(Individuo[indivA]);
                int valorIndividuoB = objValida.EvaluaSudoku(Individuo[indivB]);
                if (valorIndividuoA == 243 || valorIndividuoB == 243) break;

                //El mejor conjunto reemplaza al peor y la copia se muta
                if (valorIndividuoA > valorIndividuoB) {
                    CopiaConjunto(indivA, indivB);
                    Muta(indivB);
                }
                else {
                    CopiaConjunto(indivB, indivA);
                    Muta(indivA);
                }
            }

            //Después del ciclo, busca el mejor conjunto de individuos
            int ConjuntoMejor = 0;
            int MayorPuntaje = -1;
            for (int cont = 0; cont < Individuo.Count; cont++) {
                int valorConjunto = objValida.EvaluaSudoku(Individuo[cont]);
                if (valorConjunto > MayorPuntaje) {
                    ConjuntoMejor = cont;
                    MayorPuntaje = valorConjunto;
                }
            }
            return Individuo[ConjuntoMejor];
        }

        private void CopiaConjunto(int origen, int destino) {
            for (int cont = 0; cont < 81; cont++)
                Individuo[destino][cont] = Individuo[origen][cont];
        }

        private void Muta(int indiv) {
            int pos = azar.Next(81);
            int nuevo;
            do {
                nuevo = azar.Next(1, 10);
            } while (Individuo[indiv][pos] == nuevo);
            Individuo[indiv][pos] = nuevo;
        }

        public void ImprimeSudoku(int[] individuo) {
            //Pone el individuo (que es un arreglo unidimensional) dentro de un tablero de sudoku
            for (int cont = 0, columna = 0; cont < individuo.Length; cont++) {
                Console.Write(individuo[cont].ToString() + ",");
                columna++;
                if (columna == 9) {
                    columna = 0;
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
