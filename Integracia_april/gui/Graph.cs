using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{ 
	public class Graph {
		private int width = 0;
		private int height = 0;
		private int id = 0;
		private Random r = new Random();
		private int distance = 10;
		private Node[,] nodes;
		private int target;
		
		public Graph(int w, int h){
			width = w;
			height = h;
			nodes = new Node[width,height];
			createNodes();
			joinNodes();
		}
		
		public void createNodes(){
			for (int i = 0; i < width; i++){
				for (int j = 0; j < height; j++){
					nodes[i,j] = new Node(id,i*distance,j*distance,r.Next(3));
					id++;
			    }
	        }
		}
		
		public void createEdge(Node node1, Node node2) {
			if(node1.getTerrain() != 3 && node2.getTerrain() != 3){
				node1.addEdgeTo(node2);
				node2.addEdgeTo(node1);
			}
		}
		
		public void joinNodes(){
			for(var i = 0; i < width-1; i++){
				for(var j = 0; j < height-1; j++){
					createEdge(nodes[i,j],nodes[i,j+1]);
					createEdge(nodes[i,j],nodes[i+1,j]);
				}
			}
			
			for(var j = 0; j < height-1; j++){
				createEdge(nodes[width-1,j],nodes[width-1,j+1]);
			}
			
			for(var i = 0; i < width-1; i++){
				createEdge(nodes[i,height-1],nodes[i+1,height-1]);
			}
		}
		
		public void disableNode(int x, int y){
			Node node = nodes[x,y];
			if(node.isEnable()){
				node.disableNode();
			}
		}
		
		public void enableNode(int x, int y){
			Node node = nodes[x,y];
			List<Node> enabledNodes = new List<Node>();
			if(!node.isEnable()){
				if(x-1 >= 0){
					if(nodes[x-1,y].isEnable()){
						enabledNodes.Add(nodes[x-1,y]);
					}
				}
				if(x+1 < width){
					if(nodes[x+1,y].isEnable()){
						enabledNodes.Add(nodes[x+1,y]);
					}
				}
				if(y-1 >= 0){
					if(nodes[x,y-1].isEnable()){
						enabledNodes.Add(nodes[x,y-1]);
					}
				}
				if(y+1 < height){
					if(nodes[x,y+1].isEnable()){
						enabledNodes.Add(nodes[x,y+1]);
					}
				}
			}
			node.enableNode(enabledNodes);
		}
		
		public int getWidth(){
			return width;
		}
		
		public int getHeight(){
			return height;
		}
		
		public Node getNode(int x, int y){
			return nodes[x,y];
		}
		
		public Node[,] getNodes(){
			return nodes;
		}
		
		public int getDistance(){
			return distance;
		}
		
		public void setNodes(Node [,] defNodes){
			nodes = defNodes;
		}
		
		public void setFinalTargetLocation(int x, int y){
			target = nodes[x,y].getId();
		}
		
		public int getFinalTargetLocation(){
			return target;
		}
		
		public void draw(Graphics g){
			for (int i = 0; i < width; i++){
				for (int j = 0; j < height; j++){
					nodes[i,j].draw(g);
			    }
	        }
        }
	}
}
