using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTrunfoPokemon
{
    public class Partida
    {

        private Jogador jogador1;
        private Jogador jogador2;

        public Partida(string nome1, string nome2)
        {
            jogador1 = new Jogador { Nome = nome1 };
            jogador2 = new Jogador { Nome = nome2 };
        }

        public void Iniciar()
        {
            var cartas = Baralho.CriarBaralho();
            Baralho.Embaralhar(cartas);
            Baralho.Distribuir(cartas, jogador1, jogador2);

            Console.WriteLine("Partida iniciada!");

            while (jogador1.Baralho.Count > 0 && jogador2.Baralho.Count > 0)
            {
                JogarRodada();

                Console.WriteLine($"\nCartas restantes:");
                Console.WriteLine($"{jogador1.Nome}: {jogador1.Baralho.Count}");
                Console.WriteLine($"{jogador2.Nome}: {jogador2.Baralho.Count}");

                Console.ReadKey();
            }

            VerificarVencedor();
        }

        private void JogarRodada()
        {
            var carta1 = jogador1.Baralho.Dequeue();
            var carta2 = jogador2.Baralho.Dequeue();

            Console.WriteLine($"\nCarta de {jogador1.Nome}:");
            MostrarCarta(carta1);



            int escolha = EscolherAtributo(carta1);

            int valor1 = 0, valor2 = 0;

            switch (escolha)
            {
                case 1: valor1 = carta1.Hp; valor2 = carta2.Hp; break;
                case 2: valor1 = carta1.Attack; valor2 = carta2.Attack; break;
                case 3: valor1 = carta1.Defense; valor2 = carta2.Defense; break;
                case 4: valor1 = carta1.SpAttack; valor2 = carta2.SpAttack; break;
                case 5: valor1 = carta1.SpDefense; valor2 = carta2.SpDefense; break;
                case 6: valor1 = carta1.Speed; valor2 = carta2.Speed; break;
            }

            Console.WriteLine($"\nCarta de {jogador2.Nome}:");
            MostrarCarta(carta2);
            Console.WriteLine($"\n---{jogador1.Nome}: {valor1} vs {jogador2.Nome}: {valor2}---");
            ResolverRodada(carta1, carta2, valor1, valor2);
        }

        private int EscolherAtributo(Cartas carta)
        {
            Console.WriteLine("\nEscolha um atributo:");
            Console.WriteLine("1 - HP | 2 - Attack | 3 - Defense | 4 - SpAttack | 5 - SpDefense | 6 - Speed |");

            return int.Parse(Console.ReadLine());
        }

        public void ResolverRodada(Cartas c1, Cartas c2, int v1, int v2) 
        {
            // Super Trunfo 
            if (c1.IsSuperTrunfo || c2.IsSuperTrunfo)
            {
                // c1 é Arceus
                if (c1.IsSuperTrunfo && !c2.IsSuperTrunfo)
                {
                    if (c2.Grupo == "A" && v2 > v1)
                    {
                        Console.WriteLine($"==={jogador2.Nome} derrotou o Arceus com Grupo A!===");
                        jogador2.Baralho.Enqueue(c1);
                        jogador2.Baralho.Enqueue(c2);
                    }
                    else
                    {
                        Console.WriteLine($"==={jogador1.Nome} venceu com Arceus!===");
                        jogador1.Baralho.Enqueue(c1);
                        jogador1.Baralho.Enqueue(c2);

                    }
                    return;
                }

                // c2 é Arceus
                if (c2.IsSuperTrunfo && !c1.IsSuperTrunfo)
                {
                    if (c1.Grupo == "A" && v1 > v2)
                    {
                        Console.WriteLine($"{jogador1.Nome} derrotou o Arceus com Grupo A!");
                        jogador1.Baralho.Enqueue(c1);
                        jogador1.Baralho.Enqueue(c2);
                    }
                    else
                    {
                        Console.WriteLine($"==={jogador2.Nome} venceu com Arceus!===");
                        jogador2.Baralho.Enqueue(c1);
                        jogador2.Baralho.Enqueue(c2);
                    }
                    return;
                }
            }
            // 🔥 CASO NORMAL (SEM ARCEUS)
            if (v1 > v2)
            {
                Console.WriteLine($"==={jogador1.Nome} venceu!===");
                jogador1.Baralho.Enqueue(c1);
                jogador1.Baralho.Enqueue(c2);
            }
            else if (v2 > v1)
            {
                Console.WriteLine($"==={jogador2.Nome} venceu!===");
                jogador2.Baralho.Enqueue(c1);
                jogador2.Baralho.Enqueue(c2);
            }
            else
            {
                Console.WriteLine("===Empate!===");
                jogador1.Baralho.Enqueue(c1);
                jogador2.Baralho.Enqueue(c2);
            }
        }
     
     

        private void VerificarVencedor()
        {
            if (jogador1.Baralho.Count > 0)
                Console.WriteLine($"\n==={jogador1.Nome} venceu o jogo!===");
            else
                Console.WriteLine($"\n==={jogador2.Nome} venceu o jogo!===");
        }

        private void MostrarCarta(Cartas carta)
        {
            Console.WriteLine($"\n=== {carta.Nome} ===");
            Console.WriteLine($"[1]HP: {carta.Hp}");
            Console.WriteLine($"[2]Attack: {carta.Attack}");
            Console.WriteLine($"[3]Defense: {carta.Defense}");
            Console.WriteLine($"[4]Sp. Attack: {carta.SpAttack}");
            Console.WriteLine($"[5]Sp. Defense: {carta.SpDefense}");
            Console.WriteLine($"[6]Speed: {carta.Speed}");
            Console.WriteLine($"[Grupo]:{carta.Grupo}");

            if (carta.IsSuperTrunfo)
                Console.WriteLine("!![SUPER TRUNFO]!!");
        }
    }
}
    

