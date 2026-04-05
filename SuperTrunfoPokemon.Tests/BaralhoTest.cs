using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperTrunfoPokemon;
using System.Collections.Generic;
using System.Linq;

namespace SuperTrunfoPokemon.Tests
{
    [TestClass]
    public class BaralhoTests
    {
        [TestMethod]
        public void CriarBaralho_DeveRetornar16Cartas()
        {
            var cartas = Baralho.CriarBaralho();

            Assert.IsNotNull(cartas);
            Assert.AreEqual(16, cartas.Count);
        }

        [TestMethod]
        public void CriarBaralho_DeveConterArceusComoSuperTrunfo()
        {
            var cartas = Baralho.CriarBaralho();
            var arceus = cartas.FirstOrDefault(c => c.Nome == "Arceus");

            Assert.IsNotNull(arceus);
            Assert.IsTrue(arceus.IsSuperTrunfo);
        }

        [TestMethod]
        public void CriarBaralho_DeveConterApenasUmSuperTrunfo()
        {
            var cartas = Baralho.CriarBaralho();

            int quantidadeSuperTrunfo = cartas.Count(c => c.IsSuperTrunfo);

            Assert.AreEqual(1, quantidadeSuperTrunfo);
        }

        [TestMethod]
        public void CriarBaralho_DeveConterCartasConhecidas()
        {
            var cartas = Baralho.CriarBaralho();

            Assert.IsTrue(cartas.Any(c => c.Nome == "Garchomp"));
            Assert.IsTrue(cartas.Any(c => c.Nome == "Lucario"));
            Assert.IsTrue(cartas.Any(c => c.Nome == "Snorlax"));
            Assert.IsTrue(cartas.Any(c => c.Nome == "Arceus"));
        }

        [TestMethod]
        public void CriarBaralho_ArceusDeveTerTodosOsAtributos120()
        {
            var cartas = Baralho.CriarBaralho();
            var arceus = cartas.First(c => c.Nome == "Arceus");

            Assert.AreEqual(120, arceus.Hp);
            Assert.AreEqual(120, arceus.Attack);
            Assert.AreEqual(120, arceus.Defense);
            Assert.AreEqual(120, arceus.SpAttack);
            Assert.AreEqual(120, arceus.SpDefense);
            Assert.AreEqual(120, arceus.Speed);
        }

        [TestMethod]
        public void Embaralhar_NaoDeveAlterarQuantidadeDeCartas()
        {
            var cartas = Baralho.CriarBaralho();
            int quantidadeAntes = cartas.Count;

            Baralho.Embaralhar(cartas);

            Assert.AreEqual(quantidadeAntes, cartas.Count);
        }

        [TestMethod]
        public void Embaralhar_NaoDevePerderNemDuplicarCartas()
        {
            var cartas = Baralho.CriarBaralho();
            var nomesAntes = cartas.Select(c => c.Nome).OrderBy(n => n).ToList();

            Baralho.Embaralhar(cartas);

            var nomesDepois = cartas.Select(c => c.Nome).OrderBy(n => n).ToList();

            CollectionAssert.AreEqual(nomesAntes, nomesDepois);
        }

        [TestMethod]
        public void Distribuir_DeveDar8CartasParaCadaJogador()
        {
            var cartas = Baralho.CriarBaralho();
            var jogador1 = new Jogador { Nome = "Player" };
            var jogador2 = new Jogador { Nome = "CPU" };

            Baralho.Distribuir(cartas, jogador1, jogador2);

            Assert.AreEqual(8, jogador1.Baralho.Count);
            Assert.AreEqual(8, jogador2.Baralho.Count);
        }

        [TestMethod]
        public void Distribuir_DeveDistribuirAlternadamente()
        {
            var cartas = new List<Cartas>
            {
                new Cartas { Nome = "Carta1" },
                new Cartas { Nome = "Carta2" },
                new Cartas { Nome = "Carta3" },
                new Cartas { Nome = "Carta4" }
            };

            var jogador1 = new Jogador { Nome = "Player" };
            var jogador2 = new Jogador { Nome = "CPU" };

            Baralho.Distribuir(cartas, jogador1, jogador2);

            Assert.AreEqual(2, jogador1.Baralho.Count);
            Assert.AreEqual(2, jogador2.Baralho.Count);

            Assert.AreEqual("Carta1", jogador1.Baralho.Dequeue().Nome);
            Assert.AreEqual("Carta3", jogador1.Baralho.Dequeue().Nome);

            Assert.AreEqual("Carta2", jogador2.Baralho.Dequeue().Nome);
            Assert.AreEqual("Carta4", jogador2.Baralho.Dequeue().Nome);
        }

        [TestMethod]
        public void Distribuir_DeveReinicializarOsBaralhosDosJogadores()
        {
            var cartas = new List<Cartas>
            {
                new Cartas { Nome = "Carta1" },
                new Cartas { Nome = "Carta2" }
            };

            var jogador1 = new Jogador { Nome = "Player" };
            var jogador2 = new Jogador { Nome = "CPU" };

            jogador1.Baralho.Enqueue(new Cartas { Nome = "Antiga1" });
            jogador2.Baralho.Enqueue(new Cartas { Nome = "Antiga2" });

            Baralho.Distribuir(cartas, jogador1, jogador2);

            Assert.AreEqual(1, jogador1.Baralho.Count);
            Assert.AreEqual(1, jogador2.Baralho.Count);
            Assert.AreEqual("Carta1", jogador1.Baralho.Peek().Nome);
            Assert.AreEqual("Carta2", jogador2.Baralho.Peek().Nome);
        }
    }
}