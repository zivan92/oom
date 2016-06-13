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
    public static class Push22
    {
        public static void Run()
        {
            var producer = new Subject<int>();

            producer.Subscribe(x => Console.WriteLine($"Empfangener Wert: {x}"));

            for (var i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                producer.OnNext(i);
            }
        }
    }
}
