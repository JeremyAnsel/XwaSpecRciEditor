using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace XwaSpecRciEditor
{
    public class SpecRciCollection : ObservableCollection<SpecRciEntry>
    {
        public static SpecRciCollection FromFile(string path)
        {
            SpecRciCollection rci = new SpecRciCollection();

            FileStream filestream = null;

            try
            {
                filestream = new FileStream(path, FileMode.Open, FileAccess.Read);

                using (var file = new BinaryReader(filestream))
                {
                    filestream = null;

                    bool end = false;

                    while (!end)
                    {
                        try
                        {
                            int[] values = new int[12];

                            for (int i = 0; i < 12; i++)
                            {
                                values[i] = file.ReadInt32();
                            }

                            rci.Add(new SpecRciEntry(values));
                        }
                        catch (EndOfStreamException)
                        {
                            end = true;
                        }
                    }
                }
            }
            finally
            {
                if (filestream != null)
                {
                    filestream.Dispose();
                }
            }

            return rci;
        }

        public void SaveToFile(string path)
        {
            FileStream filestream = null;

            try
            {
                filestream = new FileStream(path, FileMode.Create, FileAccess.Write);

                using (var file = new BinaryWriter(filestream))
                {
                    filestream = null;

                    foreach (SpecRciEntry entry in this)
                    {
                        foreach (int val in entry.GetValues())
                        {
                            file.Write(val);
                        }
                    }
                }
            }
            finally
            {
                if (filestream != null)
                {
                    filestream.Dispose();
                }
            }
        }
    }
}
