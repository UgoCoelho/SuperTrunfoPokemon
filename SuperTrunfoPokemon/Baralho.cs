using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTrunfoPokemon
{
    public static class Baralho
    {
        public static List<Cartas> CriarBaralho()
        {
            var cartas = new List<Cartas>()
        {
            // 🔥 Atacantes físicos
            new Cartas { Nome = "Excadrill", Hp = 110, Attack = 135, Defense = 60, SpAttack = 50, SpDefense = 65, Speed = 88, Grupo = "D"},
            new Cartas { Nome = "Garchomp", Hp = 108, Attack = 130, Defense = 95, SpAttack = 80, SpDefense = 85, Speed = 102, Grupo = "A" },
            new Cartas { Nome = "Conkeldurr", Hp = 105, Attack = 140, Defense = 95, SpAttack = 55, SpDefense = 65, Speed = 45, Grupo = "C" },

            // 🔮 Atacantes especiais
            new Cartas { Nome = "Chandelure", Hp = 60, Attack = 55, Defense = 90, SpAttack = 145, SpDefense = 90, Speed = 80, Grupo = "D" },
            new Cartas { Nome = "Greninja", Hp = 72, Attack = 95, Defense = 67, SpAttack = 103, SpDefense = 71, Speed = 122, Grupo = "D" },
            new Cartas { Nome = "Lucario", Hp = 70, Attack = 110, Defense = 70, SpAttack = 115, SpDefense = 70, Speed = 90, Grupo = "C" },

            // 🛡️ Defensores físicos
            new Cartas { Nome = "Ferrothorn", Hp = 74, Attack = 94, Defense = 131, SpAttack = 54, SpDefense = 116, Speed = 20, Grupo = "B" },
            new Cartas { Nome = "Hippowdon", Hp = 108, Attack = 112, Defense = 118, SpAttack = 68, SpDefense = 72, Speed = 47, Grupo = "B"},

            // 🧠 Defensores especiais
            new Cartas { Nome = "Goodra", Hp = 90, Attack = 100, Defense = 70, SpAttack = 110, SpDefense = 150, Speed = 80, Grupo = "D" },
            new Cartas { Nome = "Sylveon", Hp = 95, Attack = 65, Defense = 65, SpAttack = 110, SpDefense = 130, Speed = 60, Grupo = "C" },

            // ⚡ Rápidos
            new Cartas { Nome = "Talonflame", Hp = 78, Attack = 81, Defense = 71, SpAttack = 74, SpDefense = 69, Speed = 126, Grupo = "A" },
            new Cartas { Nome = "Weavile", Hp = 70, Attack = 120, Defense = 65, SpAttack = 45, SpDefense = 85, Speed = 125, Grupo = "B" },

            // ❤️ Alto HP / equilibrados
            new Cartas { Nome = "Snorlax", Hp = 160, Attack = 110, Defense = 65, SpAttack = 65, SpDefense = 110, Speed = 30, Grupo = "A" },
            new Cartas { Nome = "Togekiss", Hp = 85, Attack = 50, Defense = 95, SpAttack = 120, SpDefense = 115, Speed = 80, Grupo = "C" },
            new Cartas { Nome = "Volcarona", Hp = 85, Attack = 60, Defense = 65, SpAttack = 135, SpDefense = 105, Speed = 100, Grupo = "B" },

            // ⭐ Super Trunfo
            new Cartas { Nome = "Arceus", Hp = 120, Attack = 120, Defense = 120, SpAttack = 120, SpDefense = 120, Speed = 120, IsSuperTrunfo = true, Grupo = "A" }
        };

            return cartas;
        }


        // 🎲 Embaralhar cartas (Fisher-Yates)
        public static void Embaralhar(List<Cartas> cartas)
        {
            Random rng = new Random();

            int n = cartas.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                var temp = cartas[k];
                cartas[k] = cartas[n];
                cartas[n] = temp;
            }
        }

        // 👥 Distribuir entre jogadores
        public static void Distribuir(List<Cartas> cartas, Jogador j1, Jogador j2)
        {
            j1.Baralho = new Queue<Cartas>();
            j2.Baralho = new Queue<Cartas>();

            for (int i = 0; i < cartas.Count; i++)
            {
                if (i % 2 == 0)
                    j1.Baralho.Enqueue(cartas[i]);
                else
                    j2.Baralho.Enqueue(cartas[i]);
            }
        }
    }
}

