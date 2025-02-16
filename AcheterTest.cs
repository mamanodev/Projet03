using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace Projet03
{
    [TestFixture]
    internal class AcheterTest
    {
        FrmPrincipale form = new FrmPrincipale();
        [Test]
        public void CalculRemisTest()
        {

            // Arrange

            FrmPrincipale.totalMonnaie = 2.00m;
            FrmPrincipale.Prix_bonbonChoisi = 1.50m;
            decimal remis = 0.50m;
            decimal retourCalculRemis = 0;
            // Act
            retourCalculRemis= form.calculRemis(FrmPrincipale.totalMonnaie, FrmPrincipale.Prix_bonbonChoisi);

            // Assert
            Assert.That(remis, Is.EqualTo(retourCalculRemis));
        }

    }
}
