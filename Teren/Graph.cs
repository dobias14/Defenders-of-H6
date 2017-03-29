﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendersOfH6
{ 
	class Graph {
		private int width = 0;
		private int height = 0;
		private int id = 0;
		private Random r = new Random();
		private int distance = 10;
		private Node[,] nodes;
		
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
					nodes[i,j] = new Node(id,i*distance,j*distance,r.Next(4));
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
			throw new NotImplementedException();
			/*Node node = nodes[x,y];
			if(!node.isEnable()){
				
			}*/
		}
		
		public Node getNode(int x, int y){
			return nodes[x,y];
		}
		
		public Array getNodes(){
			return nodes;
		}
		
		public int getDistance(){
			return distance;
		}
	}
}