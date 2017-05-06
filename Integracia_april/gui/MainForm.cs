using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DefendersOfH6;
using System.IO;
using System.Text;

namespace GUI {
	public partial class MainForm : Form {
		public bool build_tower;
        public bool build_bug;
		public bool is_start;

        public World world;
        public Graph graph;
        List<ThinkingObject> things = new List<ThinkingObject>();
        Graphics g;
        public MainForm() {
			InitializeComponent();

            g = CreateGraphics();
            graph = new Graph(20, 20);

            world = new World(ref things, World.Difficulty.Easy, g, graph);
            label1.Text = world.getScore()+"";

            listBox1.Items.AddRange(Enum.GetNames(typeof(World.Difficulty)));

        }
		void Button1Click(object sender, EventArgs e) {
            if (!is_start) { 
			is_start = true;

            world.setDifficultyForNextRound((World.Difficulty)listBox1.SelectedIndex);
            world.zacniKolo();
                //graph = new Graph(1000,1000);
            }

        }
		
		void Button2Click(object sender, EventArgs e) {
			if (is_start) {
				build_tower = true;	
                		
			}
		}

		void MainFormMouseUp(object sender, MouseEventArgs e) {
	
            Node n = graph.getNode(e.X / 10, e.Y / 10);
            //Node k = graph.getNode(50, 50);
            
            
            if (build_tower)
            {
                //g.FillEllipse(Brushes.Red, 50, 50, 20, 20);
                ICollection myCollection = ArrayList.Synchronized(things);
                BasicTower t1 = new BasicTower(n, graph, 100, 100);

                t1.thinking();
                //t1.action();
                //t1.draw(g);

                graph.disableNode(e.X / 10, e.Y / 10);
                lock (myCollection.SyncRoot) { 
                    things.Add(t1);
                    //Console.WriteLine(things.Count+"DELETE");
                }
                build_tower = false;
                world.substractFromScore(100);
                label1.Text = world.getScore() + "";
            }

            
            if (build_bug)
            {
                //BasicCreature c1 = new BasicCreature(n, k, graph, 100, 100, world);
                build_bug = false;
                //things.Add(c1);
                //c1.draw(g);
            }
            

            //world.setArray(things);

		}
		
		void Button3Click(object sender, EventArgs e) {
			if (is_start) {
				is_start = false;
                if (world.isH6ServerDead())
                {
                    MessageBox.Show("H6 server has been destroyed.");
                }
                world.skonciKolo();
			}
		}
		
		void Button4Click(object sender, EventArgs e) {
			MessageBox.Show("LOAD GAME");

            string path = "../SAVE.txt";
            string readText = File.ReadAllText(path);
		}
		
		void Button5Click(object sender, EventArgs e){
			MessageBox.Show("SAVE GAME");

            string path = "../SAVE.txt";
            File.WriteAllText(path, "Neda sa ulozit subor, leboooo ste zle klikli na ten save no :)");
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

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
