namespace POCO_EF_Oracle
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCodeGenerator = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBoxLoadConstraints = new System.Windows.Forms.CheckBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.CheckBoxIsView = new System.Windows.Forms.CheckBox();
            this.TextFilterName = new System.Windows.Forms.TextBox();
            this.CheckBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxLength = new System.Windows.Forms.CheckBox();
            this.checkBoxRequired = new System.Windows.Forms.CheckBox();
            this.checkBoxPrimaryKey = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeName = new System.Windows.Forms.CheckBox();
            this.textBoxNamespace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTnsNames = new System.Windows.Forms.ComboBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1107, 894);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 449);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 387);
            this.panel3.TabIndex = 31;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(252, 387);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCodeGenerator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 836);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 58);
            this.panel2.TabIndex = 30;
            // 
            // buttonCodeGenerator
            // 
            this.buttonCodeGenerator.Location = new System.Drawing.Point(10, 11);
            this.buttonCodeGenerator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCodeGenerator.Name = "buttonCodeGenerator";
            this.buttonCodeGenerator.Size = new System.Drawing.Size(363, 35);
            this.buttonCodeGenerator.TabIndex = 9;
            this.buttonCodeGenerator.Text = "Code Generator";
            this.buttonCodeGenerator.UseVisualStyleBackColor = true;
            this.buttonCodeGenerator.Click += new System.EventHandler(this.buttonCodeGenerator_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckBoxLoadConstraints);
            this.panel1.Controls.Add(this.ButtonSearch);
            this.panel1.Controls.Add(this.CheckBoxIsView);
            this.panel1.Controls.Add(this.TextFilterName);
            this.panel1.Controls.Add(this.CheckBoxShowPassword);
            this.panel1.Controls.Add(this.checkBoxLength);
            this.panel1.Controls.Add(this.checkBoxRequired);
            this.panel1.Controls.Add(this.checkBoxPrimaryKey);
            this.panel1.Controls.Add(this.checkBoxTypeName);
            this.panel1.Controls.Add(this.textBoxNamespace);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxTnsNames);
            this.panel1.Controls.Add(this.textBoxUserId);
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 449);
            this.panel1.TabIndex = 29;
            // 
            // CheckBoxLoadConstraints
            // 
            this.CheckBoxLoadConstraints.AutoSize = true;
            this.CheckBoxLoadConstraints.Location = new System.Drawing.Point(116, 405);
            this.CheckBoxLoadConstraints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxLoadConstraints.Name = "CheckBoxLoadConstraints";
            this.CheckBoxLoadConstraints.Size = new System.Drawing.Size(101, 24);
            this.CheckBoxLoadConstraints.TabIndex = 10;
            this.CheckBoxLoadConstraints.Text = "Constraint";
            this.CheckBoxLoadConstraints.UseVisualStyleBackColor = true;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(261, 400);
            this.ButtonSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(112, 35);
            this.ButtonSearch.TabIndex = 38;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // CheckBoxIsView
            // 
            this.CheckBoxIsView.AutoSize = true;
            this.CheckBoxIsView.Location = new System.Drawing.Point(10, 405);
            this.CheckBoxIsView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxIsView.Name = "CheckBoxIsView";
            this.CheckBoxIsView.Size = new System.Drawing.Size(79, 24);
            this.CheckBoxIsView.TabIndex = 37;
            this.CheckBoxIsView.Text = "Is View";
            this.CheckBoxIsView.UseVisualStyleBackColor = true;
            // 
            // TextFilterName
            // 
            this.TextFilterName.Location = new System.Drawing.Point(10, 365);
            this.TextFilterName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextFilterName.Name = "TextFilterName";
            this.TextFilterName.Size = new System.Drawing.Size(361, 26);
            this.TextFilterName.TabIndex = 36;
            this.TextFilterName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.TextFilterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextFilterName_KeyPress);
            // 
            // CheckBoxShowPassword
            // 
            this.CheckBoxShowPassword.AutoSize = true;
            this.CheckBoxShowPassword.Checked = true;
            this.CheckBoxShowPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxShowPassword.Location = new System.Drawing.Point(294, 75);
            this.CheckBoxShowPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxShowPassword.Name = "CheckBoxShowPassword";
            this.CheckBoxShowPassword.Size = new System.Drawing.Size(68, 24);
            this.CheckBoxShowPassword.TabIndex = 35;
            this.CheckBoxShowPassword.Text = "Show";
            this.CheckBoxShowPassword.UseVisualStyleBackColor = true;
            this.CheckBoxShowPassword.CheckedChanged += new System.EventHandler(this.CheckBoxShowPassword_CheckedChanged);
            // 
            // checkBoxLength
            // 
            this.checkBoxLength.AutoSize = true;
            this.checkBoxLength.Checked = true;
            this.checkBoxLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLength.Location = new System.Drawing.Point(136, 289);
            this.checkBoxLength.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxLength.Name = "checkBoxLength";
            this.checkBoxLength.Size = new System.Drawing.Size(78, 24);
            this.checkBoxLength.TabIndex = 32;
            this.checkBoxLength.Text = "Length";
            this.checkBoxLength.UseVisualStyleBackColor = true;
            this.checkBoxLength.Click += new System.EventHandler(this.checkBoxTypeName_Click);
            // 
            // checkBoxRequired
            // 
            this.checkBoxRequired.AutoSize = true;
            this.checkBoxRequired.Checked = true;
            this.checkBoxRequired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRequired.Location = new System.Drawing.Point(10, 289);
            this.checkBoxRequired.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxRequired.Name = "checkBoxRequired";
            this.checkBoxRequired.Size = new System.Drawing.Size(93, 24);
            this.checkBoxRequired.TabIndex = 32;
            this.checkBoxRequired.Text = "Required";
            this.checkBoxRequired.UseVisualStyleBackColor = true;
            this.checkBoxRequired.Click += new System.EventHandler(this.checkBoxTypeName_Click);
            // 
            // checkBoxPrimaryKey
            // 
            this.checkBoxPrimaryKey.AutoSize = true;
            this.checkBoxPrimaryKey.Checked = true;
            this.checkBoxPrimaryKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrimaryKey.Location = new System.Drawing.Point(136, 257);
            this.checkBoxPrimaryKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxPrimaryKey.Name = "checkBoxPrimaryKey";
            this.checkBoxPrimaryKey.Size = new System.Drawing.Size(110, 24);
            this.checkBoxPrimaryKey.TabIndex = 32;
            this.checkBoxPrimaryKey.Text = "Primary Key";
            this.checkBoxPrimaryKey.UseVisualStyleBackColor = true;
            this.checkBoxPrimaryKey.Click += new System.EventHandler(this.checkBoxTypeName_Click);
            // 
            // checkBoxTypeName
            // 
            this.checkBoxTypeName.AutoSize = true;
            this.checkBoxTypeName.Checked = true;
            this.checkBoxTypeName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTypeName.Location = new System.Drawing.Point(10, 257);
            this.checkBoxTypeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxTypeName.Name = "checkBoxTypeName";
            this.checkBoxTypeName.Size = new System.Drawing.Size(104, 24);
            this.checkBoxTypeName.TabIndex = 32;
            this.checkBoxTypeName.Text = "TypeName";
            this.checkBoxTypeName.UseVisualStyleBackColor = true;
            this.checkBoxTypeName.Click += new System.EventHandler(this.checkBoxTypeName_Click);
            // 
            // textBoxNamespace
            // 
            this.textBoxNamespace.Location = new System.Drawing.Point(10, 214);
            this.textBoxNamespace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNamespace.Name = "textBoxNamespace";
            this.textBoxNamespace.Size = new System.Drawing.Size(361, 26);
            this.textBoxNamespace.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Namespace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Filter Name:";
            // 
            // comboBoxTnsNames
            // 
            this.comboBoxTnsNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTnsNames.FormattingEnabled = true;
            this.comboBoxTnsNames.Location = new System.Drawing.Point(10, 38);
            this.comboBoxTnsNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTnsNames.Name = "comboBoxTnsNames";
            this.comboBoxTnsNames.Size = new System.Drawing.Size(361, 28);
            this.comboBoxTnsNames.TabIndex = 6;
            this.comboBoxTnsNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxTnsNames_KeyPress);
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxUserId.Location = new System.Drawing.Point(10, 103);
            this.textBoxUserId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(154, 26);
            this.textBoxUserId.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(171, 103);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(200, 20);
            this.textPassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "User Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "TNS Name";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(10, 140);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(363, 37);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(849, 894);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 894);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "POCO EntityFramework for Oracle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCodeGenerator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxTnsNames;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox CheckBoxShowPassword;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.CheckBox CheckBoxIsView;
        private System.Windows.Forms.TextBox TextFilterName;
        private System.Windows.Forms.CheckBox checkBoxLength;
        private System.Windows.Forms.CheckBox checkBoxRequired;
        private System.Windows.Forms.CheckBox checkBoxPrimaryKey;
        private System.Windows.Forms.CheckBox checkBoxTypeName;
        private System.Windows.Forms.TextBox textBoxNamespace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox CheckBoxLoadConstraints;
    }
}

