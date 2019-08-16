using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace XwaSpecRciEditor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Execute_Open(null, null);
        }

        private SpecRciCollection SpecRci
        {
            get { return (SpecRciCollection)(this.Resources["SpecRci"] as ObjectDataProvider).ObjectInstance; }
            set { (this.Resources["SpecRci"] as ObjectDataProvider).ObjectInstance = value; }
        }

        private string FileName
        {
            get { return (string)(this.Resources["FileName"] as ObjectDataProvider).ObjectInstance; }
            set { (this.Resources["FileName"] as ObjectDataProvider).ObjectInstance = value; }
        }

        private SpecRciShipIdConverter ShipIdConverter
        {
            get { return (SpecRciShipIdConverter)this.Resources["ShipIdConverter"]; }
        }

        private void Execute_New(object sender, ExecutedRoutedEventArgs e)
        {
            var rci = new SpecRciCollection();
            rci.Add(new SpecRciEntry());
            this.SpecRci = rci;
            this.FileName = "New File";
        }

        private void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "SpecRci file|*.rci";
            dlg.FileName = "SPEC.RCI";

            if (dlg.ShowDialog() == true)
            {
                this.OpenFile(dlg.FileName);
            }
        }

        private void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "SpecRci file|*.rci";
            string fileName = this.FileName;

            if (fileName == "New File")
            {
                dlg.FileName = "SPEC.RCI";
            }
            else
            {
                dlg.InitialDirectory = System.IO.Path.GetDirectoryName(fileName);
                dlg.FileName = System.IO.Path.GetFileName(fileName);
            }

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    this.SpecRci.SaveToFile(dlg.FileName);
                    this.FileName = dlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OpenFile(string path)
        {
            try
            {
                this.SpecRci = SpecRciCollection.FromFile(path);
                this.FileName = path;

                this.ShipIdConverter.LoadShipList(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
