using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel a = new Hotel(35, 1, "Zivan Pajkanovic");
            Hotel b = new Hotel(50, 2, "David Test");
            Hotel c = new Hotel(65, 3, "Monika Test");
            Hotel d = new Hotel(80, 4, "Dominik Test");

			
            Console.WriteLine($"Das Hotelzimmer in der Abteilung a kostet {a.Zimmerpreis} Euro und hat Platz für {a.Anzahl} Person(en). Gesamtpreis = {a.Endpreis()} Euro ");
            Console.WriteLine($"Das Hotelzimmer in der Abteilung b kostet {b.Zimmerpreis} Euro und hat Platz für {b.Anzahl} Person(en). Gesamtpreis = {b.Endpreis()} Euro ");
            Console.WriteLine($"Das Hotelzimmer in der Abteilung c kostet {c.Zimmerpreis} Euro und hat Platz für {c.Anzahl} Person(en). Gesamtpreis = {c.Endpreis()} Euro ");
            Console.WriteLine($"Das Hotelzimmer in der Abteilung d kostet {d.Zimmerpreis} Euro und hat Platz für {d.Anzahl} Person(en). Gesamtpreis = {d.Endpreis()} Euro ");
              
          	Console.WriteLine($"\nDas Zimmer in der Abteilung a wurde von {a.GebuchtVon} gebucht");
            a.Umbuchen("Zivan Test");
            Console.WriteLine($"Das Zimmer in der Abteilung a wurde jetzt von {a.GebuchtVon} umgebucht");

            Suite e = new Suite(80, 2, "Zivan Pajkanovic");
            Console.WriteLine($"\nDie Suite in der Abteilung e wurde von {e.GebuchtVon} gebucht und kostet: {e.Zimmerpreis} Euro");
			e.Umbuchen("Zivan Test");
            Console.WriteLine($"Die Suite in der Abteilung e wurde jetzt von {e.GebuchtVon} umgebucht und kostet: {e.Zimmerpreis} Euro");

            var items = new HotelZimmer[]
            {
            new Hotel(35, 1, "Zivan Pajkanovic"),
            new Hotel(50, 2, "David Test"),
            new Hotel(80, 4, "Dominik Test"),
            new Hotel(65, 3, "Monika Test"),
            new Suite(70, 1, "Markus Test"),
            new Suite(80, 2, "Jasmin Test"),
            new Suite(90, 3, "Lena Test"),

        };

            foreach (var x in items)
            {
                Console.WriteLine($"\nWurde von: {x.GebuchtVon} gebucht. \nZimmerpreis: {x.Zimmerpreis}");
            }

            
            string s = JsonConvert.SerializeObject(items);
            Console.WriteLine(s);

            SerialDeserial.Run(items);

			Pull.Run();

            Push.Run();

						Push12.Run();	
						Push22.Run();
			
			Rx.Run();	Async.MyAsync().ContinueWith((t)=>Console.WriteLine($"Ende")).Wait();
            

        }
    }
}
