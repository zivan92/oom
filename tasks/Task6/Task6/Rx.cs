using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;


namespace Task6
{
    public static class Rx
    {
        public static void Run()
        {
            Subject<Hotel> Rx = new Subject<Hotel>();

            Rx.Where(x => x.Anzahl > 2).Subscribe((x) => Console.WriteLine($"Hotel {x.GebuchtVon}"));

            Task.Run(() =>
            {
                Task.Delay(500).Wait(); 
                Rx.OnNext(new Hotel(35, 1, "Monika Test"));
                Rx.OnNext(new Hotel(50, 2, "David Test"));
                Rx.OnNext(new Hotel(80, 4, "Dominik Test"));
                Rx.OnNext(new Hotel(65, 3, "Zivan Pajkanovic"));

            });


        }
    }
}
