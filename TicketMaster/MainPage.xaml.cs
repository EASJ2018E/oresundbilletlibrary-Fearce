using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BilletKundeApp;
using OresundBilletLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicketMaster
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
       // public List<string> List { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void UpdatePrice()
        {
            try
            {
                ViewModel.Dato = DatePicker.Date.UtcDateTime;
                TotalPrisLabel.Text = ViewModel.Kunde.SumPrice().ToString();
                // if (List.Count != ViewModel.Ture.Count) //Update listen før jeg huskede observablecollection XD
                // {
                //     List = new List<string>();
                //    foreach (var s in ViewModel.Ture)
                //   {
                //      List.Add(s);
                // }

                //  Liste.ItemsSource = List;
                // }
                if (Bro.SelectedItem != null && Bro.SelectedItem.ToString().ToUpper() == "ØRESUND")
                {
                    if (Køretøj.SelectedItem != null && Køretøj.SelectedItem.ToString().ToUpper() == "BIL")
                    {
                        Bil bil = new Bil();
                        bil.Dato = DatePicker.Date.UtcDateTime;
                        if (Brobizz.IsChecked != null) bil.Brobizz = (bool)Brobizz.IsChecked;
                        bil.Nummerplade = Nummerplade.Text;
                        PrisLabel.Text = bil.TotalPris().ToString();
                    }
                    else if (Køretøj.SelectedItem != null && Køretøj.SelectedItem.ToString().ToUpper() == "MC")
                    {
                        MC mc = new MC();
                        mc.Dato = DatePicker.Date.UtcDateTime;
                        if (Brobizz.IsChecked != null) mc.Brobizz = (bool)Brobizz.IsChecked;
                        mc.Nummerplade = Nummerplade.Text;
                        PrisLabel.Text = mc.TotalPris().ToString();
                    }
                }
                else if (Bro.SelectedItem != null && Bro.SelectedItem.ToString().ToUpper().ToUpper() == "STOREBÆLT")
                {
                    if (Køretøj.SelectedItem != null && Køretøj.SelectedItem.ToString().ToUpper() == "BIL")
                    {
                        StoreBaeltBilletLibrary.Bil bil = new StoreBaeltBilletLibrary.Bil();
                        bil.Dato = DatePicker.Date.UtcDateTime;
                        if (Brobizz.IsChecked != null) bil.Brobizz = (bool)Brobizz.IsChecked;
                        bil.Nummerplade = Nummerplade.Text;
                        PrisLabel.Text = bil.TotalPris().ToString();
                    }
                    else if (Køretøj.SelectedItem != null && Køretøj.SelectedItem.ToString().ToUpper() == "MC")
                    {
                        StoreBaeltBilletLibrary.MC mc = new StoreBaeltBilletLibrary.MC();
                        mc.Dato = DatePicker.Date.UtcDateTime;
                        if (Brobizz.IsChecked != null) mc.Brobizz = (bool)Brobizz.IsChecked;
                        mc.Nummerplade = Nummerplade.Text;
                        PrisLabel.Text = mc.TotalPris().ToString();
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                var messageDialog = new MessageDialog("Nummerpladen skal være max 7 tegn");
                messageDialog.Commands.Add(new UICommand(
                    "Close",
                    new UICommandInvokedHandler(command => { Nummerplade.Text = ""; })));
                messageDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog("Kontakt administrator med fejlen " + ex).ShowAsync();
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddTicket();
        }

        //jajajajajaj DRY i know ok
        private void Bro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void Brobizz_OnChecked(object sender, RoutedEventArgs e)
        {
           UpdatePrice();
        }

        private void DatePicker_OnDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void Nummerplade_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void Køretøj_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
        }
    }
}
