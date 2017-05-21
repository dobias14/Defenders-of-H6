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
        public bool build_tower_basic;
        public bool build_tower_multi;
        public bool is_start;

        //public MessageBox 

        public World world;
        public Graph graph;
        List<ThinkingObject> things = new List<ThinkingObject>();
        Graphics g;
        public MainForm() {
            InitializeComponent();
            g = CreateGraphics();
            graph = new Graph(35, 35);
            world = new World(ref things, World.Difficulty.Easy, g, graph);
            label1.Text = world.getScore() + "";
            listBox1.Items.AddRange(Enum.GetNames(typeof(World.Difficulty)));

        }
        void Button1Click(object sender, EventArgs e) {
            if (!is_start) {
                is_start = true;
                world.setDifficultyForNextRound((World.Difficulty)listBox1.SelectedIndex);
                world.zacniKolo();
            }

        }

        void Button2Click(object sender, EventArgs e) {
            if (is_start) {
                build_tower_basic = true;
                build_tower_multi = false;
            }
        }

        void MainFormMouseUp(object sender, MouseEventArgs e) {

            if (graph.getHeight() <= e.Y / 10 ||
                graph.getWidth() <= e.X / 10
                )
            {
                return;
            }

            Node n = graph.getNode(e.X / 10, e.Y / 10);
           
            
            
            if (build_tower_basic || build_tower_multi)
            {
                ICollection myCollection = ArrayList.Synchronized(things);
                BasicTower t1;
                MultiTargetTower t2;

                if (build_tower_basic)
                {
                    t1 = new BasicTower(n, graph, 20, 100, world);
                    lock (myCollection.SyncRoot)
                    {
                        if (n.getTerrain() == 1 && n.isEnable()) // ak je teren stol
                        {
                            things.Add(t1);
                        }
                        else
                        {
                            Console.WriteLine("sem nemoze veza");
                        }
                    }
                    world.substractFromScore(100);
                }

                else
                {
                   t2 = new MultiTargetTower(n, graph, 20, 100, world);
                    lock (myCollection.SyncRoot)
                    {
                        if (n.getTerrain() == 1 && n.isEnable()) // ak je teren stol
                        {
                            things.Add(t2);
                           
                        }
                        else
                        {
                            Console.WriteLine("sem nemoze veza");
                        }
                    }
                    world.substractFromScore(300);
                } 

                graph.disableNode(e.X / 10, e.Y / 10); 
                showActualScoreValue();
            }

		}
		
		void Button3Click(object sender, EventArgs e) {
			if (is_start) {
				is_start = false;
                if (world.isH6ServerDead())
                {
                    MessageBox.Show("H6 server has been destroyed.");
                }
                world.skonciKolo();

                showActualScoreValue();
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

        private void showActualScoreValue()
        {
            label1.Text = world.getScore() + "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (is_start)
            {
                build_tower_multi = true;
                build_tower_basic = false;
            }

        }
    }
}
