using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using static System.Console;
using System.Windows.Forms;

namespace Task6
{
    public static class Push
    {
        public static void Run()
        {
            var w = new Form();
             w.Text = "Move the mouse!";
             w.Width = 800;
             w.Height = 600;

            w.MouseMove += (s, e) => WriteLine($"[Coordinates:] ({e.X},{e.Y})");
			
			 
            IObservable<Point> moves = Observable.FromEventPattern<MouseEventArgs>(w, "MouseMove").Select(x => x.EventArgs.Location);

			moves
            .Throttle(TimeSpan.FromSeconds(1.0))
			.DistinctUntilChanged()
            .Subscribe(e => WriteLine($"[Please be active] ({e.X}, {e.Y}) "))
            ;
			
            Application.Run(w);


        }
    }
}
