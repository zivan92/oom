using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace Task4
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void Test1()
        {
            string[] arr = { "Mein", "erster", "Test" };
            var s = Utils.Serialisiere(arr);
            var arr2 = Utils.DeSerialisiere<string[]>(s);
            //arr2[0] = "Test";
            CollectionAssert.AreEqual(arr, arr2);
        }

        [Test]
        public void Test2()
        {
            string[] arr = { "Mein", "zweiter", "Test" };

            var id = Utils.SpeichereObj(arr);

            var filename = Utils.BuildFileName(id);
            FileAssert.Exists(filename);
        }

        [Test]
        public void Test3()
        {
           
            string[] arr = { "Mein", "dritter", "Test" };

            var id = Utils.SpeichereObj(arr);

            var filename = Utils.BuildFileName(id);
            FileAssert.Exists(filename);
            Utils.DeleteObj(id);
            FileAssert.DoesNotExist(filename);
        }

        [Test]
        public void Test4()
        {

            var hotelStadt = new Stadt("Wien", 5);
            var hotelzimmer = new Hotel[]{ 	new Zimmer(1,"Zivan Pajkanovic"),
                                       		new Zimmer(2,"Martina Test") { Länge= 4, Breite= 4},
                                	        new Zimmer(3,"Milan Test"),
                                               	new Zimmer(4,"Dominik Test") { Länge= 5, Breite= 5},
                                               	new Zimmer(5,"David Test"),                                          
					 };
            try
            {
                hotelStadt.AddHotelPlural(hotelzimmer);
            }
            catch (ArgumentException )
            {
                Assert.Fail();
            }
        }
      
	[Test]
        public void Test5()
        {
            var hotelStadt = new Stadt("Wien", 5);
            var hotelzimmer = new Hotel[]{ 	new Zimmer(1,"Zivan Pajkanovic"),
                                                new Zimmer(2,"Martina Test") { Länge= 4, Breite= 4},
                                                new Zimmer(3,"Milan Test"),
                                                new Zimmer(4,"Dominik Test") { Länge= 5, Breite= 5},
                                                new Zimmer(5,"David Test"),                                          
					  };
								
            hotelStadt.AddHotelPlural(hotelzimmer);
            
           
            var id = Utils.SpeichereObj(hotelStadt);
            var derTest = Utils.LadeObj<Stadt>(id);
            if(!derTest.Equals(hotelStadt))
            {
                Assert.Fail();
            }

            Utils.DeleteObj(id);

        }
		
	[Test]
        public void Test6()
        {
            string[] arr = { "Mein", "vierter", "Test", "für", "das","Beispiel" };

            var id = Utils.SpeichereObj(arr);
            var derTest = Utils.LadeObj<string[]>( id);
            CollectionAssert.AreEqual(arr, derTest);
            
            Utils.DeleteObj(id);
        }
		
	[Test]
        public void Test7()
        {
            TestDelegate foo = () => {
                var hotelStadt = new Stadt("Wien", 5);
                var hotelzimmer = new Hotel[]{ 	new Zimmer(1,"Zivan Pajkanovic"),
						new Zimmer(1,"Martina Test") { Länge= 4, Breite= 4},
						new Zimmer(3,"Milan Test"),
		 				new Zimmer(4,"Dominik Test") { Länge= 5, Breite= 5},
						new Zimmer(5,"David Test"),                                          
				    	     };
								
                hotelStadt.AddHotelPlural(hotelzimmer);
            };

            Assert.That(foo,
                Throws.Exception.TypeOf<ArgumentException>().And.Message.EqualTo("Ein Zimmer mit der Nummer existiert schon !")
                );
      		}
			
	[Test]
        public void Test8()
        {
           
            Assert.That(() => { new Zimmer(-1); },
                Throws.Exception.TypeOf<ArgumentException>()
                );

        }
    }
}