using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using Path = System.IO.Path;
using Size = System.Drawing.Size;
using AdaptiveVision;
using AvlNet;
using NewElectronicTechnology.SynView;
using System.Data.Sql;

namespace WindowsFormsApp1
{
    class DD_Xml
    {

        public void Refresch_XML(out DataTable tableout)
        {
            string[] filePaths2 = Directory.GetFiles(@"V:/EB_Fertig");

            DataTable table2 = new DataTable();
            table2.Columns.Add("File Name");

            for (int i = 0; i < filePaths2.Length; i++)
            {
                FileInfo file = new FileInfo(filePaths2[i]);
                table2.Rows.Add(file.Name);
            }

            tableout = table2;
        }
    }
}
