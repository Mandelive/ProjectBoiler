namespace ProjectBoiler
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("BoiledProblems");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvProblems = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblParam5 = new System.Windows.Forms.Label();
            this.txtParam5 = new System.Windows.Forms.TextBox();
            this.lblParam4 = new System.Windows.Forms.Label();
            this.txtParam4 = new System.Windows.Forms.TextBox();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.txtParam3 = new System.Windows.Forms.TextBox();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.txtParam2 = new System.Windows.Forms.TextBox();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.txtParam1 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.consoleBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 538);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvProblems);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(240, 538);
            this.splitContainer2.SplitterDistance = 260;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SizeChanged += new System.EventHandler(this.splitContainer2_SizeChanged);
            // 
            // tvProblems
            // 
            this.tvProblems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProblems.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvProblems.HideSelection = false;
            this.tvProblems.HotTracking = true;
            this.tvProblems.Location = new System.Drawing.Point(0, 0);
            this.tvProblems.Name = "tvProblems";
            treeNode1.Name = "BoiledProblems";
            treeNode1.Text = "BoiledProblems";
            this.tvProblems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvProblems.Size = new System.Drawing.Size(240, 260);
            this.tvProblems.TabIndex = 0;
            this.tvProblems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProblems_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblParam5);
            this.panel1.Controls.Add(this.txtParam5);
            this.panel1.Controls.Add(this.lblParam4);
            this.panel1.Controls.Add(this.txtParam4);
            this.panel1.Controls.Add(this.lblParam3);
            this.panel1.Controls.Add(this.txtParam3);
            this.panel1.Controls.Add(this.lblParam2);
            this.panel1.Controls.Add(this.txtParam2);
            this.panel1.Controls.Add(this.lblParam1);
            this.panel1.Controls.Add(this.txtParam1);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 274);
            this.panel1.TabIndex = 0;
            // 
            // lblParam5
            // 
            this.lblParam5.AutoSize = true;
            this.lblParam5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam5.Location = new System.Drawing.Point(16, 180);
            this.lblParam5.Name = "lblParam5";
            this.lblParam5.Size = new System.Drawing.Size(49, 15);
            this.lblParam5.TabIndex = 11;
            this.lblParam5.Text = "Param5";
            // 
            // txtParam5
            // 
            this.txtParam5.Location = new System.Drawing.Point(16, 199);
            this.txtParam5.Name = "txtParam5";
            this.txtParam5.Size = new System.Drawing.Size(208, 20);
            this.txtParam5.TabIndex = 10;
            // 
            // lblParam4
            // 
            this.lblParam4.AutoSize = true;
            this.lblParam4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam4.Location = new System.Drawing.Point(16, 138);
            this.lblParam4.Name = "lblParam4";
            this.lblParam4.Size = new System.Drawing.Size(49, 15);
            this.lblParam4.TabIndex = 9;
            this.lblParam4.Text = "Param4";
            // 
            // txtParam4
            // 
            this.txtParam4.Location = new System.Drawing.Point(16, 157);
            this.txtParam4.Name = "txtParam4";
            this.txtParam4.Size = new System.Drawing.Size(208, 20);
            this.txtParam4.TabIndex = 8;
            // 
            // lblParam3
            // 
            this.lblParam3.AutoSize = true;
            this.lblParam3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam3.Location = new System.Drawing.Point(16, 96);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(49, 15);
            this.lblParam3.TabIndex = 7;
            this.lblParam3.Text = "Param3";
            // 
            // txtParam3
            // 
            this.txtParam3.Location = new System.Drawing.Point(16, 115);
            this.txtParam3.Name = "txtParam3";
            this.txtParam3.Size = new System.Drawing.Size(208, 20);
            this.txtParam3.TabIndex = 6;
            // 
            // lblParam2
            // 
            this.lblParam2.AutoSize = true;
            this.lblParam2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam2.Location = new System.Drawing.Point(16, 54);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(49, 15);
            this.lblParam2.TabIndex = 5;
            this.lblParam2.Text = "Param2";
            // 
            // txtParam2
            // 
            this.txtParam2.Location = new System.Drawing.Point(16, 73);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(208, 20);
            this.txtParam2.TabIndex = 4;
            // 
            // lblParam1
            // 
            this.lblParam1.AutoSize = true;
            this.lblParam1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam1.Location = new System.Drawing.Point(16, 12);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(49, 15);
            this.lblParam1.TabIndex = 3;
            this.lblParam1.Text = "Param1";
            // 
            // txtParam1
            // 
            this.txtParam1.Location = new System.Drawing.Point(16, 31);
            this.txtParam1.Name = "txtParam1";
            this.txtParam1.Size = new System.Drawing.Size(208, 20);
            this.txtParam1.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(134, 232);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(16, 232);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(90, 32);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // consoleBrowser
            // 
            this.consoleBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBrowser.Location = new System.Drawing.Point(0, 0);
            this.consoleBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.consoleBrowser.Name = "consoleBrowser";
            this.consoleBrowser.Size = new System.Drawing.Size(764, 538);
            this.consoleBrowser.TabIndex = 1;
            this.consoleBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.consoleBrowser_DocumentCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 538);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Main";
            this.Text = "ProjectBoiler";
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvProblems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.WebBrowser consoleBrowser;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.TextBox txtParam1;
        private System.Windows.Forms.Label lblParam5;
        private System.Windows.Forms.TextBox txtParam5;
        private System.Windows.Forms.Label lblParam4;
        private System.Windows.Forms.TextBox txtParam4;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.TextBox txtParam3;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.TextBox txtParam2;
    }
}