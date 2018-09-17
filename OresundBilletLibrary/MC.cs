using System;
using System.Collections.Generic;
using System.Text;
using BilletLibrary;

namespace OresundBilletLibrary
{
    public class MC : Køretøj
    {
        public override decimal Pris()
        {
            return Brobizz ? 73 : 210; //Conditional operator - hvis brobizz så 73 ellers 210
        }

        public override string KøretøjType()
        {
            return "Øresund MC";
        }

        public override DateTime Dato { get; set; }

        public override bool Brobizz { get; set; }

        /// <summary>
        /// Override for at sikre sig at prisen er fast og ikke med % fratrækning
        /// </summary>
        /// <returns></returns>
        public override decimal TotalPris()
        {
            return Pris();
        }
    }
}
