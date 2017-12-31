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
   }
}
