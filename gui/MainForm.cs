using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DefendersOfH6;

namespace GUI {
	public partial class MainForm : Form {
		public bool build_tower;
        public bool build_bug;
		public bool is_start;

        public World world;
        public Graph graph;
        volatile List<ThinkingObject> things = new List<ThinkingObject>();
        Graphics g;
        public MainForm() {
			InitializeComponent();
       
		}
		void Button1Click(object sender, EventArgs e) {
			is_start = true;
            world.zacniKolo();
            graph = new Graph(1000,1000);

		}
		
		void Button2Click(object sender, EventArgs e) {
			if (is_start) {
				build_tower = true;	
                		
			}
		}

		void MainFormMouseUp(object sender, MouseEventArgs e) {
	
            Node n = graph.getNode(e.X / 10, e.Y / 10);
            Node k = graph.getNode(50, 50);
            
            if (build_tower)
            {
                g.FillEllipse(Brushes.Red, 50, 50, 20, 20);
                ICollection myCollection = ArrayList.Synchronized(things);
                BasicTower t1 = new BasicTower(n, graph, 100, 100);

                t1.thinking();
                //t1.action();
                t1.draw(g);

                graph.disableNode(e.X / 10, e.Y / 10);
                lock (myCollection.SyncRoot) { 
                    things.Add(t1);
                    Console.WriteLine(things.Count+"DELETE");
                }
                build_tower = false;

            }
            if (build_bug)
            {
                BasicCreature c1 = new BasicCreature(n, k, graph, 100, 100, world);
                build_bug = false;
                things.Add(c1);
                c1.draw(g);
            }

            world.setArray(things);

		}
		
		void Button3Click(object sender, EventArgs e) {
			if (is_start) {
				is_start = false;
				MessageBox.Show("PAUSE");
                world.skonciKolo();
			}
		}
		
		void Button4Click(object sender, EventArgs e) {
			MessageBox.Show("LOAD GAME");
		}
		
		void Button5Click(object sender, EventArgs e){
			MessageBox.Show("SAVE GAME");
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            Console.WriteLine("vonku");
            Console.WriteLine(things.Count);
            world = new World(things, 100, g);
            Console.WriteLine("juhu");
       

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (is_start)
            {
                build_bug = true;

            }

        }
    }
}
