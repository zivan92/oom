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
    public static class Push12
    {
        public static void Run()
        {
            var source = new Subject<int>();

            source
                .Sample(TimeSpan.FromSeconds(1.0))
                .Subscribe(x => Console.WriteLine($"Empfangen: {x}"))
                ;

            var t = new Thread(() =>
            {
                var i = 0;
                while (i<30)
                {
                    Thread.Sleep(250);
                    source.OnNext(i);
                    Console.WriteLine($"Gesendet: {i}");
                    i++;
                }
            });
            t.Start();
        }
    }
}
