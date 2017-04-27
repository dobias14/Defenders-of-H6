using System;
using System.Collections.Generic;
using System.Drawing;
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
            graph = new Graph(20, 20);

            world = new World(ref things, World.Difficulty.Easy, g,graph);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Node n = graph.getNode(1, 1);
            //Node k = graph.getNode(19, 19);

            is_start = true;

            //BasicCreature c1 = new BasicCreature(n, k, graph, 100, 100, world);
            //build_bug = false;
            //things.Add(c1);

            world.setFPS(60);

            world.zacniKolo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (is_start)
            {
                is_start = false;
                if (world.isH6ServerDead()) {
                    MessageBox.Show("H6 server has been destroyed.");
                }              
                world.skonciKolo();
            }
        }
    }
}
