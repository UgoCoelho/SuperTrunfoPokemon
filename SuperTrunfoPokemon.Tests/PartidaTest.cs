using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperTrunfoPokemon;
using System.Reflection;

namespace SuperTrunfoPokemon.Tests
{
    [TestClass]
    public class PartidaTests
    {
        private static Jogador ObterJogador(Partida partida, string nomeCampo)
        {
            var campo = typeof(Partida).GetField(nomeCampo, BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(campo);

            var valor = campo.GetValue(partida);
            Assert.IsNotNull(valor);

            return (Jogador)valor;
        }

        [TestMethod]
        public void ResolverRodada_QuandoJogador1TemValorMaior_DeveAdicionarAsDuasCartasAoBaralhoDoJogador1()
        {
            var partida = new Partida("Player", "CPU");
            var jogador1 = ObterJogador(partida, "jogador1");
            var jogador2 = ObterJogador(partida, "jogador2");

            var c1 = new Cartas { Nome = "Pikachu" };
            var c2 = new Cartas { Nome = "Bulbasaur" };

            partida.ResolverRodada(c1, c2, 100, 80);

            Assert.AreEqual(2, jogador1.Baralho.Count);
            Assert.AreEqual(0, jogador2.Baralho.Count);
        }

        [TestMethod]
        public void ResolverRodada_QuandoJogador2TemValorMaior_DeveAdicionarAsDuasCartasAoBaralhoDoJogador2()
        {
            var partida = new Partida("Player", "CPU");
            var jogador1 = ObterJogador(partida, "jogador1");
            var jogador2 = ObterJogador(partida, "jogador2");

            var c1 = new Cartas { Nome = "Charmander" };
            var c2 = new Cartas { Nome = "Squirtle" };

            partida.ResolverRodada(c1, c2, 70, 95);

            Assert.AreEqual(0, jogador1.Baralho.Count);
            Assert.AreEqual(2, jogador2.Baralho.Count);
        }

        [TestMethod]
        public void ResolverRodada_QuandoEmpata_CadaJogadorDeveReceberSuaPropriaCarta()
        {
            var partida = new Partida("Player", "CPU");
            var jogador1 = ObterJogador(partida, "jogador1");
            var jogador2 = ObterJogador(partida, "jogador2");

            var c1 = new Cartas { Nome = "Gengar" };
            var c2 = new Cartas { Nome = "Alakazam" };

            partida.ResolverRodada(c1, c2, 90, 90);

            Assert.AreEqual(1, jogador1.Baralho.Count);
            Assert.AreEqual(1, jogador2.Baralho.Count);
        }

        [TestMethod]
        public void ResolverRodada_GrupoAComValorMaior_DeveVencerArceus()
        {
            var partida = new Partida("Player", "CPU");
            var jogador1 = ObterJogador(partida, "jogador1");
            var jogador2 = ObterJogador(partida, "jogador2");

            var arceus = new Cartas { Nome = "Arceus", IsSuperTrunfo = true };
            var cartaForte = new Cartas { Nome = "Garchomp", Grupo = "A" };

            partida.ResolverRodada(arceus, cartaForte, 100, 130);

            Assert.AreEqual(0, jogador1.Baralho.Count);
            Assert.AreEqual(2, jogador2.Baralho.Count);
        }

        [TestMethod]
        public void ResolverRodada_ArceusContraGrupoNaoA_SempreVencer()
        {
            var partida = new Partida("Player", "CPU");
            var jogador1 = ObterJogador(partida, "jogador1");
            var jogador2 = ObterJogador(partida, "jogador2");

            var arceus = new Cartas
            {
                Nome = "Arceus",
                IsSuperTrunfo = true
            };

            var cartaFraca = new Cartas
            {
                Nome = "Lucario",
                Grupo = "C"
            };

            partida.ResolverRodada(arceus, cartaFraca, 100, 130);

            Assert.AreEqual(2, jogador1.Baralho.Count);
            Assert.AreEqual(0, jogador2.Baralho.Count);
        }
    }
}