//Algoritmo genético para ubicar las reinas de un ajedrez sin que se ataquen entre sí. Operador mutación
using System;
using System.Collections.Generic;

namespace Genetico10 {
    class Poblacion {
        private List<int[]> Reinas; //Lista de conjuntos de reinas
        private Random azar;
        private char[,] Tablero;

        public Poblacion(int tamTablero) {
            Reinas = new List<int[]>();
            azar = new Random();
            Tablero = new char[tamTablero, tamTablero];
        }

        public int[] Proceso(int numIndividuos, int numCiclos) {
            //Crea la población con individuos (reinas) generados al azar
            //En un principio las posiciones de las reinas sería [0,1,2,3,4,5,6,7,8,..., tamTablero-1]	
            for (int cont = 1; cont <= numIndividuos; cont++) {
                int[] valor = new int[Tablero.GetLength(0)];
                for (int num = 0; num < Tablero.GetLength(0); num++) valor[num] = num;
                Reinas.Add(valor);
            }

            //Proceso de algoritmo genético
            for (int ciclo = 1; ciclo <= numCiclos; ciclo++) {

                //Toma dos conjuntos de reinas al azar
                int conjuntoA = azar.Next(Reinas.Count);
                int conjuntoB;
                do {
                    conjuntoB = azar.Next(Reinas.Count);
                } while (conjuntoA == conjuntoB); //Asegura que sean dos conjuntos distintos

                //Evalúa la adaptación de los dos conjuntos
                int valorConjuntoA = EvaluaReinas(conjuntoA);
                int valorConjuntoB = EvaluaReinas(conjuntoB);

                //El mejor conjunto reemplaza al peor y la copia se muta
                if (valorConjuntoA > valorConjuntoB) {
                    CopiaConjunto(conjuntoA, conjuntoB);
                    Muta(conjuntoB);
                }
                else {
                    CopiaConjunto(conjuntoB, conjuntoA);
                    Muta(conjuntoA);
                }
            }

            //Después del ciclo, busca el mejor conjunto de reinas
            int ConjuntoMejor = 0;
            int MayorNumReinas = -1;
            for (int cont = 0; cont < Reinas.Count; cont++) {
                int valorConjunto = EvaluaReinas(cont);
                if (valorConjunto > MayorNumReinas) {
                    ConjuntoMejor = cont;
                    MayorNumReinas = valorConjunto;
                }
            }

            return Reinas[ConjuntoMejor];
        }

        private void CopiaConjunto(int origen, int destino) {
            for (int cont = 0; cont < Tablero.GetLength(0); cont++)
                Reinas[destino][cont] = Reinas[origen][cont];
        }

        private void Muta(int indiv) {
            int posA = azar.Next(Tablero.GetLength(0));
            int posB;
            do {
                posB = azar.Next(Tablero.GetLength(0));
            } while (posA == posB); //Asegura que sean dos posiciones distintas

            //Intercambia posiciones de la reina
            int temp = Reinas[indiv][posA];
            Reinas[indiv][posA] = Reinas[indiv][posB];
            Reinas[indiv][posB] = temp;
        }

        public int EvaluaReinas(int conjunto) {
            IniciaTablero();
            
            //Ataque de las reinas
            for(int columna=0; columna < Tablero.GetLength(0); columna++) {
                int fila = Reinas[conjunto][columna];
                AtaqueReina(fila, columna);
            }

            //Cuenta el número de R que quedan en el tablero
            int numeroR = 0;
            for(int fila=0; fila < Tablero.GetLength(0); fila++)
                for(int columna=0; columna < Tablero.GetLength(0); columna++) {
                    if (Tablero[fila, columna] == 'R') numeroR++;
                }

            return numeroR;
        }

        //Inicializa el tablero
        public void IniciaTablero() {
            for (int fila = 0; fila < Tablero.GetLength(0); fila++)
                for (int columna = 0; columna < Tablero.GetLength(0); columna++)
                    Tablero[fila, columna] = '.';
        }

        //Pone x en el ataque de la Reina
        public void AtaqueReina(int fila, int columna) {
            int ataque = 0;
            while (fila - ataque >= 0 && columna - ataque >= 0) {
                Tablero[fila - ataque, columna - ataque] = 'x';
                ataque++;
            }
                
            ataque = 0;
            while (fila + ataque < Tablero.GetLength(0) && columna + ataque < Tablero.GetLength(0)) {
                Tablero[fila + ataque, columna + ataque] = 'x';
                ataque++;
            }

            ataque = 0;
            while (fila - ataque >= 0 && columna + ataque < Tablero.GetLength(0)) {
                Tablero[fila - ataque, columna + ataque] = 'x';
                ataque++;
            }
            
            ataque = 0;
            while (fila + ataque < Tablero.GetLength(0) && columna - ataque >= 0) {
                Tablero[fila + ataque, columna - ataque] = 'x';
                ataque++;
            }
            
            ataque = 0;
            while (fila + ataque < Tablero.GetLength(0)) {
                Tablero[fila + ataque, columna] = 'x';
                ataque++;
            }

            ataque = 0;
            while (fila - ataque >= 0) {
                Tablero[fila - ataque, columna] = 'x';
                ataque++;
            }
            
            ataque = 0;
            while (columna + ataque < Tablero.GetLength(0)) {
                Tablero[fila, columna + ataque] = 'x';
                ataque++;
            }
            
            ataque = 0;
            while (columna - ataque >= 0) {
                Tablero[fila, columna - ataque] = 'x';
                ataque++;
            }

            Tablero[fila, columna] = 'R';
        }

        public void ImprimeTablero(int[] Reinas) {
            /* Imprime el conjunto */
            Console.Write("Ubicación reinas: ");
            for (int num = 0; num < Reinas.Length; num++)
                Console.Write(Reinas[num].ToString() + ", ");
            Console.WriteLine(" ");

            IniciaTablero();

            //Ataque de las reinas
            for (int columna = 0; columna < Tablero.GetLength(0); columna++) {
                int fila = Reinas[columna];
                AtaqueReina(fila, columna);
            }

            for (int fila = 0; fila < Tablero.GetLength(0); fila++) {
                Console.WriteLine(" ");
                for (int columna = 0; columna < Tablero.GetLength(0); columna++)
                    Console.Write(Tablero[fila, columna]);
            }
        }
    }
}
