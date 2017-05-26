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

            if (graph.getHeight() <= e.Y / 15 ||
                graph.getWidth() <= e.X / 15
                )
            {
                return;
            }

            Node n = graph.getNode(e.X / 15, e.Y / 15);
           
            
            
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

                graph.disableNode(e.X / 15, e.Y / 15); 
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

            // nacita sa, vytvori sa pole a cez graph.setNodes urobi novy graf
            // Node [,] nodes = nodes;
            //graph = new Graph(35, 35);
            //graph.setNodes(nodes);
            //graph.setFinalTargetLocation(x,y);
            //world = new World(ref things, World.Difficulty.Easy, g, graph);

            
            string path = "../SAVE.txt";
            var lines = File.ReadLines(path);
            Console.WriteLine(lines);
            int LastLineNumber = 0;
            string CurrentLine;
            //CurrentLine = lines.Skip(LastLineNumber).First();
            LastLineNumber++;

           /* foreach (string line in lines) {
                Console.WriteLine(line);
            }*/
            //string readText = File.ReadAllText(path);
		}
		
		void Button5Click(object sender, EventArgs e){
			MessageBox.Show("SAVE GAME");
            string content = "";
            string path = "../SAVE.txt";
            List<ThinkingObject> w = world.getarrayOfObjectInGame();
            Node[,] nodes = graph.getNodes();

            for (int i = 0; i < nodes.GetLength(0); i++)
            {
                for (int j = 0; j < nodes.GetLength(1); j++)
                {
                    content += (nodes[i, j].getX()/10).ToString() + " " + (nodes[i, j].getY()/10).ToString() + " " + nodes[i, j].getTerrain().ToString() + " ";
                }
            }
            content += "\n";

            Console.WriteLine(content);
            for (int i = 0; i < w.Count; i++)
            {
                if (w[i].GetType() == typeof(BasicCreature)) {
                    BasicCreature c = (BasicCreature)w[i];
                    content += "0 " + (c.getPosition().getX() / 10).ToString() + " " + (c.getPosition().getY() / 10).ToString() + " ";
                }
                else
                {
                    BasicTower c = (BasicTower)w[i];
                    content += "1 " + (c.getPosition().getX() / 10).ToString() + " " + (c.getPosition().getY() / 10).ToString() + " ";
                }
            }

            Console.WriteLine(content);
            File.WriteAllText(path, content);
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
