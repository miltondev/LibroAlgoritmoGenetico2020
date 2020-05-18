/* Buscar valor de X. Algoritmo genético: Operador cruce y mutación */
using System;

namespace Genetico07 {
    class Ecuacion {
        private double minX, maxX;

        //El rango de búsqueda en X para encontrar el mínimo Y
        public void Rango(double minX, double maxX) {
            this.minX = minX;
            this.maxX = maxX;
        }

        //El individuo en binario se convierte a real y 
        //retorna el valor que genera la ecuación
        public double ValorY(string Individuo) {
            double x = ValorX(Individuo);
            double y = -1.78 * Math.Pow(Math.Sin(x), 2);
            y += 6.40 * Math.Pow(Math.Cos(x), 2);
            y += 3.07 * Math.Pow(Math.Sin(x), 3);
            return y;
        }

        //Convierte la representación binaria en dato tipo real
        public double ValorX(string Individuo) {
            double multiplica = (maxX - minX);
            multiplica /= (Math.Pow(2, Individuo.Length) - 1);
            int numero = Convert.ToInt32(Individuo, 2);
            return minX + numero * multiplica;
        }
    }
}
