/* Buscar la ruta en un tablero para visitar determinados puntos. Uso del operador mutación */
using System;

namespace Genetico08 {
    class Tablero {
		private int Filas, Columnas;
		private char[,] tabla;

		//Crea el tablero con los puntos
		public Tablero(int Filas, int Columnas, int Puntos) {
			this.Filas = Filas;
			this.Columnas = Columnas;

			//Tablero lleno con 0s
			int fila, columna;
			tabla = new char[Filas, Columnas];
			for (fila = 0; fila < Filas; fila++)
				for (columna = 0; columna < Columnas; columna++)
					tabla[fila, columna] = '.';

			//Pone los puntos de paso obligado al azar
			Random azar = new Random();
			for (int punto = 1; punto <= Puntos; punto++) {
				do {
					fila = azar.Next(Filas);
					columna = azar.Next(Columnas);
				} while (tabla[fila, columna] == 'p');
				tabla[fila, columna] = 'p';
			}
		}

		//Imprime la tabla
		public void ImprimeTabla() {
			for (int fila = 0; fila < Filas; fila++) {
				Console.WriteLine(" ");
				for (int columna = 0; columna < Columnas; columna++)
					Console.Write(tabla[fila, columna]);
			}
			Console.WriteLine(" ");
			Console.WriteLine(" ");
		}

		//Evalúa la ruta que hace el individuo para ver si visita los puntos obligados
		//Retorna cuantos puntos le queda por visitar. Si es cero entonces ha visitado todos.
		public int EvaluaRuta(string ruta) {
			HaceCamino(ruta);

			//Evalua la efectividad de la ruta.
			int SinVisitar = 0;
			for (int fila = 0; fila < Filas; fila++) {
				for (int columna = 0; columna < Columnas; columna++)
					if (tabla[fila, columna] == 'p')
						SinVisitar++;
			}

			RestauraTabla();

			return SinVisitar; //Si vale cero, entonces ha visitado todos los puntos
		}

		//Trazar el camino
		public void HaceCamino(string ruta) {
			//Inicia siempre en 0,0
			int posF = 0;
			int posC = 0;

			//Pone la ruta en el tablero
			for (int letra = 0; letra < ruta.Length; letra++) {
				switch (ruta[letra]) {
					case 'N': if (posF > 0) posF--; break;
					case 'S': if (posF < this.Filas - 1) posF++; break;
					case 'E': if (posC < this.Columnas - 1) posC++; break;
					case 'O': if (posC > 0 ) posC--; break;
				}

				if (tabla[posF, posC] == '.')
					tabla[posF, posC] = 'x';
				else if (tabla[posF, posC] == 'p')
					tabla[posF, posC] = 'V';
			}
		}

		//Restaura la tabla a sólo puntos y puntos de obligado paso
		private void RestauraTabla() {
			for (int fila = 0; fila < Filas; fila++) {
				for (int columna = 0; columna < Columnas; columna++) {
					if (tabla[fila, columna] == 'x') tabla[fila, columna] = '.';
					if (tabla[fila, columna] == 'V') tabla[fila, columna] = 'p';
				}
			}
		}
	}
}
