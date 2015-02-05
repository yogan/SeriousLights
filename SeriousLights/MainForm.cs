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
        private SerialCommunication mySerialCommunication;

        public MainForm()
        {
            InitializeComponent();

            myStrip = new LedStrip(10);
            mySerialCommunication = new SerialCommunication();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ledComboBox.Items.AddRange(myStrip.Led.ToArray());
            ledComboBox.SelectedIndex = 0;
        }

        private void OnFormClosing(Object sender, FormClosingEventArgs e)
        {
            mySerialCommunication.Close();
        }

        private void OnColorBarScroll(object sender, EventArgs e)
        {
            var color = Color.FromArgb(redBar.Value, greenBar.Value, blueBar.Value);
            UpdateColorPanel(color);
            //mySerialCommunication.Write(color);
        }

        private void UpdateColorPanel(Color color)
        {
            colorPanel.BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySerialCommunication.Write(colorPanel.BackColor);
        }
    }
}
