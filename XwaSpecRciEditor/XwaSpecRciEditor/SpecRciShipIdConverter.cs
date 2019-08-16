using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace XwaSpecRciEditor
{
    public class SpecRciShipIdConverter : IValueConverter
    {
        public SpecRciShipIdConverter()
        {
        }

        private List<string> Ships { get; set; }

        public void LoadShipList(string path)
        {
            string shiplistPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), "Shiplist.txt");

            if (System.IO.File.Exists(shiplistPath))
            {
                this.Ships = System.IO.File.ReadAllLines(shiplistPath)
                    .Select(t => t.Split('!', ','))
                    .Select(t => t.Length > 2 ? t[2].Trim() : string.Empty)
                    .ToList();
            }
            else
            {
                this.Ships = new List<string>();
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return this.Ships.ElementAtOrDefault((int)value - 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
