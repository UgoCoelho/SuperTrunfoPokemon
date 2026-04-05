using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperTrunfoPokemon;

namespace SuperTrunfoPokemon.Tests
{
    [TestClass]
    public class CartasTests
    {
        [TestMethod]
        public void Carta_DeveArmazenarAtributosCorretamente()
        {
            var carta = new Cartas
            {
                Nome = "Charizard",
                Hp = 78,
                Attack = 84,
                Defense = 78,
                SpAttack = 109,
                SpDefense = 85,
                Speed = 100,
                IsSuperTrunfo = false,
                Grupo = "B"
            };

            Assert.AreEqual("Charizard", carta.Nome);
            Assert.AreEqual(78, carta.Hp);
            Assert.AreEqual(84, carta.Attack);
            Assert.AreEqual(78, carta.Defense);
            Assert.AreEqual(109, carta.SpAttack);
            Assert.AreEqual(85, carta.SpDefense);
            Assert.AreEqual(100, carta.Speed);
            Assert.IsFalse(carta.IsSuperTrunfo);
            Assert.AreEqual("B", carta.Grupo);
        }

        [TestMethod]
        public void Carta_PodeSerMarcadaComoSuperTrunfo()
        {
            var carta = new Cartas
            {
                Nome = "Arceus",
                IsSuperTrunfo = true
            };

            Assert.IsTrue(carta.IsSuperTrunfo);
        }
    }
}