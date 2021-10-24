using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Stagerie
{

    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string patientJsonPath = @"C:\data\Patients.json";
        string productJsonPath = @"C?\data\Products.json";

        public static List<string> ReadJson()
        {
            string json = null;
            List<string> jsonList = new List<string>();
            string temp = "";
            using (StreamReader r = new StreamReader("data/Patients.json"))
            {
                json = r.ReadToEnd();
            }
            if (json == "" || json == null)
            {
                throw new Exception("Json file is empty.");
            }
            else
            {
                foreach (var item in json)
                {
                    if (item == '{')
                    {
                        temp += item;
                    }
                    if (item == '}')
                    {
                        temp += item;
                        jsonList.Add(temp);
                        temp = "";
                    }
                }
            }
            return jsonList;
        }
        public void WriteJson(string path)
        {
            string json = JsonConvert.SerializeObject(this);
            bool firstItem = false;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    fileStream.Close();
                    File.AppendAllText(path, "[");
                    firstItem = true;
                }
                else
                {
                    fileStream.Seek(-1, SeekOrigin.End);
                    if (fileStream.ReadByte() == ']') fileStream.SetLength(fileStream.Length - 1);
                    fileStream.Seek(0, SeekOrigin.Begin);
                }
            }
            if (firstItem)
            {
                File.AppendAllText(path, json + "]");
                firstItem = false;
            }
            else
            {
                File.AppendAllText(path, "," + json + "]");
            }
        }

        int i = 1;
        PatientCollection patients = new PatientCollection();
        public MainPage()
        {
            Patient patient1 = new Patient("Max", "Novopashenniy", DateTime.UtcNow, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina","Paris", 1, "Moskva", "1", "lol@ya.ru", true, "89128763786", "",DateTime.Today, DateTime.Today, null);
            Patient patient2 = new Patient("Vasiliy", "Pupkin", DateTime.UtcNow, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "2", "lol@ya.ru", true, "89128763786", "", DateTime.Today, DateTime.Today, null);
            Patient patient3 = new Patient("Max", "Lebovski", DateTime.UtcNow, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "3", "lol@ya.ru", true, "89128763786", "", DateTime.Today, DateTime.Today, null);
            Patient patient4 = new Patient("Vasiliy", "Novopashenniy", DateTime.UtcNow, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "4", "lol@ya.ru", true, "89128763786", "", DateTime.Today, DateTime.Today, null);
            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);
            patients.Add(patient4);
            this.InitializeComponent();
        }

        private void TabView_AddTabButtonClick(muxc.TabView sender, object args)
        {
            var newTab = new muxc.TabViewItem();
            newTab.IconSource = new muxc.SymbolIconSource() { Symbol = Symbol.Document };
            i++;
            newTab.Header = $"Facture {i}";

            // The Content of a TabViewItem is often a frame which hosts a page.
            Frame frame = new Frame();
            newTab.Content = frame;
            frame.Navigate(typeof(FacturationTabViewItem));

            sender.TabItems.Add(newTab);
        }

        // Remove the requested tab from the TabView
        private void TabView_TabCloseRequested(muxc.TabView sender, muxc.TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
            i -= 1;
        }

        private void OnAnnulerButtonClick(object sender, TappedRoutedEventArgs e)
        {
            if (RechercherTab.Visibility == Visibility.Visible)
            {
                RechercherTab.Visibility = Visibility.Collapsed;
            }
            else
            {
                RechercherTab.Visibility = Visibility.Visible;
            }
        }

        public void RechercherNomPrenom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (RechercherNomPrenom.SelectedItem as Patient == null)
                {

                }
                else
                {
                    RechercherTab.Visibility = Visibility.Collapsed;
                    AssureNom.IsEditable = true;
                    AssureNom.Text = (RechercherNomPrenom.SelectedItem as Patient).FirstName.ToString();
                    AssurePrenom.Text = (RechercherNomPrenom.SelectedItem as Patient).LastName.ToString();
                    AssureNoSS.Text = (RechercherNomPrenom.SelectedItem as Patient).NumeroSS.ToString();
                    AssureNoSSCode.Text = 99.ToString();
                    AssureCPVilleNom.Text = (RechercherNomPrenom.SelectedItem as Patient).TownName.ToString();
                    AssureCPVilleCode.Text = (RechercherNomPrenom.SelectedItem as Patient).TownIndex.ToString();
                    AssureCentre.Text = (RechercherNomPrenom.SelectedItem as Patient).Centre.ToString();
                    AssureTelDom.Text = (RechercherNomPrenom.SelectedItem as Patient).TelephoneNumber.ToString();
                    AssureNote.Text = (RechercherNomPrenom.SelectedItem as Patient).Note.ToString();
                    AssureVisitDate.Text = DateTime.Today.ToString();

                    //PatientTab 
                    PatientNom.Text = (RechercherNomPrenom.SelectedItem as Patient).FirstName.ToString();
                    PatientPrenom.Text = (RechercherNomPrenom.SelectedItem as Patient).LastName.ToString();
                    PatientLienNe.IsEditable = false;
                    PatientLienNeDate.Text = (RechercherNomPrenom.SelectedItem as Patient).BirthDate.ToString();
                    PatientLienNeNumber.IsReadOnly = true;
                    PatientMail.Text = (RechercherNomPrenom.SelectedItem as Patient).TelephoneNumber.ToString();
                    PatientCodeRemb.Text = (RechercherNomPrenom.SelectedItem as Patient).Adress.ToString();
                    PatientMutuCB.Text = (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString();
                    PatientMutu.IsChecked = (RechercherNomPrenom.SelectedItem as Patient).Mutu;
                    PatientNoAdhMutu.Text = (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString();
                    PatientStartDate.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitSince.ToString();
                    PatientEndDate.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitTo.ToString();
                    AssureNom.IsEditable = false;
                }
            }
        }

        //Colorising tabs
        private void RechercherTabLostFocus(object sender, RoutedEventArgs e)
        {
            RechercherRect.Fill = new SolidColorBrush(Color.FromArgb(255, 197, 196, 196));
        }

        private void RechercherTabGotFocus(object sender, RoutedEventArgs e)
        {
            RechercherRect.Fill = new SolidColorBrush(Color.FromArgb(255, 161, 136, 198));
        }

        private void AssureTab_GotFocus(object sender, RoutedEventArgs e)
        {
            AssureRect.Fill = new SolidColorBrush(Color.FromArgb(255, 161, 136, 198));
        }

        private void AssureTab_LostFocus(object sender, RoutedEventArgs e)
        {
            AssureRect.Fill = new SolidColorBrush(Color.FromArgb(255, 197, 196, 196));
        }

        private void PatientTab_GotFocus(object sender, RoutedEventArgs e)
        {
            PatientRect.Fill = new SolidColorBrush(Color.FromArgb(255, 161, 136, 198));
        }

        private void PatientTab_LostFocus(object sender, RoutedEventArgs e)
        {
            PatientRect.Fill = new SolidColorBrush(Color.FromArgb(255, 197, 196, 196));
        }

        private void PrescripteurTab_GotFocus(object sender, RoutedEventArgs e)
        {
            PrescripteurRect.Fill = new SolidColorBrush(Color.FromArgb(255, 161, 136, 198));
        }

        private void PrescripteurTab_LostFocus(object sender, RoutedEventArgs e)
        {
            PrescripteurRect.Fill = new SolidColorBrush(Color.FromArgb(255, 197, 196, 196));
        }

        private void RechercherNomPrenom_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
    }
}
