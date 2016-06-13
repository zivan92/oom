using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var hotelStadt = new Stadt("Wien", 5);
            var hotelzimmer = new Zimmer[]{ 	new Zimmer(1,"Zivan Pajkanovic"),
												new Zimmer(2,"Martina Test") { Länge= 4, Breite= 4},
												new Zimmer(3,"Milan Test"),
												new Zimmer(4,"Dominik Test") { Länge= 5, Breite= 5},
												new Zimmer(5,"David Test") { Länge= 4, Breite= 5},                                          
								};
            try {
                hotelStadt.AddHotelPlural(hotelzimmer);

               
                var jsonstr = Utils.Serialisiere(hotelStadt);
                Utils.SpeichereObj2(hotelStadt);
                var derTest = Utils.LadeObj2<Stadt>();
                WriteLine($"Task 4= {jsonstr}"); 
                Console.Read();
            }
            catch(ArgumentException ex)
            {
                
                WriteLine($"Task4 exception geworfen {ex.Message } ");
            }
            catch (Exception ex)
            {
                WriteLine($"Task4 exception mit der ich nicht gerechnet habe geworfen {ex.Message }");
            }

        }

        static void GibEsAus<T>(T[] arr, Action<string> foo) where T : Hotel
        {
            foreach (var zimmer in arr)
            {
                foo($" Dieses Zimmer {zimmer.Info} jetzt um nur {zimmer.Preis(100L)} !");
            }
        }
    }
}
