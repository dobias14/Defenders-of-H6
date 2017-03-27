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
        CountingThread clock;
        public Form1()
        {
            InitializeComponent();
            clock = new CountingThread(true, this);

            World w = new World();

            Thread oThread = new Thread(new ThreadStart(clock.run));

            // Start the thread
            oThread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!oThread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread
            // to do some work:
            //Thread.Sleep(1);
            //oThread.

            // Request that oThread be stopped
            //oThread.Abort();

            // Wait until oThread finishes. Join also has overloads
            // that take a millisecond interval or a TimeSpan object.
            //oThread.Join();

            Console.WriteLine();
            Console.WriteLine("clock has finished.");

            Console.WriteLine();
            Console.WriteLine("and clock number is : " + World.getTime());
            
            //World.resetTimer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = World.getTime() + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clock.stopThread();
        }
    }
}
