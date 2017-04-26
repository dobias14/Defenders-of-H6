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
        public bool build_tower;
        public bool build_bug;
        public bool is_start;

        public World world;
        public Graph graph;
        List<ThinkingObject> things = new List<ThinkingObject>();
        Graphics g;


        public Form1()
        {
            InitializeComponent();

            g = CreateGraphics();
            Console.WriteLine("vonku");
            Console.WriteLine(things.Count);
            world = new World(ref things, 100, 500, g);
            Console.WriteLine("juhu");

            graph = new Graph(20, 20);

            //List<ThinkingObject> o = new List<ThinkingObject>();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //w.zacniKolo();

            Node n = graph.getNode(1, 1);
            Node k = graph.getNode(19, 19);

            is_start = true;

            BasicCreature c1 = new BasicCreature(n, k, graph, 100, 100, world);
            build_bug = false;
            things.Add(c1);

            world.zacniKolo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (is_start)
            {
                is_start = false;
                MessageBox.Show("PAUSE");
                world.skonciKolo();
            }
        }
    }
}
