using System;
using static System.Console;
using Newtonsoft.Json;

namespace Task4
{
    
        public class Zimmer :  Hotel
        {
            public int ZimmerNummer { get;  set; }
            private readonly string Besucher;
            public long Länge { get;  set; } = 5;
            public long Breite { get; set; } = 5;
            public long Stock { get; private set; } = 5;
            public int MaxStoecke { get; private set; } = 7;

            public override bool Equals(object obj)
            {
                var other = obj as Zimmer;
                if (object.ReferenceEquals(other, null)) return false;

                if (other.ZimmerNummer != this.ZimmerNummer
                    || other.Besucher != this.Besucher
                    || other.Länge != this.Länge
                    || other.Breite != this.Breite
                    || other.Stock != this.Stock
                    || other.MaxStoecke != this.MaxStoecke
                    ) return false;

                return true;
            }

            public override int GetHashCode()
            {
                return ZimmerNummer.GetHashCode()
                    ^ Besucher.GetHashCode()
                    ^ Länge.GetHashCode()
                    ^ Breite.GetHashCode()
                    ^ Stock.GetHashCode()
                    ^ MaxStoecke.GetHashCode();
            }

            public void Aufstocken() => MaxStoecke++;
           

            public long ZimmerGroesse() => Länge * Breite;
            


            public Zimmer(int ZimmerNr)
            {
                if (ZimmerNr < 0) throw new ArgumentException("Diese Zimmernummer existiert nicht", nameof(ZimmerNr));
                ZimmerNummer = ZimmerNr;
            }

            [JsonConstructor]
            public Zimmer(int ZimmerNr,string gebucht): this(ZimmerNr)
            {
                Besucher = gebucht;
            }

            public string gebucht => Besucher;

            public long Preis(long ZimmerPreis) => ZimmerGroesse() * Stock * ZimmerPreis;

            public string Info => $"Zimmer wurde gebucht von: {Besucher}";
        }
    
}