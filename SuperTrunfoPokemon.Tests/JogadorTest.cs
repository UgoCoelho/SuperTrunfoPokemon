using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperTrunfoPokemon;

namespace SuperTrunfoPokemon.Tests
{
    [TestClass]
    public class JogadorTests
    {
        [TestMethod]
        public void Jogador_DeveArmazenarNomeCorretamente()
        {
            var jogador = new Jogador();
            jogador.Nome = "Player";

            Assert.AreEqual("Player", jogador.Nome);
        }

        [TestMethod]
        public void Jogador_DeveIniciarComBaralhoVazio()
        {
            var jogador = new Jogador();

            Assert.IsNotNull(jogador.Baralho);
            Assert.AreEqual(0, jogador.Baralho.Count);
        }

        [TestMethod]
        public void Jogador_DevePermitirAdicionarCartaAoBaralho()
        {
            var jogador = new Jogador();
            var carta = new Cartas { Nome = "Pikachu" };

            jogador.Baralho.Enqueue(carta);

            Assert.AreEqual(1, jogador.Baralho.Count);
            Assert.AreEqual("Pikachu", jogador.Baralho.Peek().Nome);
        }
    }
}