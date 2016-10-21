using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using FISCA;

namespace StudentTransferCoreImpl
{
    class ExportToXml
    {
        public void Generate(string name, string content)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = string.Format("{0}-Data.xml", name);
            dialog.Filter = "*.xml|*.xml";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, content, Encoding.UTF8);

                if (MessageBox.Show("打開?", "ischool", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    Process.Start(dialog.FileName);
            }
        }
    }
}
