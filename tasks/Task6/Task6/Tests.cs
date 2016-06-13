using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Task6
{
    class Tests
    {
        [Test]
        public void HozelZimmerBuchung()
        {
            var x = new Hotel(30, 1, "Zivan Pajkanovic");
            Assert.IsTrue(x.Zimmerpreis == 30);
            Assert.IsTrue(x.Anzahl == 1);
        }
		
		[Test]
        public void HotelZimmerBuchungNichtMöglichNegativerPreis1()
        {
            Assert.Catch(() =>
            {
                var x = new Hotel(-35, 1, "Zivan Pajkanovic");
            });
        }
		
        [Test]
        public void SuiteBuchung()
        {
            var x = new Suite(70, 2, "Zivan Pajkanovic");
            Assert.IsTrue(x.Zimmerpreis == 70);
            Assert.IsTrue(x.Anzahl == 2);
        }

        [Test]
        public void HotelZimmerBuchungNichtMöglichNegativeAnzahl()
        {
            Assert.Catch(() =>
            {
                var x = new Hotel(50, -2, "Zivan Pajkanovic");
            });
        }

        [Test]
        public void SuiteMitNegativemPreisNichtMöglich()
        {
            Assert.Catch(() =>
            {
                var x = new Suite(-70, 1, "Zivan Pajkanovic");
            });
        }

        [Test]
        public void SuiteAnzahlKannNichtNegativSein()
        {
            Assert.Catch(() =>
            {
                var x = new Suite(70, -1, "Zivan Pajkanovic");
            });
        }


        [Test]
        public void ZimmerUmbuchen()
        {
            var x = new Hotel(35,1, "Zivan Pajkanovic");
            x.Umbuchen("Zivan Test");
            Assert.IsTrue(x.GebuchtVon == "Zivan Test");
            
        }

        [Test]
        public void SuiteUmbuchen()
        {
            var x = new Suite(70, 1, "Zivan Pajkanovic");
            x.Umbuchen("Zivan Test");
            Assert.IsTrue(x.GebuchtVon == "Zivan Test");

        }

        [Test]
        public void HotelGesamtpreisWurdeBerechnet()
        {
            var x = new Hotel(35, 1,"Zivan Pajkanovic");
            Assert.IsTrue(x.Endpreis()==(35*1));

        }

        [Test]
        public void SuiteGesamtPreisWurdeBerechnet()
        {
            var x = new Suite(80, 2, "Zivan Pajkanovic");
            Assert.IsTrue(x.Endpreis() == (88 * 2));

        }

    }
}
