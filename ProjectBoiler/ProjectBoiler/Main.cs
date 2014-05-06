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
            var problems = from t in Assembly.GetAssembly(typeof(BoiledProblems.Problem1)).GetTypes()
                           //where t.IsClass && t.Name.StartsWith("Problem") && t.Namespace == "BoiledProblems"
                           select t;

            foreach (var p in problems)
            {
                treeView1.Nodes[0].Nodes.Add(p.Name);
            }
            treeView1.ExpandAll();

        }
    }
}
