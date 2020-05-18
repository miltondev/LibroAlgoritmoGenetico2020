using System;

namespace Genetico01 {
    class Cadena {
        //Toma una cadena y le cambia alguna letra al azar
        public string MutaCadena(Random azar, string cadena) {
            int pos = azar.Next(cadena.Length);
            char[] cambia = cadena.ToCharArray();
            cambia[pos] = LetraAzar(azar);
            string nuevo = new string(cambia);
            return nuevo;
        }

        //Retorna en cuantos caracteres coincide cadA con cadB 
        public int EvaluaCadena(string cadA, string cadB) {
            int acum = 0;
            for (int cont = 0; cont < cadA.Length; cont++) {
                if (cadA[cont] == cadB[cont]) acum++;
            }
            return acum;
        }

        //Genera una cadena al azar
        public string CadenaAzar(Random azar, int longitud) {
            string cad = "";
            for (int cont = 1; cont <= longitud; cont++) {
                cad += LetraAzar(azar).ToString();
            }
            return cad;
        }

        //Retorna un caracter al azar
        private char LetraAzar(Random azar) {
            string Permitido = "abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ áéúíóúÁÉÍÓÚÑñ¿?¡!äëïöüÄËÏÖÜ";
            return Permitido[azar.Next(Permitido.Length)];
        }
    }
}