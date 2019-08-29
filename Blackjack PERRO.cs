﻿using System;

namespace Blackjack3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Para ganar, debe sacar 21 en el valor total de las cartas que solicites.");

            Random aleatorio = new Random();


            int jugador = 0, max = 0, max2 = 0, contadorNombres = 0;
            string nmax = "x", nombre = "z", segundoPuesto="w";

            Console.WriteLine("Ingrese el numero de jugadores (minimo 2, máximo 5)");
            int j = int.Parse(Console.ReadLine());
            int[] puntaje = new int[j];           //Guarda los puntajes
            string[] jugadores = new string[j];   //Guarda los nombres
           

            while (j < 2 || j > 5)
            {
                Console.WriteLine("Error. Mínimo DOS (2) jugadores y máximo CINCO (5)");
                j = int.Parse(Console.ReadLine());
            }

            while (jugador < j)
            {
                int carta1 = 0, carta2 = 0, total = 0, carta = 0;
                string continuar = "s";
                jugador++;
                Console.WriteLine("Bienvenido jugador:" + jugador);
                Console.Write("Ingrese su nombre: ");
                nombre = (Console.ReadLine());
                jugadores[contadorNombres] = nombre;
              

                carta1 = aleatorio.Next(1, 11);
                carta2 = aleatorio.Next(1, 11);
                total = carta1 + carta2;
                Console.WriteLine("Sus cartas son: " + carta1 + " y " + carta2);
                Console.WriteLine("Su acumulado es: " + total);
                Console.Write("Deseas continuar? (s/n): ");
                continuar = Console.ReadLine();
                while (continuar == "s" && total < 21)
                {
                    carta = aleatorio.Next(1, 11);
                    Console.WriteLine("Su nueva carta es:  " + carta);
                    total += carta;
                    Console.WriteLine("Total: " + total);

                    if (total < 22)
                    {
                        Console.Write("Deseas continuar? (s/n): ");
                        continuar = Console.ReadLine();
                        while (continuar != "s" && continuar != "n")
                        {
                            Console.Write("¡Error!, Deseas continuar? (s/n): ");
                            continuar = Console.ReadLine();
                        }

                        
                        if (total == 21) Console.WriteLine("¡Ha ganado!");
                    }
                    else
                    {
                        Console.WriteLine("¡Ha sido eliminado!");
                        total = 0;
                        break;
                    }
                    
                }
                contadorNombres++;
                puntaje[jugador - 1] = total;

                Console.WriteLine("El puntaje del jugador " + jugador + " es " + puntaje[jugador - 1]);
            }
            Console.WriteLine("El ganador fue: " + nmax);
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (puntaje[i] > max) max = puntaje[i];
                if (puntaje[i] == max) nmax = nombre;
                Console.WriteLine("Resultados: ");
                Console.WriteLine("Puntaje del jugador " + (i + 1) + ": " + puntaje[i]);
            }

            for (int i = 0; i < jugadores.Length; i++)
            {
                if((puntaje[i] > max2) && (max != puntaje[i]))
                {
                    max2 = puntaje[i];
                    segundoPuesto = jugadores[i];
                }
            }
            Console.WriteLine(max);
            Console.WriteLine("El primer lugar es del jugador: " + nmax);
            Console.WriteLine("El segundo lugar es del jugador: " + segundoPuesto);
            Console.ReadKey();

          
        }
    }
}
