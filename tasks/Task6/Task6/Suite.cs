using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Suite : HotelZimmer
    {
        private int anzahl;

        private double zimmerpreis;
        private double umsatz;
        private string gebuchtvon;

        private double Umsatz
        {
            get
            {
                umsatz = zimmerpreis / 1.2;
                return umsatz;
            }
        }

        public string GebuchtVon
        {
            get
            {
                return gebuchtvon;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Familienname darf nicht leer sein!");
                gebuchtvon = value;
            }
        }

        public void Umbuchen(string Nachname)
        {
            if (string.IsNullOrWhiteSpace(Nachname)) throw new ArgumentException("Familienname darf nicht leer sein!");
            gebuchtvon = Nachname;
        }

        public double Zimmerpreis
        {
            get
            {
                return zimmerpreis;
            }
            set
            {
                if (value < 0) throw new Exception("Preis kann nicht negativ sein!");
                zimmerpreis = value;
            }
        }

        public int Anzahl
        {
            get
            {
                return anzahl;
            }
            set
            {
                if (value < 0) throw new Exception("Anzahl kann nicht negativ sein!");
                anzahl = value;
            }
        }

        public double Endpreis()
        {
            return (anzahl * zimmerpreis);
        }

        
        public Suite(double Zimmerpreis, int Anzahl, string GebuchtVon)
        {
            if (Zimmerpreis < 0) throw new ArgumentOutOfRangeException("Preis kann nicht negativ werden!");
            if (Anzahl < 0) throw new ArgumentOutOfRangeException("Anzahl kann nicht negativ werden!");
            if (string.IsNullOrWhiteSpace(GebuchtVon)) throw new ArgumentException("Familienname darf nicht leer sein!");
            zimmerpreis = Zimmerpreis;
            anzahl = Anzahl;
            gebuchtvon = GebuchtVon;
        }
    }
}

