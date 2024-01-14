using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpShapesLib;

namespace UdpShapesClient
{
    public partial class colorChange : Form
    {
        public colorChange()
        {
            InitializeComponent();
        }

        private void colorChange_Load(object sender, EventArgs e)
        {
            comboBoxColor.Items.Add(Color.Red);
            comboBoxColor.Items.Add(Color.Yellow);
            comboBoxColor.Items.Add(Color.Blue);
            comboBoxColor.Items.Add(Color.Green);
            comboBoxColor.Items.Add(Color.LightBlue);
            comboBoxColor.Items.Add(Color.Black);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Color Color = (Color)comboBoxColor.SelectedItem;
            this.Close();
            
        }
    }
}
