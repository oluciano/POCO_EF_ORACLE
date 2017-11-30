using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using POCO_EF_Oracle.Controllers;
using POCO_EF_Oracle.Models;
using System.IO;
using ScintillaNET;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace POCO_EF_Oracle
{
    public partial class Form1 : Form
    {

        private bool _isConnected;

        public ImageList IconsList { get; } = new ImageList();

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetTnsOracle();
            LoadIconsList();
        }

        private void LoadIconsList()
        {
            IconsList.Images.Add(Properties.Resources.fileIcon);
            tabControl1.ImageList = IconsList;

        }

        private void GetTnsOracle()
        {
            try
            {
                var tns = DbUtil.ListTnsNames();
                var tnsClean = tns.Where(c => !c.Contains("CONNECT_DATA") && !c.Contains("Sample")).ToList();
                tnsClean.ForEach(c => comboBoxTnsNames.Items.Add(c));
                if (tnsClean.Count > 0)
                    comboBoxTnsNames.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (string.IsNullOrEmpty(comboBoxTnsNames.Text) || string.IsNullOrEmpty(textPassword.Text) || string.IsNullOrEmpty(textBoxUserId.Text))
            {
                MessageBox.Show("TNS Name, Password and User Id are requeried");
                return;
            }
            try
            {
                if (_isConnected)
                {
                    DbUtil.CloseConnection();
                    _isConnected = false;
                    buttonConnect.Text = "Connect";
                }
                else
                {
                    DbUtil.OpenConnection(comboBoxTnsNames.Text, textBoxUserId.Text, textPassword.Text);
                    buttonConnect.Text = "Disconect";
                    panel2.Enabled = true;
                    _isConnected = true;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        internal void Listbox_MouseDown(object sender, MouseEventArgs e)
        {
            var list = sender as ListBox;
            if (e.Button == MouseButtons.Right && list.SelectedItems.Count > 0)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem subMenu01 = new ToolStripMenuItem("Generate Code") { Name = "GENERATE" };

                subMenu01.Click += new EventHandler(itemListColums_click);
                menu.Items.AddRange(new ToolStripItem[] { subMenu01 });
                menu.Show(list, e.Location);
            }
        }

        private void itemListColums_click(object sender, EventArgs e)
        {
            var tabSeletected = tabControl1.SelectedTab.Controls.Cast<SplitContainer>().FirstOrDefault();
            var panel = tabSeletected.Panel2;
            var listSelected = panel.Controls.Cast<ListBox>().FirstOrDefault().SelectedItems;
            if (listSelected.Count > 0)
            {
                List<TableView> viewSelected = new List<TableView>();
                foreach (var item in listSelected)
                    viewSelected.Add(item as TableView);

                new TabService().EditPageSelected(tabControl1.SelectedTab, viewSelected, this);
            }

        }

        internal void ColumnsItem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buttonLoadTables_Click(object sender, EventArgs e)
        {
            //ListTables.Items.Clear();
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    var lisTables = DbUtil.LisTables(null);
            //    lisTables.ForEach(c => ListTables.Items.Add(c));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void buttonLoadViews_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            try
            {
                Cursor = Cursors.WaitCursor;
                var viewList = DbUtil.ListViews(null);
                viewList.ForEach(c => treeView1.Nodes.Add(c));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void buttonCodeGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> node = new List<string>();
                foreach (TreeNode item in treeView1.Nodes)
                    if (item.Checked)
                    {
                        node.Add(item.Text);
                        foreach (TreeNode item2 in item.Nodes)
                            if (item2.Checked)
                                node.Add(item2.Text);
                    }


                var x = treeView1.Nodes;
                Cursor = Cursors.WaitCursor;
                foreach (string item in node)
                {
                    AddModel(item);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void comboBoxTnsNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void AddModel(string tableName)
        {
            foreach (TabPage tab in tabControl1.TabPages)
                if (tab.Name == tableName)
                    return;

            var friendlyName = Services.FriendlyName(tableName);
            var last = friendlyName[friendlyName.Length - 1];

            if (last.Equals('V') && CheckBoxIsView.Checked)
                friendlyName = friendlyName.Remove(friendlyName.Length - 1);

            friendlyName = friendlyName.Contains("Dlb") ? friendlyName.Replace("Dlb", "") : friendlyName;
            var nameOfFile = string.Concat(friendlyName, ".cs");

            var columnsName = CheckBoxIsView.Checked ? DbUtil.ColumunsViews(tableName) : DbUtil.ColumnsTable(tableName);

            TabControlTable controlTable = new TabControlTable()
            {
                Table = tableName,
                FriendlyTable = friendlyName,
                TypeName = checkBoxTypeName.Checked,
                Length = checkBoxLength.Checked,
                PrimaryKey = checkBoxPrimaryKey.Checked,
                Required = checkBoxRequired.Checked,
                IsView = CheckBoxIsView.Checked,
                NameSpace = textBoxNamespace.Text,
                NameOfFile = nameOfFile,
                Schema = textBoxUserId.Text.ToUpper(),
                Columns = columnsName
            };
            new TabService().AddPageTab(controlTable, tabControl1, this);
        }

        private void checkBoxTypeName_Click(object sender, EventArgs e)
        {
            buttonCodeGenerator.PerformClick();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: remove it
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tab = sender as TabPage;
                CreateContextMenu(sender, e);
            }
        }

        internal void ColumnsItem_Click(object sender, EventArgs e)
        {
            var list = sender as ListBox;
            var listSelected = list.SelectedItems;
            if (listSelected.Count > 0)
            {
                List<TableView> viewSelected = new List<TableView>();
                foreach (var item in listSelected)
                    viewSelected.Add(item as TableView);

                new TabService().EditPageSelected(tabControl1.SelectedTab, viewSelected, this);
            }

        }

        void CreateContextMenu(object sender, MouseEventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem subMenu01 = new ToolStripMenuItem("Close") { Name = "CLOSE_THIS" };
            ToolStripMenuItem subMenu02 = new ToolStripMenuItem("Close all BUT This") { Name = "CLOSE_ALL_BUT_THIS" };
            ToolStripMenuItem subMenu03 = new ToolStripMenuItem("Close All") { Name = "CLOSE_ALL" };
            ToolStripMenuItem subMenu04 = new ToolStripMenuItem("Save As..") { Name = "SAVE_AS" };
            ToolStripMenuItem subMenu05 = new ToolStripMenuItem("Save All...") { Name = "SAVE_ALL" };
            ToolStripSeparator subMenuSeparetor = new ToolStripSeparator();

            subMenu01.Click += new EventHandler(menuItemClose_click);
            subMenu02.Click += new EventHandler(menuItemClose_click);
            subMenu03.Click += new EventHandler(menuItemClose_click);
            subMenu04.Click += new EventHandler(menuItemClose_click);
            subMenu05.Click += new EventHandler(menuItemClose_click);
            menu.Items.AddRange(new ToolStripItem[] { subMenu01, subMenu02, subMenu03, subMenuSeparetor, subMenu04, subMenu05 });

            menu.Show(tabControl1, e.Location);
        }

        private void menuItemClose_click(object sender, EventArgs e)
        {
            var s = sender as ToolStripMenuItem;
            switch (s.Name)
            {
                case "CLOSE_THIS":
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    break;
                case "CLOSE_ALL":
                    tabControl1.TabPages.Clear();
                    break;
                case "CLOSE_ALL_BUT_THIS":
                    var old = tabControl1.SelectedTab;
                    try
                    {
                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.Add(old);
                    }
                    catch
                    {
                        tabControl1.TabPages.Add(old);
                    }
                    break;
                case "SAVE_AS":
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            var tab = tabControl1.SelectedTab;
                            var path = folderBrowserDialog1.SelectedPath;
                            var splitForm = tab.Controls.Cast<SplitContainer>().FirstOrDefault();
                            var myPanel = splitForm.Panel1.Controls.Cast<Control>().FirstOrDefault(c => c is Panel) as Panel;
                            var panelAreaScintilla = myPanel.Controls.Cast<Scintilla>().FirstOrDefault(c => c is Scintilla) as Scintilla;

                            SaveFile(path, tab.Text, panelAreaScintilla.Text);

                            DialogResult dialogResult = MessageBox.Show("Do you want to open this file?", "Saved successfully", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Process.Start(path);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error" + ex.Message);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                    break;
                case "SAVE_ALL":
                    try
                    {
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            var path = folderBrowserDialog1.SelectedPath;
                            Cursor = Cursors.WaitCursor;
                            foreach (TabPage tab in tabControl1.TabPages)
                            {                                
                                var splitForm = tab.Controls.Cast<SplitContainer>().FirstOrDefault();
                                var myPanel = splitForm.Panel1.Controls.Cast<Control>().FirstOrDefault(c => c is Panel) as Panel;
                                var panelAreaScintilla = myPanel.Controls.Cast<Scintilla>().FirstOrDefault(c => c is Scintilla) as Scintilla;

                                SaveFile(path, tab.Text, panelAreaScintilla.Text);
                            }
                            DialogResult dialogResult = MessageBox.Show("Do you want to open these files?", "Saved successfully", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Process.Start(path);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                    break;
            }
        }

        void SaveFile(string path, string nameOfFile, string text)
        {
            var pathFile = Path.Combine(path, nameOfFile);
            if (File.Exists(pathFile))
                File.Delete(pathFile);
            File.WriteAllText(pathFile, text);
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxShowPassword.CheckState == CheckState.Unchecked)
                textPassword.PasswordChar = '#';
            else
                textPassword.PasswordChar = '\0';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {

            TreeNode node;

            Cursor = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            try
            {
                List<string> viewList = new List<string>();
                if (CheckBoxIsView.Checked)
                    viewList = DbUtil.ListViews(TextFilterName.Text);
                else
                    viewList = DbUtil.LisTables(TextFilterName.Text);

                foreach (var item in viewList.ToArray())
                {
                    node = treeView1.Nodes.Add(item);
                    if (CheckBoxLoadConstraints.Checked && !CheckBoxIsView.Checked)
                    {
                        var constraints = DbUtil.ListAllForeignKeyes(item);
                        if (constraints.Any())
                            constraints.ForEach(n => node.Nodes.Add(n.ToString()));

                        viewList.RemoveAll(x => constraints.ToList().Exists(c => c.ChildTable == x));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        private void TextFilterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void ListTables_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.A && e.Control)
            //{
            //    e.SuppressKeyPress = true;
            //    for (int i = 0; i < ListTables.Items.Count; i++)
            //        ListTables.SetSelected(i, true);

            //}
            //else if (e.KeyCode == Keys.Z && e.Control)
            //{
            //    e.SuppressKeyPress = true;
            //    for (int i = 0; i < ListTables.Items.Count; i++)
            //        ListTables.SetSelected(i, false);

            //}
        }

        private void ListTables_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right && ListTables.Items.Count > 0 )
            //{
            //    ContextMenuStrip menu = new ContextMenuStrip();
            //    ToolStripMenuItem subMenu01 = new ToolStripMenuItem("Close") { Name = "CLOSE_THIS" };
            //    ToolStripMenuItem subMenu02 = new ToolStripMenuItem("Close all BUT This") { Name = "CLOSE_ALL_BUT_THIS" };
            //    ToolStripMenuItem subMenu03 = new ToolStripMenuItem("Close All") { Name = "CLOSE_ALL" };
            //    ToolStripMenuItem subMenu04 = new ToolStripMenuItem("Save As..") { Name = "SAVE_AS" };
            //    ToolStripMenuItem subMenu05 = new ToolStripMenuItem("Save All...") { Name = "SAVE_ALL" };
            //    ToolStripSeparator subMenuSeparetor = new ToolStripSeparator();

            //    subMenu01.Click += new EventHandler(menuItemClose_click);
            //    subMenu02.Click += new EventHandler(menuItemClose_click);
            //    subMenu03.Click += new EventHandler(menuItemClose_click);
            //    subMenu04.Click += new EventHandler(menuItemClose_click);
            //    subMenu05.Click += new EventHandler(menuItemClose_click);
            //    menu.Items.AddRange(new ToolStripItem[] { subMenu01, subMenu02, subMenu03, subMenuSeparetor, subMenu04, subMenu05 });

            //    menu.Show(ListTables, e.Location);
            //}
        }
    }
}
