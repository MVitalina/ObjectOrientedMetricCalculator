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

                        Analyzer analyzer = new Analyzer();
                        var depthOfInheritanceTree = analyzer.GetDepthOfInheritanceTree(string.Join("\n", allLinesInAllFiles));
                        foreach (var item in depthOfInheritanceTree)
                        {
                            Console.WriteLine(item.Item1 + "\t" + item.Item2);
                        }
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
