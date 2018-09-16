using System;
using BilletKundeApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OresundBilletLibrary;
using StoreBaeltBilletLibrary;

namespace BilletKundeAppTests
{
    [TestClass]
    public class KundeTests
    {
        [TestMethod]
        public void SumAfTureTests()
        {
            //Arrange
            Kunde kunde = new Kunde();
            OresundBilletLibrary.Bil oreBil = new OresundBilletLibrary.Bil();
            StoreBaeltBilletLibrary.Bil storeBil = new StoreBaeltBilletLibrary.Bil();
            OresundBilletLibrary.MC oreMC = new OresundBilletLibrary.MC();
            StoreBaeltBilletLibrary.MC storeMC = new StoreBaeltBilletLibrary.MC();

            //Act
            kunde.Ture.Add(oreBil);
            kunde.Ture.Add(storeBil);
            kunde.Ture.Add(oreMC);
            kunde.Ture.Add(storeMC);
            decimal sum = 985; //Forventet pris af de fire ture uden nogle rabatter

            //Assert - delta er den maksimale godkendte forskel fra det forventede resultat.
            Assert.AreEqual(Convert.ToDouble(kunde.SumPrice()), Convert.ToDouble(sum), 0.001);
        }
    }
}
