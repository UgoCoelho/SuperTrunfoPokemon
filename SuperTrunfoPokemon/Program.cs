using System;

namespace SuperTrunfoPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Partida partida = new Partida("Player", "CPU");
            partida.Iniciar();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}