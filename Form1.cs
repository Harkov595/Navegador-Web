using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador_Web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
                webBrowser1.GoHome();
        }

        private void Ir_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
