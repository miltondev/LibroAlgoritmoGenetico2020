//Generar cadenas al azar para acertar en cadenaOriginal
using System;

namespace Genetico00 {
    class Program {
        static void Main() {
            //Único generador de números pseudo-aleatorios
            Random azar = new Random();

            //La cadena original
            string cadenaOriginal = "Esta es una prueba de texto";

            //Genera cadenas al azar y ver si en algún momento hay coincidencia
            int longitud = cadenaOriginal.Length;

            //Ciclo para generar cadenas al azar 
            for (int num = 1; num <= 10000; num++) {
                string nuevaCadena = CadenaAzar(azar, longitud);
                if (nuevaCadena == cadenaOriginal)
                    Console.WriteLine("Acertó");
            }

            Console.WriteLine("Finaliza");
            Console.ReadKey();
        }

        //Retorna una cadena al azar
        static string CadenaAzar(Random azar, int longitud) {
            string cad = "";
            for (int cont = 1; cont <= longitud; cont++) {
                cad += LetraAzar(azar);
            }
            return cad;
        }

        //Retorna una letra al azar
        static char LetraAzar(Random azar) {
            string Permitido = "abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            return Permitido[azar.Next(Permitido.Length)];
        }
    }
}
