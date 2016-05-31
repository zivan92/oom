using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
    public class Stadt
    {
        public Dictionary<int, Hotel> buchung { get; set; }
        public int AnzahlZimmer { get; set; }
        public string StadtName { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Stadt;
            if (object.ReferenceEquals(other, null)) return false;

            if (other.AnzahlZimmer != this.AnzahlZimmer
                || other.StadtName != this.StadtName
                || other.buchung.Count != this.buchung.Count
            ) return false;

            for (int i = 1; i <= buchung.Count; i++)
            {
                this.buchung[i].Equals(other.buchung[i]); 
            }

            return true;
        }

        public override int GetHashCode()
        {
            return AnzahlZimmer.GetHashCode()
                ^ StadtName.GetHashCode();
        }

        [JsonConstructor]
        public Stadt()
        {

        }

        public Stadt(string name,int anzahlZimmer)
        {
            if(String.IsNullOrEmpty(name) ) throw new ArgumentNullException("Diese Stadt gibt es nicht", nameof(name));
            if(anzahlZimmer < 1) throw new ArgumentException("Keine gueltige Anzahl von Zimmer", nameof(anzahlZimmer));
            StadtName = name;
            AnzahlZimmer = anzahlZimmer;
            buchung = new Dictionary<int, Hotel>(anzahlZimmer);
            for (int i = 1; i <= AnzahlZimmer; i++)
            {
                buchung.Add(i, null);
            }
        }

       public void AddHotel(Hotel bude)
        {
            if (bude is Suite)
                throw new ArgumentException("Es gibt keine Suite");

            Zimmer h = bude as Zimmer;
            if (h == null)
                throw new ArgumentException("Funktioniert nur fuer Zimmer");

            if(buchung[h.ZimmerNummer] != null)
                throw new ArgumentException("Ein Zimmer mit der Nummer existiert schon !");

            if(!buchung.Keys.Contains(h.ZimmerNummer))
                throw new ArgumentException("Im Hotel gibt es kein Zimmer mir der Nummer !");
            buchung[h.ZimmerNummer] = h;
        }

        public void AddHotelPlural(ICollection<Hotel> buden)
        {
            foreach(var bude in buden)
            {
                if (bude is Suite)
                    throw new ArgumentException("Es gibt keine Suite in dieser Stadt");
                AddHotel(bude);
            }    
        }
    }
}
