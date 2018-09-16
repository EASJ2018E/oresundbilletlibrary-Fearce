using System;
using System.Collections.Generic;
using System.Text;
using BilletLibrary;
using OresundBilletLibrary;
using StoreBaeltBilletLibrary;

namespace BilletKundeApp
{
    public class Kunde
    {
        public List<Køretøj> Ture { get; set; } //Baseclass som type

        public Kunde()
        {
            Ture = new List<Køretøj>();
        }

        public decimal SumPrice()
        {
            decimal total = 0;
            foreach (var t in Ture)
            {
                total += t.TotalPris();
            }

            return total;
        }

    }
}
