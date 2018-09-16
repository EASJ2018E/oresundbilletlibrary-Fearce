using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OresundBilletLibrary;

namespace OresundBilletLibraryTests
{
    [TestClass]
    public class BilTests
    {
        /// <summary>   
        /// Test dato p� Bil
        /// </summary>
        [TestMethod]
        public void BilDatoTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            bil.Dato = DateTime.Today;
            //Assert
            Assert.AreEqual(bil.Dato, DateTime.Today);
        }

        /// <summary>
        /// Test pris p� Bil
        /// </summary>
        [TestMethod]
        public void BilPrisTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            decimal pris = 410;
            //Assert
            Assert.AreEqual(bil.Pris(), pris);
        }

        /// <summary>
        /// Test nummerplade p� Bil
        /// </summary>
        [TestMethod]
        public void BilNummerpladeTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            bil.Nummerplade = "AD14562";
            //Assert
            Assert.AreEqual(bil.Nummerplade, "AD14562");
        }

        /// <summary>
        /// Test type p� Bil
        /// </summary>
        [TestMethod]
        public void BilK�ret�jTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            string k�ret�j = "�resund Bil";
            //Assert
            Assert.AreEqual(bil.K�ret�jType(), k�ret�j);
        }

        /// <summary>
        /// Test for at sikre sig at nummerpladen maks kan v�re 7 tegn
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BilNummerpladeMaxTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            bil.Nummerplade = "12345678";
            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void BilBrobizzTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            bil.Brobizz = true;
            var pris = 161;
            //Assert - delta er den maksimale godkendte forskel fra det forventede resultat.
            Assert.AreEqual(Convert.ToDouble(bil.TotalPris()), pris, 0.001);
        }

        [TestMethod]
        public void BilIngenBrobizzTest()
        {
            //Arrange
            Bil bil = new Bil();
            //Act
            var pris = 410;
            //Assert - delta er den maksimale godkendte forskel fra det forventede resultat.
            Assert.AreEqual(Convert.ToDouble(bil.TotalPris()), pris, 0.001);
        }
    }
}
