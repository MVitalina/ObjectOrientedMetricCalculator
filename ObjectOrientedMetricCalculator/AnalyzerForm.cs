using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedMetricCalculator
{
    public partial class AnalyzerForm : Form
    {
        public AnalyzerForm()
        {
            InitializeComponent();
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        var files = Directory.GetFiles(fbd.SelectedPath, "*.cs", SearchOption.AllDirectories);
                        Console.WriteLine(files[0]);
                        Console.WriteLine(files.Count());

                        List<string> allLinesInAllFiles = new List<string>();
                        foreach (string filename in files)
                        {
                            allLinesInAllFiles.AddRange(File.ReadAllLines(filename).ToList());
                        }
                        //List<string> methodNames = new List<string>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
