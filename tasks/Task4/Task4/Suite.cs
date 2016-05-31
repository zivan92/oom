using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Suite :  Hotel
    {
        public Suite(long suiteKosten) { SuiteKosten = suiteKosten; }
        public long SuiteKosten { get; private set; }
		public string Info => "Suite";
        public long Preis(long ZimmerPreis) => ZimmerPreis * SuiteKosten;
    }
}
