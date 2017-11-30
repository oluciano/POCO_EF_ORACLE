using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCO_EF_Oracle
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                e.SuppressKeyPress = true;
                for (int i = 0; i < listBox1.Items.Count; i++)
                    listBox1.SetSelected(i, true);

            }
            else if (e.KeyCode == Keys.Z && e.Control)
            {
                e.SuppressKeyPress = true;
                for (int i = 0; i < listBox1.Items.Count; i++)
                    listBox1.SetSelected(i, false);

            }
        }
    }
}
