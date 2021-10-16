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
        string ReadJson(string path)
        {
            string json = null;
            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }
            if (json == "" || json == null)
            {
                Entity entity = new Patient("Max", "Novopashenniy", DateTime.UtcNow, 01892734, "kekw", "wayaaaa", "ulica Pushkina Dom Kolotushkina", 1, "Moskva", "88005553535", "lol@ya.ru", true, "89128763786", "", null);
                WriteJson(JsonConvert.SerializeObject(entity), path);
                json = ReadJson(path);
            }
            else
            {
                EntityCollection entities = JsonConvert.DeserializeObject<EntityCollection>(json);
            }
            return json;
        }
        void WriteJson(string json, string path)
        {
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
            if (json[0] == '[')
            {
                foreach (var item in JsonConvert.DeserializeObject<EntityCollection>(json))
                {
                    WriteJson(JsonConvert.SerializeObject(item), path);
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
        public MainPage()
        {
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
    }
}
