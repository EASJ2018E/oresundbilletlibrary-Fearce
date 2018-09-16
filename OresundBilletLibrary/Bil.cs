using System;
using BilletLibrary;

namespace OresundBilletLibrary
{
    public class Bil : Køretøj
    {
        public override decimal Pris()
        {
            return Brobizz ? 161 : 410;
        }

        public override string KøretøjType()
        {
            return "Øresund Bil";
        }

        /// <summary>
        /// Override for at sikre sig at prisen er fast og ikke med % fratrækning
        /// </summary>
        /// <returns></returns>
        public override decimal TotalPris()
        {
            return Pris();
        }

        public override DateTime Dato { get; set; }
    }
}
