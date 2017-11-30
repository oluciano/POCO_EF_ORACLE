using POCO_EF_Oracle.Controllers;
using POCO_EF_Oracle.Models;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using ScintillaNET;

namespace POCO_EF_Oracle
{
    public class TabService
    {
        internal void AddPageTab(TabControlTable controlTable, TabControl tabControl, Form1 form)
        {
            var tabPage = new TabPage(controlTable.NameOfFile)
            {
                ImageIndex = (int)IconIndex.File,
                Tag = controlTable,
                Name = controlTable.Table
            };
            Detail detail = new Detail();

            //Get layout 
            var splitForm = detail.Controls.Cast<SplitContainer>().FirstOrDefault();

            //Create control panel1
            var panel1 = new Panel();
            var textArea = new TextAreaController(panel1, form);
            panel1 = textArea.CreateNew();
            panel1.Dock = DockStyle.Fill;
            splitForm.Panel1.Controls.Add(panel1);

            //Add columns in ListBox at Panel2
            var listbox = splitForm.Panel2.Controls.Cast<ListBox>().FirstOrDefault();
            controlTable.Columns.ForEach(c => listbox.Items.Add(c));
            
            listbox.Click += new EventHandler(form.ColumnsItem_Click);
            listbox.KeyPress += new KeyPressEventHandler(form.ColumnsItem_KeyPress);
            listbox.MouseDown += new MouseEventHandler(form.Listbox_MouseDown);


            //Set text in 
            textArea.SetText(Services.GenerateRtbText(Services.MakeView(controlTable)));

            tabPage.Controls.Add(splitForm);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;    
        }

        private void Listbox_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void EditPageSelected(TabPage selectedTab, List<TableView> viewSelected, Form1 form1)
        {
            try
            {
                var form = selectedTab.Controls.Cast<SplitContainer>().FirstOrDefault();
                var panel1 = form.Panel1.Controls.Cast<Panel>().FirstOrDefault();
                var scintilla = panel1.Controls.Cast<Scintilla>().FirstOrDefault(c => c is Scintilla) as Scintilla;

                var controlTable = selectedTab.Tag as TabControlTable;
                controlTable.Columns = viewSelected;

                scintilla.Text = Services.GenerateRtbText(Services.MakeView(controlTable));
                form.Panel1.Controls.Clear();
                panel1.Controls.Clear();
                panel1.Controls.Add(scintilla);
                form.Panel1.Controls.Add(panel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private static void ColumnsItem_Click(object sender, EventArgs e)
        //{
        //    ContextMenuStrip menu = new ContextMenuStrip();

        //    ToolStripMenuItem menuCloseThis = new ToolStripMenuItem("Close")
        //    {
        //        Name = "CLOSE_THIS"
        //    };
        //    ToolStripMenuItem menuCloseAllButThis = new ToolStripMenuItem("Close all BUT This")
        //    {
        //        Name = "CLOSE_ALL_BUT_THIS"
        //    };
        //    ToolStripMenuItem menuCloseAll = new ToolStripMenuItem("Close All")
        //    {
        //        Name = "CLOSE_ALL"
        //    };
        //    ToolStripSeparator menuSeparetor = new ToolStripSeparator();

        //    ToolStripMenuItem menuSaveAs = new ToolStripMenuItem("Save As..")
        //    {
        //        Name = "SAVE_AS"
        //    };
        //    ToolStripMenuItem menuSaveAll = new ToolStripMenuItem("Save All...")
        //    {
        //        Name = "SAVE_ALL"
        //    };

        //    menuCloseThis.Click += new EventHandler(menuItemClose_click);
        //    menuCloseAllButThis.Click += new EventHandler(menuItemClose_click);
        //    menuSaveAs.Click += new EventHandler(menuItemClose_click);
        //    menuSaveAll.Click += new EventHandler(menuItemClose_click);
        //    menuCloseAll.Click += new EventHandler(menuItemClose_click);
        //    menu.Items.AddRange(new ToolStripItem[] { menuCloseThis, menuCloseAllButThis, menuCloseAll, menuSeparetor, menuSaveAs, menuSaveAll });

        //    menu.Show(tabControl1, e.Location);

        //}
    }
}
