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

        Analyzer analyzer;

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        ReadFile(fbd.SelectedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadFile(string filepath = "C:\\Users\\WS0\\Documents\\Projects\\Project_A\\MR")
        {
            var files = Directory.GetFiles(filepath, "*.cs", SearchOption.AllDirectories);
            Console.WriteLine(files.Count());

            List<string> allLinesInAllFiles = new List<string>();
            foreach (string filename in files)
            {
                allLinesInAllFiles.AddRange(File.ReadAllLines(filename).ToList());
            }

            string moduleListing = string.Join("\n", allLinesInAllFiles);
            analyzer = new Analyzer(moduleListing);

            buttonDepth.Enabled = true;
            buttonChild.Enabled = true;
        }

        private void buttonDepth_Click(object sender, EventArgs e)
        {
            if (analyzer == null)
            {
                return;
            }

            var depthOfInheritanceTree = analyzer.GetDepthOfInheritanceTree();
            string result = "";
            foreach (var item in depthOfInheritanceTree)
            {
                result += item.Item1 + "\t" + item.Item2 + "\n";
            }

            richTextBoxResult.Text = result;
        }

        private void buttonChild_Click(object sender, EventArgs e)
        {
            if (analyzer == null)
            {
                return;
            }

            var numberOfChild = analyzer.GetNumberOfChild();
            string result = "";
            foreach (var item in numberOfChild)
            {
                result += item.Item1 + "\t" + item.Item2 + "\n";
            }

            richTextBoxResult.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
        }
    }
}
