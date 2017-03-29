using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefendersOfH6
{
    public partial class Form1 : Form
    {
        World w;
        public Form1()
        {
            InitializeComponent();

            List<ThinkingObject> o = new List<ThinkingObject>();

            w = new World(o);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            w.zacniKolo();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            w.skonciKolo();
        }
    }
}
