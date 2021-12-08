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
        const string productJsonPath = @"C?\data\Products.json";

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
            Product product = new Product("0909123798213", "analgin", "1", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product1 = new Product("0909123798213", "meth", "2", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product2 = new Product("0909123798213", "weed", "8", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product3 = new Product("0909123798213", "doliprane", "3", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product4 = new Product("0909123798213", "lol", "4", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product5 = new Product("0909123798213", "kek", "5", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product6 = new Product("0909123798213", "baby", "6", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
            Product product7 = new Product("0909123798213", "mamacita", "7", "stock", "cmd", "codeActe", "tva", "base", "prixTTC", "remise", "qte", "montant");
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
            products.Add(product);
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);

            foreach (var item in products)
            {
                list.Add((item as Product).ProductName);
            }
            products.List = productNames;
            this.InitializeComponent();
            var border = new Border() { BorderBrush = ProductGrid.BorderBrush, BorderThickness = ProductGrid.BorderThickness };
            Grid grid = new Grid() { BorderBrush = border.BorderBrush, BorderThickness = border.BorderThickness };
            grid.Children.Add(new ComboBox() { Name = "ProductCombo", MinWidth = 378, ItemsSource = list, IsEditable = true });
            ProductGrid.RowDefinitions.Add(new RowDefinition() { Height = ProductGrid.RowDefinitions.First().Height });
            Grid.SetColumn(grid, 1);
            Grid.SetRow(grid, 1);
            DoNewProductLine(ProductGrid);
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
            if (e.Key == VirtualKey.Enter)
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


        public void DoNewProductLine(Grid targetGrid)
        {
            targetGrid.RowDefinitions.Add(new RowDefinition() { Height = ProductGrid.RowDefinitions.First().Height });

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
                        foreach (var item in new string(CB.Name.ToString().Reverse().ToArray()))//
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
                                for (int i = 1; i < ProductGrid.RowDefinitions.Count - 1; i++)
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
                else if (GetProductByName(CB.Text.ToString()).ProductName != "fail")
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
                    TextBlock montant = new TextBlock() { Text = "0,00" };
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
