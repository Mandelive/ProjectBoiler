using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;
using BoiledProblems;

namespace ProjectBoiler
{
    public partial class Main : Form
    {
        IProblem currentProblem;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeConsoleBrowser();
            PopulateProblemsTree();
        }

        private void PopulateProblemsTree()
        {
            var problems = from t in Assembly.GetAssembly(typeof(BoiledProblems.IProblem)).GetTypes()
                           where t.IsClass && t.Name.StartsWith("Problem")
                           orderby t.Name
                           select t;

            foreach (var p in problems)
            {
                tvProblems.Nodes[0].Nodes.Add(p.Name);
            }

            tvProblems.ExpandAll();
        }

        private void InitializeConsoleBrowser()
        {
            var page = @"<html><head></head><body style=""background-color: #000000; color: #ffffff; font-family: Consolas, ""Courier New"", ""Lucida Console"", Arial;""></body><html>";
            var ms = new MemoryStream();
            var bytes = Encoding.UTF8.GetBytes(page);
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            consoleBrowser.DocumentStream = ms;
        }

        private void ChangeProblem()
        {
            var selectedProblem = tvProblems.SelectedNode.Text;
            var problemType = (from t in Assembly.GetAssembly(typeof(BoiledProblems.IProblem)).GetTypes()
                               where t.IsClass && t.Name == selectedProblem
                               select t).First();

            currentProblem = (IProblem)Activator.CreateInstance(problemType);

            var doc = consoleBrowser.Document;

            var element = doc.CreateElement("span");
            element.Style = "color: #ddbb33; font-weight: bold;";
            element.InnerText = "Problem " + currentProblem.GetID().ToString() + ": ";
            consoleBrowser.Document.Body.AppendChild(element);

            element = doc.CreateElement("span");
            element.Style = "font-weight: bold;";
            element.InnerText = currentProblem.GetTitle();
            consoleBrowser.Document.Body.AppendChild(element);

            element = doc.CreateElement("div");
            element.InnerText = currentProblem.GetDescription();
            consoleBrowser.Document.Body.AppendChild(element);

            element = doc.CreateElement("br");
            consoleBrowser.Document.Body.AppendChild(element);

            consoleBrowser.Document.Window.ScrollTo(0, Int16.MaxValue);
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            
        }

        private void consoleBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            consoleBrowser.Document.Window.ScrollTo(0, Int16.MaxValue);
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 240;
        }

        private void tvProblems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvProblems.SelectedNode.Text.StartsWith("Problem"))
            {
                ChangeProblem();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tvProblems.Focus();
            consoleBrowser.Document.Body.InnerText = "";
            if (tvProblems.SelectedNode.Text.StartsWith("Problem"))
            {
                ChangeProblem();
            }
        }

        private void splitContainer2_SizeChanged(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 278;
        }
    }
}
