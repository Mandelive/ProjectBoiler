﻿using System;
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
                           //orderby t.Name.Substring("Problem".Length)
                           select t;

            foreach (var p in problems)
            {
                var problem = (IProblem)Activator.CreateInstance(p);
                tvProblems.Nodes[0].Nodes.Add(problem.Id.ToString("000"), problem.Id.ToString("000: ") + problem.Title);
            }

            tvProblems.Sort();

            tvProblems.ExpandAll();
        }

        private void InitializeConsoleBrowser()
        {
            var page = @"<html><head></head><body style=""background-color: #000000; color: #ffffff; font-family: Consolas, 'Courier New', 'DejaVu Sans Mono';""></body><html>";
            var ms = new MemoryStream();
            var bytes = Encoding.UTF8.GetBytes(page);
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            consoleBrowser.DocumentStream = ms;
        }

        private void ChangeProblem()
        {
            var selectedProblemNumber = Int32.Parse(tvProblems.SelectedNode.Name.Substring(0, 3));
            var problemType = (from t in Assembly.GetAssembly(typeof(BoiledProblems.IProblem)).GetTypes()
                               where t.IsClass && t.Name == ("Problem" + selectedProblemNumber)
                               select t).First();

            currentProblem = (IProblem)Activator.CreateInstance(problemType);

            WriteToConsole("span", "Problem " + currentProblem.Id.ToString() + ": ", true);
            WriteToConsole("span", currentProblem.Title, "font-weight: bold;");
            WriteToConsole("div", currentProblem.Description);
            WriteToConsole("br");

            var paramsInfo = currentProblem.GetParametersInfo();

            foreach (var p in paramsInfo)
            {
                WriteToConsole("span", p.Substring(0, p.IndexOf(' ')), true);
                WriteToConsole("span", p.Substring(p.IndexOf(' ')));
                WriteToConsole("br");
            }

            WriteToConsole("br");
        }

        private void ChangeParameters()
        {
            var parametersInfo = currentProblem.GetParametersInfo();
            var defaultParameters = currentProblem.GetDefaultParameters();

            for (int i = 0; i < 5; i++)
            {
                var label = (Label)Controls.Find("lblParam" + (i + 1), true).First();
                var input = (TextBox)Controls.Find("txtParam" + (i + 1), true).First();
                if (i < parametersInfo.Length)
                {
                    label.Text = parametersInfo[i].Substring(0, parametersInfo[i].IndexOf(' '));
                    input.Text = defaultParameters[i];
                    label.Enabled = true;
                    input.Enabled = true;
                }
                else
                {
                    label.Text = "";
                    input.Text = "";
                    label.Enabled = false;
                    input.Enabled = false;
                }
            }
        }

        private void ClearCurrentProblem()
        {
            currentProblem = null;
        }

        private void ClearParameters()
        {
            for (int i = 0; i < 5; i++)
            {
                var label = (Label)Controls.Find("lblParam" + (i + 1), true).First();
                var input = (TextBox)Controls.Find("txtParam" + (i + 1), true).First();
                label.Text = "";
                input.Text = "";
                label.Enabled = false;
                input.Enabled = false;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            txtParam1.Focus();
            BenchmarkProblemSolving();
        }

        private async void BenchmarkProblemSolving()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var parameters = new string[currentProblem.ParametersCount];
            Control paramsTextBoxContainer = txtParam1.Parent;
            for (int i = 0; i < currentProblem.ParametersCount; i++)
            {
                var paramTextBox = paramsTextBoxContainer.Controls.Find("txtParam" + (i + 1), false).First();
                parameters[i] = paramTextBox.Text;
            }
            currentProblem.SetParameters(parameters);

            var parametersInfo = currentProblem.GetParametersInfo();
            var parametersLine = "";
            for (int i = 0; i < currentProblem.ParametersCount; i++)
            {
                if (!String.IsNullOrEmpty(parameters[i]))
                {
                    parametersLine += parametersInfo[i].Substring(0, parametersInfo[i].IndexOf(':')) + ": " + parameters[i] + ", ";
                }
            }
            parametersLine = parametersLine.Substring(0, parametersLine.Length - 2);

            WriteToConsole("span", "Paramaters: ", true);
            WriteToConsole("span", parametersLine);
            WriteToConsole("br");

            var startTime = DateTime.UtcNow;
            var t = new Task<string>(() => currentProblem.Solve());
            t.Start();
            var result = await t;
            var endTime = DateTime.UtcNow;

            var totalTime = endTime - startTime;

            WriteToConsole("span", "Answer: ", true);
            WriteToConsole("span", result);
            WriteToConsole("br");

            WriteToConsole("span", "Time elapsed: ", true);
            WriteToConsole("span", Math.Round(totalTime.TotalMilliseconds / 1000d, 3).ToString("0.000s"));
            WriteToConsole("br");
            WriteToConsole("br");
        }

        private void consoleBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            consoleBrowser.Document.Window.ScrollTo(0, Int16.MaxValue);
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 320;
        }

        private void tvProblems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvProblems.SelectedNode.Level > 0)
            {
                consoleBrowser.Document.Body.InnerText = "";
                ChangeProblem();
                ChangeParameters();
                btnSolve.Enabled = true;
            }
            else
            {
                if (consoleBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    consoleBrowser.Document.Body.InnerText = "";
                }
                ClearCurrentProblem();
                ClearParameters();
                btnSolve.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tvProblems.Focus();
            consoleBrowser.Document.Body.InnerText = "";
            if (tvProblems.SelectedNode.Level > 0)
            {
                ChangeProblem();
            }
        }

        private void splitContainer2_SizeChanged(object sender, EventArgs e)
        {
            //splitContainer2.SplitterDistance = splitContainer2.Height - 278;
        }

        private void WriteToConsole(string elementType, string text, bool emphasis)
        {
            WriteToConsole(elementType, text, "color: #ee8844; font-weight: bold;");
        }

        private void WriteToConsole(string elementType, string text = "", string style = "")
        {
            var doc = consoleBrowser.Document;

            var element = doc.CreateElement(elementType);
            element.Style = style; 
            if (elementType != "br")
            {
                element.InnerText = text;
            }

            doc.Body.AppendChild(element);

            consoleBrowser.Document.Window.ScrollTo(0, Int16.MaxValue);
        }
    }
}
