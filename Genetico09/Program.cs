/* Juego de aritmética. Uso del operador mutación */
using System;

namespace Genetico09 {
    class Program {
        static void Main() {
            /*   Un ejemplo de juego de aritmética
             *   2 - 5 + 9 = 6 
             *   3 + 1 - 8 = -4
             *   4 * 6 + 7 = 31
             *   2 + 3 * 4 = 14
             *   5 - 1 * 6 = -1
             *   9 + 8 - 7 = 10
             *   
             *   Se pone en el algoritmo genético
             *   ¿Podrá deducir los mismos números?
             * */
            string[] operaciones = { "A-B+C=6",
                                     "D+E-F=-4",
                                     "G*H+I=31",
                                     "A+D*G=14",
                                     "B-E*H=-1",
                                     "C+F-I=10" };

            //Proceso de algoritmo genético
            Poblacion objPoblacion = new Poblacion();
            int TotalIndividuos = 1000;
            int TotalCiclos = 1000000;
            int[] MejorIndiv = objPoblacion.Proceso(operaciones, TotalIndividuos, TotalCiclos);

            //Imprime las operaciones
            for (int cont = 0; cont < 6; cont++)
                Console.WriteLine(operaciones[cont]);
            Console.WriteLine(" ");

            //Imprime los valores
            int varA=0, varB=0, varC=0;
            for (int cont = 0; cont < 6; cont++) {
                switch (cont) {
                    case 0:
                        varA = MejorIndiv[0];
                        varB = MejorIndiv[1];
                        varC = MejorIndiv[2];
                        break;
                    case 1:
                        varA = MejorIndiv[3];
                        varB = MejorIndiv[4];
                        varC = MejorIndiv[5];
                        break;
                    case 2:
                        varA = MejorIndiv[6];
                        varB = MejorIndiv[7];
                        varC = MejorIndiv[8];
                        break;
                    case 3:
                        varA = MejorIndiv[0];
                        varB = MejorIndiv[3];
                        varC = MejorIndiv[6];
                        break;
                    case 4:
                        varA = MejorIndiv[1];
                        varB = MejorIndiv[4];
                        varC = MejorIndiv[7];
                        break;
                    case 5:
                        varA = MejorIndiv[2];
                        varB = MejorIndiv[5];
                        varC = MejorIndiv[8];
                        break;
                }

                char opA = operaciones[cont][1];
                char opB = operaciones[cont][3];
                int resultado = objPoblacion.RetornaOperacion(varA, opA, varB, opB, varC);

                Console.Write(varA.ToString() + " ");
                Console.Write(opA.ToString() + " ");
                Console.Write(varB.ToString() + " ");
                Console.Write(opB.ToString() + " ");
                Console.Write(varC.ToString());
                Console.WriteLine(" = " + resultado.ToString());
            }

            Console.ReadKey();
        }
    }
}
