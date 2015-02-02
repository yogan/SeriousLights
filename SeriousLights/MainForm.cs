using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriousLights
{
    public partial class MainForm : Form
    {
        private LedStrip myStrip;

        public MainForm()
        {
            InitializeComponent();

            myStrip = new LedStrip(10);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(myStrip.Led.ToArray());
        }

        private void OnColorBarScroll(object sender, EventArgs e)
        {
            UpdateColorPanel();
        }

        private void UpdateColorPanel()
        {
            colorPanel.BackColor = Color.FromArgb(redBar.Value, greenBar.Value, blueBar.Value);
        }
    }
}
