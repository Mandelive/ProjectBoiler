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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("BoiledProblems");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvProblems = new System.Windows.Forms.TreeView();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.btnBrowseParam5 = new System.Windows.Forms.Button();
            this.btnBrowseParam4 = new System.Windows.Forms.Button();
            this.btnBrowseParam3 = new System.Windows.Forms.Button();
            this.btnBrowseParam2 = new System.Windows.Forms.Button();
            this.btnBrowseParam1 = new System.Windows.Forms.Button();
            this.btnDefaultParams = new System.Windows.Forms.Button();
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelParameters.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1136, 610);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
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
            this.splitContainer2.Panel2.Controls.Add(this.panelParameters);
            this.splitContainer2.Size = new System.Drawing.Size(360, 610);
            this.splitContainer2.SplitterDistance = 294;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            this.splitContainer2.SizeChanged += new System.EventHandler(this.splitContainer2_SizeChanged);
            // 
            // tvProblems
            // 
            this.tvProblems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProblems.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvProblems.HideSelection = false;
            this.tvProblems.HotTracking = true;
            this.tvProblems.Location = new System.Drawing.Point(0, 0);
            this.tvProblems.Name = "tvProblems";
            treeNode5.Name = "BoiledProblems";
            treeNode5.Text = "BoiledProblems";
            this.tvProblems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tvProblems.Size = new System.Drawing.Size(360, 294);
            this.tvProblems.TabIndex = 0;
            this.tvProblems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProblems_AfterSelect);
            // 
            // panelParameters
            // 
            this.panelParameters.Controls.Add(this.btnBrowseParam5);
            this.panelParameters.Controls.Add(this.btnBrowseParam4);
            this.panelParameters.Controls.Add(this.btnBrowseParam3);
            this.panelParameters.Controls.Add(this.btnBrowseParam2);
            this.panelParameters.Controls.Add(this.btnBrowseParam1);
            this.panelParameters.Controls.Add(this.btnDefaultParams);
            this.panelParameters.Controls.Add(this.lblParam5);
            this.panelParameters.Controls.Add(this.txtParam5);
            this.panelParameters.Controls.Add(this.lblParam4);
            this.panelParameters.Controls.Add(this.txtParam4);
            this.panelParameters.Controls.Add(this.lblParam3);
            this.panelParameters.Controls.Add(this.txtParam3);
            this.panelParameters.Controls.Add(this.lblParam2);
            this.panelParameters.Controls.Add(this.txtParam2);
            this.panelParameters.Controls.Add(this.lblParam1);
            this.panelParameters.Controls.Add(this.txtParam1);
            this.panelParameters.Controls.Add(this.btnClear);
            this.panelParameters.Controls.Add(this.btnSolve);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParameters.Location = new System.Drawing.Point(0, 0);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(360, 312);
            this.panelParameters.TabIndex = 0;
            // 
            // btnBrowseParam5
            // 
            this.btnBrowseParam5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseParam5.Location = new System.Drawing.Point(299, 231);
            this.btnBrowseParam5.Name = "btnBrowseParam5";
            this.btnBrowseParam5.Size = new System.Drawing.Size(42, 21);
            this.btnBrowseParam5.TabIndex = 17;
            this.btnBrowseParam5.Text = "...";
            this.btnBrowseParam5.UseVisualStyleBackColor = true;
            this.btnBrowseParam5.Visible = false;
            // 
            // btnBrowseParam4
            // 
            this.btnBrowseParam4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseParam4.Location = new System.Drawing.Point(299, 182);
            this.btnBrowseParam4.Name = "btnBrowseParam4";
            this.btnBrowseParam4.Size = new System.Drawing.Size(42, 21);
            this.btnBrowseParam4.TabIndex = 16;
            this.btnBrowseParam4.Text = "...";
            this.btnBrowseParam4.UseVisualStyleBackColor = true;
            this.btnBrowseParam4.Visible = false;
            // 
            // btnBrowseParam3
            // 
            this.btnBrowseParam3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseParam3.Location = new System.Drawing.Point(299, 133);
            this.btnBrowseParam3.Name = "btnBrowseParam3";
            this.btnBrowseParam3.Size = new System.Drawing.Size(42, 21);
            this.btnBrowseParam3.TabIndex = 15;
            this.btnBrowseParam3.Text = "...";
            this.btnBrowseParam3.UseVisualStyleBackColor = true;
            this.btnBrowseParam3.Visible = false;
            // 
            // btnBrowseParam2
            // 
            this.btnBrowseParam2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseParam2.Location = new System.Drawing.Point(299, 84);
            this.btnBrowseParam2.Name = "btnBrowseParam2";
            this.btnBrowseParam2.Size = new System.Drawing.Size(42, 21);
            this.btnBrowseParam2.TabIndex = 14;
            this.btnBrowseParam2.Text = "...";
            this.btnBrowseParam2.UseVisualStyleBackColor = true;
            this.btnBrowseParam2.Visible = false;
            this.btnBrowseParam2.Click += new System.EventHandler(this.btnBrowseParamX_Click);
            // 
            // btnBrowseParam1
            // 
            this.btnBrowseParam1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseParam1.Location = new System.Drawing.Point(299, 35);
            this.btnBrowseParam1.Name = "btnBrowseParam1";
            this.btnBrowseParam1.Size = new System.Drawing.Size(42, 21);
            this.btnBrowseParam1.TabIndex = 13;
            this.btnBrowseParam1.Text = "...";
            this.btnBrowseParam1.UseVisualStyleBackColor = true;
            this.btnBrowseParam1.Visible = false;
            this.btnBrowseParam1.Click += new System.EventHandler(this.btnBrowseParamX_Click);
            // 
            // btnDefaultParams
            // 
            this.btnDefaultParams.Location = new System.Drawing.Point(134, 268);
            this.btnDefaultParams.Name = "btnDefaultParams";
            this.btnDefaultParams.Size = new System.Drawing.Size(90, 32);
            this.btnDefaultParams.TabIndex = 12;
            this.btnDefaultParams.Text = "Default Params";
            this.btnDefaultParams.UseVisualStyleBackColor = true;
            this.btnDefaultParams.Click += new System.EventHandler(this.btnDefaultParams_Click);
            // 
            // lblParam5
            // 
            this.lblParam5.AutoSize = true;
            this.lblParam5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam5.Location = new System.Drawing.Point(16, 209);
            this.lblParam5.Name = "lblParam5";
            this.lblParam5.Size = new System.Drawing.Size(56, 18);
            this.lblParam5.TabIndex = 11;
            this.lblParam5.Text = "Param5";
            // 
            // txtParam5
            // 
            this.txtParam5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam5.Location = new System.Drawing.Point(16, 230);
            this.txtParam5.Name = "txtParam5";
            this.txtParam5.Size = new System.Drawing.Size(326, 23);
            this.txtParam5.TabIndex = 10;
            // 
            // lblParam4
            // 
            this.lblParam4.AutoSize = true;
            this.lblParam4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam4.Location = new System.Drawing.Point(16, 160);
            this.lblParam4.Name = "lblParam4";
            this.lblParam4.Size = new System.Drawing.Size(56, 18);
            this.lblParam4.TabIndex = 9;
            this.lblParam4.Text = "Param4";
            // 
            // txtParam4
            // 
            this.txtParam4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam4.Location = new System.Drawing.Point(16, 181);
            this.txtParam4.Name = "txtParam4";
            this.txtParam4.Size = new System.Drawing.Size(326, 23);
            this.txtParam4.TabIndex = 8;
            // 
            // lblParam3
            // 
            this.lblParam3.AutoSize = true;
            this.lblParam3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam3.Location = new System.Drawing.Point(16, 111);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(56, 18);
            this.lblParam3.TabIndex = 7;
            this.lblParam3.Text = "Param3";
            // 
            // txtParam3
            // 
            this.txtParam3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam3.Location = new System.Drawing.Point(16, 132);
            this.txtParam3.Name = "txtParam3";
            this.txtParam3.Size = new System.Drawing.Size(326, 23);
            this.txtParam3.TabIndex = 6;
            // 
            // lblParam2
            // 
            this.lblParam2.AutoSize = true;
            this.lblParam2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam2.Location = new System.Drawing.Point(16, 62);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(56, 18);
            this.lblParam2.TabIndex = 5;
            this.lblParam2.Text = "Param2";
            // 
            // txtParam2
            // 
            this.txtParam2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam2.Location = new System.Drawing.Point(16, 83);
            this.txtParam2.Name = "txtParam2";
            this.txtParam2.Size = new System.Drawing.Size(326, 23);
            this.txtParam2.TabIndex = 4;
            // 
            // lblParam1
            // 
            this.lblParam1.AutoSize = true;
            this.lblParam1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam1.Location = new System.Drawing.Point(16, 13);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(56, 18);
            this.lblParam1.TabIndex = 3;
            this.lblParam1.Text = "Param1";
            // 
            // txtParam1
            // 
            this.txtParam1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParam1.Location = new System.Drawing.Point(16, 34);
            this.txtParam1.Name = "txtParam1";
            this.txtParam1.Size = new System.Drawing.Size(326, 23);
            this.txtParam1.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 268);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(16, 268);
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
            this.consoleBrowser.Size = new System.Drawing.Size(772, 610);
            this.consoleBrowser.TabIndex = 1;
            this.consoleBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.consoleBrowser_DocumentCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.ShowReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 610);
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
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvProblems;
        private System.Windows.Forms.Panel panelParameters;
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
        private System.Windows.Forms.Button btnDefaultParams;
        private System.Windows.Forms.Button btnBrowseParam5;
        private System.Windows.Forms.Button btnBrowseParam4;
        private System.Windows.Forms.Button btnBrowseParam3;
        private System.Windows.Forms.Button btnBrowseParam2;
        private System.Windows.Forms.Button btnBrowseParam1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}