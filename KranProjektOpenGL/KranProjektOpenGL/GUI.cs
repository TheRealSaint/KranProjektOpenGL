using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KranProjektOpenGL
{
    public partial class GUI : Form

    {
        TView oglView = new TView();

        public GUI()
        {
            InitializeComponent();

            oglView.Dock = DockStyle.Fill;
            panel.Controls.Add(oglView);

            panel.Focus();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(1, trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(2, trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
           
        }
    
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
 

        }
    }
}
