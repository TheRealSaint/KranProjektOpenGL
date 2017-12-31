using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoOpenGLBasicsCS
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

        //Winkel
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(1, trackBar1.Value);
        }

        //Arm
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(2, trackBar2.Value);
        }
    
        //Seil
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(3, trackBar3.Value);
        }

        //Kugel
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            oglView.changeVal(4, trackBar4.Value);
        }

        //Aktualisieren
        private void button1_Click(object sender, EventArgs e)
        {
            oglView.drawScene();
            Refresh();
        }
    }
}
