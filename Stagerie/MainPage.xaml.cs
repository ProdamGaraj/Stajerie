using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        const string patientJsonPath = @"C:\data\Patients.json";
        const string productJsonPath = @"C?\data\Products.json";

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


        int i = 1;
        PatientCollection patients = new PatientCollection();
        PrescripteurCollection prescripteurs = new PrescripteurCollection();

        public MainPage()
        {
            Patient patient1 = new Patient("Max", "Novopashenniy", DateTime.Now.Date, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "1", "lol@ya.ru", true, "89128763786", "", DateTime.Now.Date, DateTime.Now.Date, null);
            Patient patient2 = new Patient("Vasiliy", "Pupkin", DateTime.Now.Date, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "2", "lol@ya.ru", true, "89128763786", "", DateTime.Now.Date, DateTime.Now.Date, null);
            Patient patient3 = new Patient("Max", "Lebovski", DateTime.Now.Date, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "3", "lol@ya.ru", true, "89128763786", "", DateTime.Now.Date, DateTime.Now.Date, null);
            Patient patient4 = new Patient("Vasiliy", "Novopashenniy", DateTime.Now.Date, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", "Paris", 1, "Moskva", "4", "lol@ya.ru", true, "89128763786", "", DateTime.Now.Date, DateTime.Now.Date, null);
            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);
            patients.Add(patient4);
            Prescripteur prescripteur = new Prescripteur("Vrach", "Vrachev","Hospital", "5621273612", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur1 = new Prescripteur("Matilda", "Kekova", "Hospital", "5354342", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur2 = new Prescripteur("Pipa", "Popich", "Hospital", "125435", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur3 = new Prescripteur("Keker", "Lolov", "Hospital", "765432352", 263, 32, "880005553535", "specification", "specType", null);
            prescripteurs.Add(prescripteur);
            prescripteurs.Add(prescripteur1);
            prescripteurs.Add(prescripteur2);
            prescripteurs.Add(prescripteur3);
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
                //RechercherTabAnnuler
                RechercherTab.Visibility = Visibility.Visible;
                AssureNom.IsEditable = true;
                AssureNom.Text = "";
                AssurePrenom.Text = "";
                AssureNoSS.Text = "";
                AssureNoSSCode.Text = "";
                AssureCPVilleNom.Text = "";
                AssureCPVilleCode.Text = "";
                AssureCentre.Text = "";
                AssureTelDom.Text = "";
                AssureNote.Text = "";
                AssureVisitDate.Text = "";

                //PatientTab Annuler
                PatientNom.Text = "";
                PatientPrenom.Text = "";
                PatientLienNe.IsEditable = true;
                PatientLienNeDate.Text = "";
                PatientLienNeNumber.IsReadOnly = false;
                PatientMail.Text = "";
                PatientCodeRemb.Text = "";
                PatientMutuCB.Text = "";
                PatientMutu.IsChecked = false;
                PatientNoAdhMutu.Text = "";
                PatientStartDate.Text = "";
                PatientEndDate.Text = "";
                AssureNom.IsEditable = true;
                RechercherTab.Visibility = Visibility.Visible;

                //PrescreteurTabAnnuler
                
            }
        }

        public void RechercherNomPrenom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (RechercherNomPrenom.SelectedItem as Patient != null)
                {
                    //AssureTab
                    RechercherTab.Visibility = Visibility.Collapsed;
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
                    PatientLienNeDate.Text = (RechercherNomPrenom.SelectedItem as Patient).BirthDate.ToShortDateString();
                    PatientLienNeNumber.IsReadOnly = true;
                    PatientMail.Text = (RechercherNomPrenom.SelectedItem as Patient).TelephoneNumber.ToString();
                    PatientCodeRemb.Text = (RechercherNomPrenom.SelectedItem as Patient).Adress.ToString();
                    PatientMutuCB.Text = (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString();
                    PatientMutu.IsChecked = (RechercherNomPrenom.SelectedItem as Patient).Mutu;
                    PatientNoAdhMutu.Text = (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString();
                    PatientStartDate.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitSince.ToShortDateString();
                    PatientEndDate.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitTo.ToShortDateString();

                    //la béquille
                    AssureCPVilleNom.Focus(FocusState.Pointer);
                    AssureCPVilleCode.Focus(FocusState.Pointer);
                    AssureCentre.Focus(FocusState.Pointer);
                    PatientLienNe.Focus(FocusState.Pointer);
                    PatientCodeRemb.Focus(FocusState.Pointer);
                    PatientMutuCB.Focus(FocusState.Pointer);
                    AssureNom.Focus(FocusState.Pointer);
                }
            }
        }

        private void PrescripteurNom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (PrescripteurNom.SelectedItem as Prescripteur != null)
                {
                    PrescripteurPrenom.Text = (PrescripteurNom.SelectedItem as Prescripteur).LastName;
                    PrescripteurHopital.Text = (PrescripteurNom.SelectedItem as Prescripteur).Hospital;
                    PrescripteurRPPS.Text = (PrescripteurNom.SelectedItem as Prescripteur).RPPS;
                    PrescripteurIdFiness.Text = (PrescripteurNom.SelectedItem as Prescripteur).Finess.ToString();
                    PrescripteurTel.Text = (PrescripteurNom.SelectedItem as Prescripteur).PhoneNumber;
                    PrescripteurSpec.Text = (PrescripteurNom.SelectedItem as Prescripteur).Spec;
                    PrescripteurSpecType.Text = (PrescripteurNom.SelectedItem as Prescripteur).SpecType;
                    PrescripteurTel.Text = (PrescripteurNom.SelectedItem as Prescripteur).PhoneNumber;

                    PrescripteurDateOrig.Text = DateTime.Now.ToShortDateString();
                    PrescripteurDateFac.Text = DateTime.Now.ToShortDateString();

                    PrescripteurHopital.Focus(FocusState.Pointer);
                    PrescripteurSpec.Focus(FocusState.Pointer);
                    PrescripteurSpecType.Focus(FocusState.Pointer);
                    PrescripteurDateOrig.Focus(FocusState.Pointer);
                    PrescripteurDateFac.Focus(FocusState.Pointer);
                    PrescripteurNom.Focus(FocusState.Pointer);
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

        private void PatientNom_TextChanged(object sender, TextChangedEventArgs e)
        {
        //    void VisibilityChange()
        //    {
        //        if (modificationAlarm.Visibility == Visibility.Visible)
        //        {
        //            modificationAlarm.Visibility = Visibility.Collapsed;
        //        }
        //        else
        //        {
        //            modificationAlarm.Visibility = Visibility.Visible;
        //        }
        //    }
        //    Stopwatch sw = new Stopwatch();
        //    Task SetVisible = Task.Run(() =>
        //   {
        //       VisibilityChange();
        //       sw.Start();
        //       while (sw.ElapsedMilliseconds<=1500)
        //       {
        //
        //       }
        //       sw.Stop();
        //   });
        }

    }
}
