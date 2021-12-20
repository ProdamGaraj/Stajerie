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
using Windows.System;
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
        const string productJsonPath = @"C:\data\Products.json";

        public static List<string> ReadJson(string path)
        {
            string json = null;
            List<string> jsonList = new List<string>();
            string temp = "";
            using (StreamReader r = new StreamReader(path))
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
        class Operator : Entity
        {
            public string Name { get; set; }
            public Operator(string name)
            {
                Name = name;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        class OperatorCollection : EntityCollection
        {
            public OperatorCollection()
            {
            }
            void AddItem(string name)
            {
                this.Add(new Operator(name));
            }


        }
        public List<String> productNames = new List<String>();

        int i = 1;
        ProductCollection products = new ProductCollection();
        int ProductGridCurrentLinesAmount = 1;
        int VisibleRowsAmount = 1;
        List<string> list = new List<string>();//items source for combos
        PatientCollection patients = new PatientCollection();
        PrescripteurCollection prescripteurs = new PrescripteurCollection();
        public MainPage()
        {
            this.InitializeComponent();
            OperatorCollection operators = new OperatorCollection();
            Operator op1 = new Operator("op1");
            Operator op2 = new Operator("op2");
            operators.Add(op1);
            operators.Add(op2);
            operatorCombo.ItemsSource = operators;
            Product product = new Product("0909123798213", "analgin", "1", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product1 = new Product("0909123798213", "meth", "2", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product2 = new Product("0909123798213", "weed", "8", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product3 = new Product("0909123798213", "doliprane", "3", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product4 = new Product("0909123798213", "lol", "4", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product5 = new Product("0909123798213", "kek", "5", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product6 = new Product("0909123798213", "baby", "6", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product7 = new Product("0909123798213", "mamacita", "7", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            products.Add(product);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);




            Patient patient1 = new Patient("Kozlov", "Artem", DateTime.Parse("01/10/1985"), "2196574", "22", "5802", "22", "Moskva", "524698", "5", "322122854", "Kozlov@mail.fr", true, "5816", "Note9", DateTime.Parse("11/12/2021"), DateTime.Parse("10/12/2022"), DateTime.MinValue);
            Patient patient2 = new Patient("Gorodnikov", "Alexandr", DateTime.Parse("5/8/1987"), "3794433", "38", "58", "38", "Novgorod", "787047", "8", "643646993", "Gorodnikov@mail.fr", true, "72", "Good", DateTime.Parse("2/11/2021"), DateTime.Parse("1/11/2022"), DateTime.MinValue);
            Patient patient3 = new Patient("Dorochenko ", "Petr", DateTime.Parse("17/11/1991"), "6990151", "69", "70", "70", "Kolomna", "258964", "3", "127422486", "Dorochenko@mail.fr", true, "84", "bad", DateTime.Parse("11/02/2021"), DateTime.Parse("10/02/2022"), DateTime.MinValue);
            Patient patient4 = new Patient("Udin", "Misha", DateTime.Parse("02/03/1986"), "13381587", "132", "134", "134", "Urupinsk", "326598", "3", "254246257", "Udin@mail.fr", true, "148", "child", DateTime.Parse("15/12/2021"), DateTime.Parse("14/12/2022"), DateTime.MinValue);
            Patient patient0 = new Patient("", "", DateTime.Now.Date, "0", "", "", "", "", "0", "", "", "", false, "", "", DateTime.Now.Date, DateTime.Now.Date, null);
            patients.Add(patient0);
            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);
            patients.Add(patient4);
            RechercherNomPrenom.ItemsSource = patients;

            Prescripteur prescripteur = new Prescripteur("Vrach", "Vrachev", "Hospital", "5621273612", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur1 = new Prescripteur("Matilda", "Kekova", "Hospital", "5354342", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur2 = new Prescripteur("Pipa", "Popich", "Hospital", "125435", 263, 32, "880005553535", "specification", "specType", null);
            Prescripteur prescripteur3 = new Prescripteur("Keker", "Lolov", "Hospital", "765432352", 263, 32, "880005553535", "specification", "specType", null);
            prescripteurs.Add(prescripteur);
            prescripteurs.Add(prescripteur1);
            prescripteurs.Add(prescripteur2);
            prescripteurs.Add(prescripteur3);



            foreach (var item in products)
            {
                list.Add((item as Product).ProductName);
            }

            var border = new Border() { BorderBrush = ProductGrid.BorderBrush, BorderThickness = ProductGrid.BorderThickness };
            Grid grid = new Grid() { BorderBrush = border.BorderBrush, BorderThickness = border.BorderThickness };
            grid.Children.Add(new ComboBox() { Name = "ProductCombo", MinWidth = 378, ItemsSource = list, IsEditable = true });
            //ProductGrid.RowDefinitions.Add(new RowDefinition() { Height = ProductGrid.RowDefinitions.First().Height });
            Grid.SetColumn(grid, 1);
            Grid.SetRow(grid, 1);
            DoNewProductLine(ProductGrid);
            InputLockChanger();
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
                //RechercherTab.Visibility = Visibility.Collapsed;
                ProductGrid.Children.Clear();
                ProductGrid.RowDefinitions.Clear();
                ProductGridCurrentLinesAmount = 1;
                VisibleRowsAmount = 1;

                ProductGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(31.0, GridUnitType.Pixel) });
                int column = 0;
                string[] headerStrings = new string[] { "№", "ProductName", "Liste", "Stock", "Cmd", "CodeActe", "TVA", "Base", "PrixTTC", "Remise", "Qte", "Montant" };
                var border = new Border() { BorderBrush = ProductGrid.BorderBrush, BorderThickness = ProductGrid.BorderThickness };
                foreach (var str in headerStrings)
                {
                    Grid textBlockGrid = new Grid() { BorderBrush = border.BorderBrush, BorderThickness = border.BorderThickness };
                    TextBlock textBlock = new TextBlock() { Text = str, TextAlignment = TextAlignment.Center };
                    textBlockGrid.Children.Add(textBlock);
                    ProductGrid.Children.Add(textBlockGrid);
                    Grid.SetColumn(textBlockGrid, column);
                    Grid.SetRow(textBlockGrid, 0);
                    column++;
                }
                DoNewProductLine(ProductGrid);
            }
            else
            {
                //RechercherTabAnnuler
                RechercherTab.Visibility = Visibility.Visible;
                RechercherNomPrenom.SelectedItem = "";
                AssureNom.IsEditable = true;
                AssureNom.SelectedItem = "";
                AssurePrenom.Text = "";
                AssureNoSS.Text = "";
                AssureNoSSCode.Text = "";
                AssureCPVilleCode.SelectedItem = "";
                AssureCPVilleNom.SelectedItem = "";
                AssureCPVilleNom.Text = "";
                AssureCPVilleCode.Text = "";
                AssureCentre.SelectedItem = "";
                AssureTelDom.Text = "";
                AssureNote.Text = "";
                AssureVisitDate.Text = "";

                //PatientTab Annuler
                PatientNom.Text = "";
                PatientPrenom.Text = "";
                PatientLienNe.IsEditable = true;
                PatientLienNeDate.Text = "";
                PatientLienNeNumber.IsReadOnly = false;
                PatientCodeRemb.Text = "";
                PatientMail.Text = "";
                PatientCodeRemb.SelectedItem = "";
                PatientMutuNumber.SelectedItem = "";
                PatientMutu.IsChecked = false;
                PatientNoAdhMutu.Text = "";
                PatientDroitSince.Text = "";
                PatientDroitTo.Text = "";
                AssureNom.IsEditable = true;
                RechercherTab.Visibility = Visibility.Visible;

                //PrescreteurTabAnnuler
                PrescripteurNom.SelectedItem = "";
                PrescripteurPrenom.Text = "";
                PrescripteurHopital.SelectedItem = "";
                PrescripteurRPPS.Text = "";
                PrescripteurIdFiness.Text = "";
                PrescripteurSpec.SelectedItem = "";
                PrescripteurSpecType.SelectedItem = "";
                PrescripteurTel.Text = "";
                PrescripteurDateOrig.SelectedItem = "";
                PrescripteurDateOrigOrd.SelectedItem = "";
                PrescripteurDateFac.SelectedItem = "";




                InputLockChanger();
            }
        }

        public void InputLockChanger()
        {
            //Rechecher lock
            RechercherNoSS.IsEnabled = !RechercherNoSS.IsEnabled;
            RechercherNeJe.IsEnabled = !RechercherNeJe.IsEnabled;
            RechercherType.IsEnabled = !RechercherType.IsEnabled;
            RechercherCodePostal.IsEnabled = !RechercherCodePostal.IsEnabled;
            //Assure lock
            AssureNom.IsEnabled = !AssureNom.IsEnabled;
            AssureAdresse.IsEnabled = !AssureAdresse.IsEnabled;
            AssurePrenom.IsEnabled = !AssurePrenom.IsEnabled;
            AssureNoSS.IsEnabled = !AssureNoSS.IsEnabled;
            AssureNoSSCode.IsEnabled = !AssureNoSSCode.IsEnabled;
            AssureCPVilleCode.IsEnabled = !AssureCPVilleCode.IsEnabled;
            AssureCPVilleNom.IsEnabled = !AssureCPVilleNom.IsEnabled;
            AssureCentre.IsEnabled = !AssureCentre.IsEnabled;
            AssureTelDom.IsEnabled = !AssureTelDom.IsEnabled;
            AssureNote.IsEnabled = !AssureNote.IsEnabled;
            //Patient lock
            PatientNom.IsEnabled = !PatientNom.IsEnabled;
            PatientPrenom.IsEnabled = !PatientPrenom.IsEnabled;
            PatientLienNe.IsEnabled = !PatientLienNe.IsEnabled;
            PatientLienNeDate.IsEnabled = !PatientLienNeDate.IsEnabled;
            PatientLienNeNumber.IsEnabled = !PatientLienNeNumber.IsEnabled;
            PatientMail.IsEnabled = !PatientMail.IsEnabled;
            PatientCodeRemb.IsEnabled = !PatientCodeRemb.IsEnabled;
            PatientMutuNumber.IsEnabled = !PatientMutuNumber.IsEnabled;
            PatientMutu.IsEnabled = !PatientMutu.IsEnabled;
            PatientContral.IsEnabled = !PatientContral.IsEnabled;
            PatientNoAdhMutu.IsEnabled = !PatientNoAdhMutu.IsEnabled;
            PatientDroitSince.IsEnabled = !PatientDroitSince.IsEnabled;
            PatientDroitTo.IsEnabled = !PatientDroitTo.IsEnabled;
            //Prescripteur lock
            PrescripteurNom.IsEnabled = !PrescripteurNom.IsEnabled;
            PrescripteurPrenom.IsEnabled = !PrescripteurPrenom.IsEnabled;
            PrescripteurHopital.IsEnabled = !PrescripteurHopital.IsEnabled;
            PrescripteurRPPS.IsEnabled = !PrescripteurRPPS.IsEnabled;
            PrescripteurIdFiness.IsEnabled = !PrescripteurIdFiness.IsEnabled;
            PrescripteurSpec.IsEnabled = !PrescripteurSpec.IsEnabled;
            PrescripteurSpecType.IsEnabled = !PrescripteurSpecType.IsEnabled;
            PrescripteurTel.IsEnabled = !PrescripteurTel.IsEnabled;
            PrescripteurDateOrig.IsEnabled = !PrescripteurDateOrig.IsEnabled;
            PrescripteurDateOrigOrd.IsEnabled = !PrescripteurDateOrigOrd.IsEnabled;
            PrescripteurDateFac.IsEnabled = !PrescripteurDateFac.IsEnabled;


        }

        public bool IsInputLocked()
        {
            return AssureNom.IsEnabled;
        }

        public void RechercherNomPrenom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                if (RechercherNomPrenom.SelectedItem as Patient != null)
                {
                    if ((RechercherNomPrenom.SelectedItem as Patient).Nom != "")
                    {
                        if (!IsInputLocked())//if closed -> open
                        {
                            InputLockChanger();
                        }
                        //AssureTab
                        RechercherTab.Visibility = Visibility.Collapsed;
                        AssureNom.Text = (RechercherNomPrenom.SelectedItem as Patient).Nom.ToString();
                        AssurePrenom.Text = (RechercherNomPrenom.SelectedItem as Patient).Prenom.ToString();
                        AssureNoSS.Text = (RechercherNomPrenom.SelectedItem as Patient).NoSS.ToString();
                        AssureNoSSCode.Text = (RechercherNomPrenom.SelectedItem as Patient).NoSSCode.ToString();
                        AssureCPVilleNom.Text = (RechercherNomPrenom.SelectedItem as Patient).CPVilleNom.ToString();
                        AssureCPVilleCode.Text = (RechercherNomPrenom.SelectedItem as Patient).CPVilleCode.ToString();
                        AssureCentre.Text = (RechercherNomPrenom.SelectedItem as Patient).Centre.ToString();
                        AssureTelDom.Text = (RechercherNomPrenom.SelectedItem as Patient).Mail.ToString();
                        AssureNote.Text = (RechercherNomPrenom.SelectedItem as Patient).Note.ToString();
                        AssureVisitDate.Text = DateTime.Today.ToString();

                        //PatientTab 
                        PatientNom.Text = (RechercherNomPrenom.SelectedItem as Patient).Nom.ToString();
                        PatientPrenom.Text = (RechercherNomPrenom.SelectedItem as Patient).Prenom.ToString();
                        PatientLienNe.IsEditable = false;
                        PatientLienNeDate.Text = (RechercherNomPrenom.SelectedItem as Patient).LienNeDate.ToShortDateString();
                        PatientLienNeNumber.IsReadOnly = true;
                        PatientMail.Text = (RechercherNomPrenom.SelectedItem as Patient).Mail.ToString();
                        PatientCodeRemb.Text = (RechercherNomPrenom.SelectedItem as Patient).CodeRemb.ToString();
                        PatientMutuNumber.Text = (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString();
                        PatientMutu.IsChecked = (RechercherNomPrenom.SelectedItem as Patient).Mutu;
                        PatientNoAdhMutu.Text = (RechercherNomPrenom.SelectedItem as Patient).NoAdhMutu.ToString();
                        PatientDroitSince.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitSince.ToShortDateString();
                        PatientDroitTo.Text = (RechercherNomPrenom.SelectedItem as Patient).DroitTo.ToShortDateString();
                        ModifiedAt.Text = (RechercherNomPrenom.SelectedItem as Patient).ModifiedAt.ToString();

                        AssureNom.Focus(FocusState.Pointer);
                    }
                    else
                    {
                        if (IsInputLocked())//if open->close
                        {
                            InputLockChanger();
                        }
                        RechercherTab.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void PrescripteurNom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
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

        private async void AssureTab_LostFocus(object sender, RoutedEventArgs e)
        {
            bool assureTextChangedFlag;
            try
            {
                assureTextChangedFlag =
            RechercherNomPrenom.SelectedItem != null && (AssureNom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Nom.ToString() ||
            AssurePrenom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Prenom.ToString() ||
            AssureNoSS.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).NoSS.ToString() ||
            AssureNoSSCode.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).NoSSCode.ToString() ||
            AssureCPVilleNom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).CPVilleNom.ToString() ||
            AssureCPVilleCode.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).CPVilleCode.ToString() ||
            AssureCentre.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Centre.ToString() ||
            AssureTelDom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Mail.ToString() ||
            AssureNote.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Note.ToString());
            }
            catch (Exception)
            {
                assureTextChangedFlag = false;
            }


            int ind = 0;
            var selectedItemProps = (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperties();
            var tempCb = new ComboBox();
            var tempTb = new TextBox();
            if (assureTextChangedFlag)
            {
                var saveFac = new ContentDialog() { Title = "Do you want to save changes?", PrimaryButtonText = "YES", SecondaryButtonText = "NO" };
                ContentDialogResult result;
                try
                {
                    result = await saveFac.ShowAsync();
                }
                catch (Exception)
                {
                    result = ContentDialogResult.Secondary;
                }

                if (result == ContentDialogResult.Primary)
                {
                    foreach (var item in (sender as Grid).Children)
                    {
                        if (item.GetType().Equals(tempTb.GetType()))//ALL TEXTBOXES
                        {
                            ind = 0;
                            foreach (var prop in selectedItemProps)
                            {

                                if ((item as TextBox).Text.Trim() != "" && (item as TextBox).Name.Substring(6) == selectedItemProps[ind].Name && (item as TextBox).Text != (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperty(selectedItemProps[ind].Name.ToString()).ToString())
                                {

                                    prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, (item as TextBox).Text.ToString());

                                    break;
                                }
                                ind++;
                            }

                        }
                        if (item.GetType().Equals(tempCb.GetType()))//ALL COMBOS
                        {
                            ind = 0;
                            foreach (var prop in selectedItemProps)
                            {

                                if ((item as ComboBox).Text.Trim() != "" && (item as ComboBox).Name.Substring(6) == selectedItemProps[ind].Name && (item as ComboBox).Text != (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperty(selectedItemProps[ind].Name.ToString()).ToString())
                                {

                                    prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, (item as ComboBox).Text.ToString());

                                    break;
                                }
                                ind++;
                            }
                        }
                    }
                    (RechercherNomPrenom.SelectedItem as Patient).ModifiedAt = DateTime.Now;
                    ModifiedAt.Text = (RechercherNomPrenom.SelectedItem as Patient).ModifiedAt.ToString();
                    RechercherNomPrenom.ItemsSource = patients;
                }
            }
            AssureRect.Fill = new SolidColorBrush(Color.FromArgb(255, 197, 196, 196));
        }

        private void PatientTab_GotFocus(object sender, RoutedEventArgs e)
        {
            PatientRect.Fill = new SolidColorBrush(Color.FromArgb(255, 161, 136, 198));
        }

        private async void PatientTab_LostFocus(object sender, RoutedEventArgs e)
        {
            bool patientTextChangedFlag;
            bool patientTextNotNull;
            try
            {
                patientTextNotNull =
                    PatientNom.Text.Trim() != "" &&
                    PatientPrenom.Text.Trim() != "" &&
                    PatientLienNeDate.Text.Trim() != "" &&
                    PatientMail.Text.Trim() != "" &&
                    PatientCodeRemb.Text.Trim() != "" &&
                    PatientMutuNumber.Text.Trim() != "" &&
                    PatientNoAdhMutu.Text.Trim() != "" &&
                    PatientDroitSince.Text.Trim() != "" &&
                    PatientDroitTo.Text.Trim() != "";
                patientTextChangedFlag = RechercherNomPrenom.SelectedItem != null &&
           (PatientNom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Nom.ToString() ||
            PatientPrenom.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Prenom.ToString() ||
            PatientLienNeDate.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).LienNeDate.ToShortDateString() ||
            PatientMail.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).Mail.ToString() ||
            PatientCodeRemb.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).CodeRemb.ToString() ||
            PatientMutuNumber.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).MutuNumber.ToString() ||
            PatientMutu.IsChecked != (RechercherNomPrenom.SelectedItem as Patient).Mutu ||
            PatientNoAdhMutu.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).NoAdhMutu.ToString() ||
            PatientDroitSince.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).DroitSince.ToShortDateString() ||
            PatientDroitTo.Text.Trim() != (RechercherNomPrenom.SelectedItem as Patient).DroitTo.ToShortDateString());
            }
            catch (Exception)
            {
                patientTextNotNull = false;
                patientTextChangedFlag = false;
            }


            if (patientTextChangedFlag && patientTextNotNull)
            {
                var saveFac = new ContentDialog() { Title = "Do you want to save changes?", PrimaryButtonText = "YES", SecondaryButtonText = "NO" };
                ContentDialogResult result;
                try
                {
                    result = await saveFac.ShowAsync();
                }
                catch (Exception)
                {
                    result = ContentDialogResult.Secondary;
                }


                if (result == ContentDialogResult.Primary)
                {
                    int ind = 0;
                    var selectedItemProps = (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperties();
                    var tempCb = new ComboBox();
                    var tempTb = new TextBox();
                    foreach (var item in (sender as Grid).Children)
                    {
                        if (item.GetType().Equals(tempTb.GetType()))//ALL TEXTBOXES
                        {
                            ind = 0;
                            foreach (var prop in selectedItemProps)
                            {

                                if ((item as TextBox).Text.Trim() != "" && (item as TextBox).Name.Substring(7) == selectedItemProps[ind].Name && (item as TextBox).Text != (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperty(selectedItemProps[ind].Name.ToString()).ToString())
                                {
                                    if (prop.Name == "LienNeDate" || prop.Name == "DroitSince" || prop.Name == "DroitTo" || prop.Name == "ModifiedAt")
                                    {
                                        prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, Convert.ToDateTime((item as TextBox).Text.ToString()));
                                    }
                                    else
                                    {
                                        prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, (item as TextBox).Text.ToString());
                                    }
                                    break;
                                }
                                ind++;
                            }

                        }
                        if (item.GetType().Equals(tempCb.GetType()))//ALL COMBOS
                        {
                            ind = 0;
                            foreach (var prop in selectedItemProps)
                            {

                                if ((item as ComboBox).Text.Trim() != "" && (item as ComboBox).Name.Substring(7) == selectedItemProps[ind].Name && (item as ComboBox).Text != (RechercherNomPrenom.SelectedItem as Patient).GetType().GetProperty(selectedItemProps[ind].Name.ToString()).ToString())
                                {
                                    if (prop.Name == "LienNeDate" || prop.Name == "DroitSince" || prop.Name == "DroitTo" || prop.Name == "ModifiedAt")
                                    {
                                        prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, Convert.ToDateTime((item as ComboBox).Text.ToString()));
                                    }
                                    else
                                    {
                                        prop.SetValue(RechercherNomPrenom.SelectedItem as Patient, (item as ComboBox).Text.ToString());
                                    }
                                    break;
                                }
                                ind++;
                            }
                        }
                    }
                    (RechercherNomPrenom.SelectedItem as Patient).ModifiedAt = DateTime.Now;
                    ModifiedAt.Text = (RechercherNomPrenom.SelectedItem as Patient).ModifiedAt.ToString();
                    RechercherNomPrenom.ItemsSource = patients;
                }
            }
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

        //ProductGrid handlers
        public void DoNewProductLine(Grid targetGrid)
        {
            targetGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(31.0, GridUnitType.Pixel) });

            for (int i = 0; i < 2; i++)
            {
                Grid tempGrid = new Grid() { BorderBrush = ProductGrid.BorderBrush, BorderThickness = ProductGrid.BorderThickness };
                if (i == 1)
                {
                    var cb = new ComboBox() { Name = "ProductCombo" + ProductGridCurrentLinesAmount.ToString(), MinWidth = 378, ItemsSource = list, IsEditable = true };
                    cb.PreviewKeyDown += new KeyEventHandler(ProductComboKeyDown);
                    targetGrid.Children.Add(cb);
                    Grid.SetColumn(cb, i);
                    Grid.SetRow(cb, ProductGridCurrentLinesAmount);
                }
                else
                {
                    tempGrid.Children.Add(new TextBlock() { Text = VisibleRowsAmount.ToString() });
                    targetGrid.Children.Add(tempGrid);
                    Grid.SetColumn(tempGrid, i);
                    Grid.SetRow(tempGrid, ProductGridCurrentLinesAmount);
                }
            }
            ProductGridCurrentLinesAmount++;
            VisibleRowsAmount++;
        }

        private Product GetProductByName(string name)
        {
            Product product = new Product("fail", "fail", "fail", "fail", "fail", "fail", "fail", "fail", "fail", "fail", "fail", "fail");//not throwing exept
            foreach (var item in products)
            {
                if ((item as Product).ProductName == name) { return (item as Product); }
            }
            return product;
        }

        private void ProductComboKeyDown(object sender, KeyRoutedEventArgs e)
        {//delete line with null str input
            if (e.Key == VirtualKey.Enter)
            {
                ComboBox CB = sender as ComboBox;
                if (CB.Text == "")
                {
                    if (ProductGrid.Children.LastOrDefault() == CB)
                    {

                    }
                    else
                    {
                        int index = 0;
                        string tempstr = "";
                        foreach (var item in new string(CB.Name.ToString().Reverse().ToArray()))
                        {
                            if (item != 'o')
                            {
                                tempstr += item;
                            }
                            else
                            {
                                tempstr = new string(tempstr.Reverse().ToArray());//it`s row index just in case of broken delet
                                index = Convert.ToInt32(tempstr);
                                ProductGrid.Children.ElementAt(index * 12 + 1).SetValue(NameProperty, "InvisibleProductCombo");
                                int j = 1;

                                ProductGrid.Children.ElementAt(index * 12 + 1).Visibility = Visibility.Collapsed;
                                DeleteLine(ProductGrid, index);
                                VisibleRowsAmount--;
                                for (int i = 1; i < ProductGrid.RowDefinitions.Count; i++)
                                {
                                    if (ProductGrid.RowDefinitions.ElementAt(i).MaxHeight != 0)
                                    {
                                        ((ProductGrid.Children.ElementAt(i * 12) as Grid).Children.LastOrDefault() as TextBlock).Text = j.ToString();
                                        j++;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                else if (GetProductByName(CB.Text.ToString()).ProductName != "fail" && (sender as ComboBox).Equals(ProductGrid.Children.LastOrDefault()))
                {//Add line
                    Product product = new Product();
                    product = GetProductByName(CB.Text.ToString());
                    int i = 2;
                    TextBox qteBox = new TextBox() { Text = "1,00", TextWrapping = TextWrapping.Wrap, Name = "qte" + ProductGridCurrentLinesAmount.ToString() };
                    qteBox.PreviewKeyDown += new KeyEventHandler(qteComboKeyDown);
                    qteBox.PreviewKeyUp += new KeyEventHandler(qteBoxKeyUp);
                    qteBox.LostFocus += new RoutedEventHandler(qteBoxLostFocus);
                    TextBox prixBox = new TextBox() { Text = "0,00", TextWrapping = TextWrapping.Wrap, Name = "prix" + ProductGridCurrentLinesAmount.ToString() };
                    prixBox.PreviewKeyDown += new KeyEventHandler(prixBoxKeyDown);
                    prixBox.PreviewKeyUp += new KeyEventHandler(prixBoxKeyUp);
                    prixBox.LostFocus += new RoutedEventHandler(prixBoxLostFocus);
                    TextBox remiseBox = new TextBox() { Text = "0,00", TextWrapping = TextWrapping.Wrap, Name = "remise" + ProductGridCurrentLinesAmount.ToString() };
                    remiseBox.PreviewKeyDown += new KeyEventHandler(remiseBoxKeyDown);
                    remiseBox.PreviewKeyUp += new KeyEventHandler(remiseBoxKeyUp);
                    remiseBox.LostFocus += new RoutedEventHandler(remiseBoxLostFocus);
                    TextBlock montant = new TextBlock() { Text = "0" };
                    foreach (var prop in product.GetType().GetProperties())
                    {
                        if (prop.Name != "ProductName" && prop.Name != "No")
                        {
                            Grid tempGrid = new Grid() { BorderBrush = ProductGrid.BorderBrush, BorderThickness = ProductGrid.BorderThickness };
                            if (prop.Name == "Qte")
                            {
                                tempGrid.Children.Add(qteBox);
                            }
                            else if (prop.Name == "PrixTTC")
                            {
                                tempGrid.Children.Add(prixBox);
                            }
                            else if (prop.Name == "Remise")
                            {
                                tempGrid.Children.Add(remiseBox);
                            }
                            else if (prop.Name == "Montant")
                            {
                                tempGrid.Children.Add(montant);
                            }
                            else
                            {
                                tempGrid.Children.Add(new TextBlock() { Text = (string)prop.GetValue(product, null) });
                            }

                            ProductGrid.Children.Add(tempGrid);
                            Grid.SetColumn(tempGrid, i);
                            Grid.SetRow(tempGrid, ProductGridCurrentLinesAmount - 1);
                            i++;
                        }
                    }
                    DoNewProductLine(ProductGrid);
                }
            }
        }

        private void MontantCalculation(string id)
        {
            TextBox prixBox = (ProductGrid.Children.ElementAt(Convert.ToInt32(id) * 12 - 4) as Grid).Children.LastOrDefault() as TextBox;
            TextBox qteBox = (ProductGrid.Children.ElementAt(Convert.ToInt32(id) * 12 - 2) as Grid).Children.LastOrDefault() as TextBox;
            TextBox remiseBox = (ProductGrid.Children.ElementAt(Convert.ToInt32(id) * 12 - 3) as Grid).Children.LastOrDefault() as TextBox;
            ((ProductGrid.Children.ElementAt(Convert.ToInt32(id) * 12 - 1) as Grid).Children.LastOrDefault() as TextBlock).Text = Math.Round((Convert.ToDouble(prixBox.Text) - Convert.ToDouble(prixBox.Text) * (Convert.ToDouble(remiseBox.Text) / 100)) * Convert.ToDouble(qteBox.Text), 2).ToString();
        }

        //prix filters
        private void prixBoxKeyUp(object sender, KeyRoutedEventArgs e)//Let it be
        {


        }

        private void prixBoxLostFocus(object sender, RoutedEventArgs e)//Normilising output
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0,00";
            }
            if ((sender as TextBox).Text.StartsWith(','))
            {
                (sender as TextBox).Text = '0' + (sender as TextBox).Text;

            }
            string text = (sender as TextBox).Text;
            if (text.Contains(','))
            {
                if (text.Substring(text.IndexOf(',')).Length > 2)
                {
                    (sender as TextBox).Text = text.Substring(0, text.IndexOf(',')) + text.Substring(text.IndexOf(','), 3);
                }
            }
            string id = "";
            foreach (var item in (sender as TextBox).Name)
            {
                if (Char.IsDigit(item))
                {
                    id += item;
                }
            }
            MontantCalculation(id);
        }

        private void prixBoxKeyDown(object sender, KeyRoutedEventArgs e)//filters for input
        {
            if (!Char.IsDigit((char)e.Key) && !(e.Key == VirtualKey.Back) && !(e.Key == VirtualKey.Delete) && !(e.Key == VirtualKey.Left) && !(e.Key == VirtualKey.Right) && !(e.Key == VirtualKey.Tab) && !Char.Equals((char)e.Key, '¼'))
            {
                e.Handled = true;
            }
            else
            {
                if (Char.Equals((char)e.OriginalKey, '¼') && (sender as TextBox).Text.Contains(','))
                {
                    e.Handled = true;
                }
            }
        }

        //qte filters
        private void qteBoxKeyUp(object sender, KeyRoutedEventArgs e)
        {

        }

        private void qteBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "1,00";
            }
            if ((sender as TextBox).Text.StartsWith(','))
            {
                (sender as TextBox).Text = '0' + (sender as TextBox).Text;

            }
            string str = new string((sender as TextBox).Text.ToArray());
            if (!str.Contains(','))
            {
                while (str.StartsWith('0') && str.Length != 1)
                {
                    str = str.Substring(1);
                }
            }
            else
            {
                while (str.StartsWith('0') && str[1] != ',')
                {
                    str = str.Substring(1);
                }
                if (str.IndexOf(',') + 3 < str.Length)
                {
                    str = str.Substring(0, str.IndexOf(',') + 3);
                }
            }
            (sender as TextBox).Text = str;
            string id = "";
            foreach (var item in (sender as TextBox).Name)
            {
                if (Char.IsDigit(item))
                {
                    id += item;
                }
            }
            MontantCalculation(id);
        }

        private void qteComboKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (!Char.IsDigit((char)e.Key) && !(e.Key == VirtualKey.Back) && !(e.Key == VirtualKey.Delete) && !(e.Key == VirtualKey.Left) && !(e.Key == VirtualKey.Right) && !(e.Key == VirtualKey.Tab) && !Char.Equals((char)e.Key, '¼'))
            {
                e.Handled = true;
            }
            else
            {
                if (!(e.Key == VirtualKey.Back) && !(e.Key == VirtualKey.Delete) && !(e.Key == VirtualKey.Left) && !(e.Key == VirtualKey.Right) && !(e.Key == VirtualKey.Tab))
                {
                    if ((char)e.Key == '¼' && (sender as TextBox).Text.Contains(','))
                    {
                        e.Handled = true;
                    }
                    else
                    {

                    }
                }

            }
            if (!Char.IsDigit((char)e.Key))
            {
                if ((sender as TextBox).Text == "0")
                {
                    (sender as TextBox).Text = "1";
                }
            }
        }

        //remise filters
        private void remiseBoxKeyUp(object sender, KeyRoutedEventArgs e)
        {


        }

        private void remiseBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "0,00";
            }
            if ((sender as TextBox).Text.StartsWith(','))
            {
                (sender as TextBox).Text = "0" + (sender as TextBox).Text.Substring((sender as TextBox).Text.IndexOf(','));
            }
            string str = new string((sender as TextBox).Text.ToArray());
            if (!str.Contains(','))
            {
                while (str.StartsWith('0') && str.Length != 1)
                {
                    str = str.Substring(1);
                }
            }
            else
            {
                while (str.StartsWith('0') && str[1] != ',')
                {
                    str = str.Substring(1);
                }
                if (str.IndexOf(',') + 3 < str.Length)
                {
                    str = str.Substring(0, str.IndexOf(',') + 3);
                }
            }
            (sender as TextBox).Text = str;
            if (double.Parse(str) > 100)
            {
                (sender as TextBox).Text = "100";
            }
            string id = "";
            foreach (var item in (sender as TextBox).Name)
            {
                if (Char.IsDigit(item))
                {
                    id += item;
                }
            }
            MontantCalculation(id);
        }

        private void remiseBoxKeyDown(object sender, KeyRoutedEventArgs e)
        {
            int index = ProductGrid.Children.IndexOf((sender as TextBox).Parent as Grid);
            if (!Char.IsDigit((char)e.Key) && !(e.Key == VirtualKey.Back) && !(e.Key == VirtualKey.Delete) && !(e.Key == VirtualKey.Left) && !(e.Key == VirtualKey.Right) && !(e.Key == VirtualKey.Tab) && !Char.Equals((char)e.Key, '¼'))
            {
                e.Handled = true;
            }
            else
            {
                if (!(e.Key == VirtualKey.Back) && !(e.Key == VirtualKey.Delete) && !(e.Key == VirtualKey.Left) && !(e.Key == VirtualKey.Right) && !(e.Key == VirtualKey.Tab))
                {
                    if ((char)e.Key == '¼' && (sender as TextBox).Text.Contains(','))
                    {
                        e.Handled = true;
                    }
                    else
                    {

                    }
                }
            }
        }

        void DeleteLine(Grid targetGrid, int index)
        {
            targetGrid.RowDefinitions.ElementAt(index).MaxHeight = 0;//juct in case of broken RemoveAt()
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