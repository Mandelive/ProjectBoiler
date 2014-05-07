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

namespace ProjectBoiler
{
    public partial class Main : Form
    {
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
            var problems = from t in Assembly.GetAssembly(typeof(BoiledProblems.Problem1)).GetTypes()
                           where t.IsClass && t.Name.StartsWith("Problem")
                           select t;

            foreach (var p in problems)
            {
                tvProblems.Nodes[0].Nodes.Add(p.Name);
            }
            tvProblems.ExpandAll();
        }

        private void InitializeConsoleBrowser()
        {
            var page = @"<html><head></head><body style=""color: #ffffff; background-color: #000000;""></body><html>";
            var ms = new MemoryStream();
            var bytes = Encoding.UTF8.GetBytes(page);
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            consoleBrowser.DocumentStream = ms;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {           
            var doc = consoleBrowser.Document;
            var element = doc.CreateElement("div");
            element.InnerHtml = "Hello <b>World!</b>";
            element.Style = "color: #ffffff;";
            consoleBrowser.Document.Body.AppendChild(element);
        }

        private void consoleBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            consoleBrowser.Document.Window.ScrollTo(0, Int16.MaxValue);
        }
    }
}
