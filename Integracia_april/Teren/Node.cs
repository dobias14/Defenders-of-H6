using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{ 
	public class Node {
		private int x,y,id,terrain;
		private bool enable;
		private List<Node> neighbours = new List<Node>();
		
		public Node(int defId,int defX, int defY, int deffTerrain){
			x = defX;
			y = defY;
			id = defId;
			terrain = deffTerrain;
			if(terrain != 3){
				enable = true;
			}else{
				enable = false;
			}
			
		}
		
		public void displayNeighbours(){
			foreach(Node neighbour in neighbours){
				Console.WriteLine(neighbour);
			}
		}
		
		public void addEdgeTo(Node node){
			neighbours.Add(node);
		}
		
		public void removeEdgeTo(Node node){
			var no = neighbours.Find(n => n.getId() == node.getId());
			neighbours.Remove(no);
		}
		
		public void disableNode(){
			foreach(var neighbour in neighbours){
				neighbour.removeEdgeTo(this);
			}
			neighbours = new List<Node>();
		}
		
		public void enableNode(List<Node> nodes){
			if(neighbours.Count > 0){
				disableNode();
			}
			neighbours = nodes;
		}

		public int getTerrain(){
			return terrain;
		}
		
		public void setTerrain(int type){
			terrain = type;
		}
		
		public int getId(){
			return id;
		}
		
		public int getX(){
			return x;
		}
		
		public int getY(){
			return y;
		}
		
		public bool isEnable(){
			return enable;
		}
		
		public override string ToString(){
			return "ID: "+id+", X: "+x+", Y: "+y+", T: "+terrain;
		}
		
		public List<Node> getNeighbours() {
			return neighbours;
		}
		
		public override void draw(Graphics g)
        {
        	switch (terrain){
				case 0:
					g.FillEllipse(Color.FromArgb(224,224,224), x, y, 10, 10); // floor
					break;
		        case 1:
		        	g.FillEllipse(Color.FromArgb(153,76,0), x, y, 10, 10); // table
		            break;
		        case 2:
		        	g.FillEllipse(Color.FromArgb(96,96,96), x, y, 10, 10); // computer
		            break;
		        case 3:
		        	g.FillEllipse(Color.FromArgb(0,0,0), x, y, 10, 10); // wall
		        	break;
		        case 10:
		        	g.FillEllipse(Color.FromArgb(0,255,0), x, y, 10, 10); // target
		        	break;
		        default:
		        	g.FillEllipse(Color.FromArgb(224,224,224), x, y, 10, 10);  // floor
		        	break;
		    }         
        }
	}
}
