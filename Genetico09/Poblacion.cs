/* Juego de aritmética. Uso del operador mutación */
using System;
using System.Collections.Generic;

namespace Genetico09 {
    class Poblacion {
        private List<int[]> Individuos; //Lista de individuos
        private Random azar;

        public Poblacion() {
            Individuos = new List<int[]>();
            azar = new Random();
        }

        public int[] Proceso(string[] operaciones, int numIndividuos, int numCiclos) {
            //Acelera la evaluación al convertir a números los resultados de las operaciones
            int[] resultados = new int[6];
            for (int cont = 0; cont < 6; cont++) {
                string numero = operaciones[cont].Substring(6);
                resultados[cont] = Convert.ToInt32(numero);
            }

            //Crea la población con individuos (las 9 variables del juego de matemática) generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++) {
                int[] valor = new int[9];
                for (int num = 0; num < 9; num++)
                    valor[num] = azar.Next(0, 20);
                Individuos.Add(valor);
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
                double valorIndivA = EvaluaIndividuo(Individuos[indivA], operaciones, resultados);
                double valorIndivB = EvaluaIndividuo(Individuos[indivB], operaciones, resultados);

                //El mejor individuo reemplaza al peor y la copia se muta
                if (valorIndivA < valorIndivB) {
                    CopiaIndividuo(indivA, indivB);
                    Muta(indivB);
                }
                else {
                    CopiaIndividuo(indivB, indivA);
                    Muta(indivA);
                }
            }

            //Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            double MenorValorY = Double.MaxValue;
            for (int cont = 0; cont < Individuos.Count; cont++) {
                double valorIndiv = EvaluaIndividuo(Individuos[cont], operaciones, resultados);
                if (valorIndiv < MenorValorY) {
                    individuoMejor = cont;
                    MenorValorY = valorIndiv;
                }
            }
            return Individuos[individuoMejor];
        }

        //Copia el individuo número a número
        private void CopiaIndividuo(int origen, int destino) {
            for (int cont = 0; cont < 6; cont++)
                Individuos[destino][cont] = Individuos[origen][cont];
        }

        //Evalúa el individuo si se acerca a los resultados esperados
        private int EvaluaIndividuo(int[] Variables, string[] operaciones, int[] resultados) {
            int diferencia = 0;
            int varA=0, varB=0, varC=0;

            for (int cont=0; cont < 6; cont++) {
                //Las 9 variables
                switch (cont) {
                    case 0:
                        varA = Variables[0];
                        varB = Variables[1];
                        varC = Variables[2];
                        break;
                    case 1:
                        varA = Variables[3];
                        varB = Variables[4];
                        varC = Variables[5];
                        break;
                    case 2:
                        varA = Variables[6];
                        varB = Variables[7];
                        varC = Variables[8];
                        break;
                    case 3:
                        varA = Variables[0];
                        varB = Variables[3];
                        varC = Variables[6];
                        break;
                    case 4:
                        varA = Variables[1];
                        varB = Variables[4];
                        varC = Variables[7];
                        break;
                    case 5:
                        varA = Variables[2];
                        varB = Variables[5];
                        varC = Variables[8];
                        break;
                }
                //Trae las operaciones
                char opA = operaciones[cont][1];
                char opB = operaciones[cont][3];

                //Hace la operación y compara con el resultado esperado
                int resultado = RetornaOperacion(varA, opA, varB, opB, varC);
                diferencia += Math.Abs(resultados[cont] - resultado);
            }
            return diferencia;
        }

        //Hace las operaciones y retorna el resultado de estas
        public int RetornaOperacion(int varA, char opA, int varB, char opB, int varC) {
            if (opA == '+' && opB == '+') return varA + varB + varC;
            if (opA == '+' && opB == '-') return varA + varB - varC;
            if (opA == '+' && opB == '*') return varA + varB * varC;
 
            if (opA == '-' && opB == '+') return varA - varB + varC;
            if (opA == '-' && opB == '-') return varA - varB - varC;
            if (opA == '-' && opB == '*') return varA - varB * varC;

            if (opA == '*' && opB == '+') return varA * varB + varC;
            if (opA == '*' && opB == '-') return varA * varB - varC;
            if (opA == '*' && opB == '*') return varA * varB * varC;
 
            return 0;
        }

        //Muta el individuo generando un número entero entre 0 y 19
        private void Muta(int indiv) {
            int pos = azar.Next(7);
            Individuos[indiv][pos] = azar.Next(0, 20);
        }

    }
}
