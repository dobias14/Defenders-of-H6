using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{ 
	class Node {
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
			throw new NotImplementedException();
		}

		public int getTerrain(){
			return terrain;
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
	}
}