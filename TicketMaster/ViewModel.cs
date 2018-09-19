using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BilletKundeApp;
using StoreBaeltBilletLibrary;
using OresundBilletLibrary;
using Bil = OresundBilletLibrary.Bil;
using MC = OresundBilletLibrary.MC;

namespace TicketMaster
{
    public class ViewModel
    {

        public static Kunde Kunde { get; set; }
        public List<string> Køretøjer { get; set; } //done
        public static string SelectedKøretøj { get; set; } //done
        public List<string> Broer { get; set; } //done
        public static string SelectedBro { get; set; } //done
        public static DateTime Dato { get; set; }
        public static bool Brobizz { get; set; }
        public static string Nummerplade { get; set; }

        public static ObservableCollection<string> Ture { get; set; }

        public string Pris { get; set; }

        public static string TotalPris { get; set; }


        public ViewModel()
        {
            Køretøjer = new List<string>(new string[] { "Bil", "Mc" });
            Broer = new List<string>(new string[] { "Øresund", "Storebælt" });
            Kunde = new Kunde();
            Ture = new ObservableCollection<string>();
            Ture.Add("Liste over ture:");
        }

        public static void AddTicket()
        {
            try
            {
                if (SelectedBro != null && SelectedBro.ToUpper() == "ØRESUND")
                {
                    if (SelectedKøretøj != null && SelectedKøretøj.ToUpper() == "BIL")
                    {
                        Bil bil = new Bil();
                        bil.Dato = Dato;
                        bil.Brobizz = Brobizz;
                        bil.Nummerplade = Nummerplade;
                        Kunde.Ture.Add(bil);
                        TotalPris = Kunde.SumPrice().ToString();
                        //var dd = decimal.Round(Kunde.SumPrice(), 2);
                        Ture.Add($"Rejse til Øresund: {Dato:dd-MM-yyyy}. Brobizz: {Brobizz}. Nummerplade: {Nummerplade}. Type: {bil.KøretøjType()}. Pris: {bil.TotalPris()}");
                    }
                    else if (SelectedKøretøj != null && SelectedKøretøj.ToUpper() == "MC")
                    {
                        MC mc = new MC();
                        mc.Dato = Dato;
                        mc.Brobizz = Brobizz;
                        mc.Nummerplade = Nummerplade;
                        Kunde.Ture.Add(mc);
                        TotalPris = Kunde.SumPrice().ToString();
                        Ture.Add($"Rejse til Øresund: {Dato:dd-MM-yyyy}. Brobizz: {Brobizz}. Nummerplade: {Nummerplade}. Type: {mc.KøretøjType()}. Pris: {mc.TotalPris()}");
                    }
                }
                else if (SelectedBro != null && SelectedBro.ToUpper() == "STOREBÆLT")
                {
                    if (SelectedKøretøj != null && SelectedKøretøj.ToUpper() == "BIL")
                    {
                        StoreBaeltBilletLibrary.Bil bil = new StoreBaeltBilletLibrary.Bil();
                        bil.Dato = Dato;
                        bil.Brobizz = Brobizz;
                        bil.Nummerplade = Nummerplade;
                        Kunde.Ture.Add(bil);
                        TotalPris = Kunde.SumPrice().ToString();
                        Ture.Add($"Rejse til Storebælt: {Dato:dd-MM-yyyy}. Brobizz: {Brobizz}. Nummerplade: {Nummerplade}. Type: {bil.KøretøjType()}. Pris: {bil.TotalPris()}");
                    }
                    else if (SelectedKøretøj != null && SelectedKøretøj.ToUpper() == "MC")
                    {
                        StoreBaeltBilletLibrary.MC mc = new StoreBaeltBilletLibrary.MC();
                        mc.Dato = Dato;
                        mc.Brobizz = Brobizz;
                        mc.Nummerplade = Nummerplade;
                        Kunde.Ture.Add(mc);
                        TotalPris = Kunde.SumPrice().ToString();
                        Ture.Add($"Rejse til Storebælt: {Dato:dd-MM-yyyy}. Brobizz: {Brobizz}. Nummerplade: {Nummerplade}. Type: {mc.KøretøjType()}. Pris: {mc.TotalPris()}");
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                var messageDialog = new MessageDialog("Nummerpladen skal være max 7 tegn").ShowAsync();
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Kontakt administrator med fejlen "+e).ShowAsync();
            }

        }


    }
}
