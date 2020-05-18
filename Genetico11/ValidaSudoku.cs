//Algoritmo genético para generar Sudokus completos. Operador mutación

namespace Genetico11 {

    class ValidaSudoku {
        private int[,] tablero;

        //Constructor donde se crea el tablero de sudoku para hacer validaciones
        public ValidaSudoku() {
            tablero = new int[9, 9];
        }

        //Evalúa si el individuo es viable como sudoku
        public int EvaluaSudoku(int[] individuo) {
            int puntaje = 0;

            //Pone el individuo (que es un arreglo unidimensional) dentro de un tablero de sudoku
            for (int cont = 0, fila = 0, columna = 0; cont < individuo.Length; cont++) {
                tablero[fila, columna++] = individuo[cont];
                if (columna == 9) {
                    columna = 0;
                    fila++;
                }
            }

            //Evalua las filas
            for (int fila = 0; fila < 9; fila++)
                for (int num = 1; num <= 9; num++)
                    puntaje += NumeroFila(num, fila);
            //Console.WriteLine("Filas =" + puntaje.ToString());


            //Evalua las columnas
            for (int columna = 0; columna < 9; columna++)
                for (int num = 1; num <= 9; num++)
                    puntaje += NumeroColumna(num, columna);
            //Console.WriteLine("Columnas =" + puntaje.ToString());

            //Evalua los cuadros internos
            for (int fila = 0; fila <= 6; fila += 3)
                for (int columna = 0; columna <= 6; columna += 3)
                    puntaje += Cuadrointerno(fila, columna);
            //Console.WriteLine("Interno =" + puntaje.ToString());

            return puntaje;
        }

        //Retorna 1 si el número existe y no está repetido. 0 en caso contrario.
        private int NumeroFila(int num, int fila) {
            int cuenta = 0;
           for (int columna = 0; columna < 9; columna++)
                if (tablero[fila, columna] == num)
                    cuenta++;

            if (cuenta == 1) return 1;
            return 0;
        }

        //Retorna 1 si el número existe y no está repetido. 0 en caso contrario.
        private int NumeroColumna(int num, int columna) {
            int cuenta = 0;
            for (int fila = 0; fila < 9; fila++)
                if (tablero[fila, columna] == num)
                    cuenta++;

            if (cuenta == 1) return 1;
            return 0;
        }

        //Evalúa puntaje de cada cuadro interno
        private int Cuadrointerno(int fila, int columna) {
            int puntaje = 0;
            for (int num = 1; num <= 9; num++) {
                int cuenta = 0;
                if (tablero[fila, columna] == num) cuenta++;
                if (tablero[fila, columna + 1] == num) cuenta++;
                if (tablero[fila, columna + 2] == num) cuenta++;
                if (tablero[fila + 1, columna] == num) cuenta++;
                if (tablero[fila + 1, columna + 1] == num) cuenta++;
                if (tablero[fila + 1, columna + 2] == num) cuenta++;
                if (tablero[fila + 2, columna] == num) cuenta++;
                if (tablero[fila + 2, columna + 1] == num) cuenta++;
                if (tablero[fila + 2, columna + 2] == num) cuenta++;
                if (cuenta == 1) puntaje++;
            }
            return puntaje;
        }

    }
}
