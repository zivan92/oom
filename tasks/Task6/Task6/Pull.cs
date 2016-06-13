using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public static class Pull
    {
        public static void Run()
        {
            var liste = new List<Hotel> { };

            liste.Add(new Hotel(50, 2, "Zivan Pajkanovic"));
            liste.Add(new Hotel(35, 1, "David Test"));
            liste.Add(new Hotel(80, 4, "Monika Test"));
            liste.Add(new Hotel(65, 3, "Gruber"));
            liste.Add(new Hotel(35, 1, "Dominik Test"));

            var i = liste.GetEnumerator();
            while (i.MoveNext()) Console.WriteLine($"{i.Current} - Zimmerpreis: {i.Current.Zimmerpreis}, Gebucht von: {i.Current.GebuchtVon}");

            var liste2= liste.Where((x) => x.Anzahl > 2);


               
                }
    }
}
