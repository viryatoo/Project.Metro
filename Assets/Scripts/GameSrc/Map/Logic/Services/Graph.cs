using MapEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.GraphUtility
{



    public class GraphVertex
    {
        public Vector2Int position;
        public List<GraphEdge> graphEdges;

        public GraphVertex(Vector2Int pos)
        {
            position = pos;
            graphEdges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge edge)
        {
            graphEdges.Add(edge);
        }
    }

    public class GraphEdge
    {
        public int Weight;
        public GraphVertex Vertex;

        public GraphEdge(int weight, GraphVertex vertex)
        {
            Weight = weight;
            Vertex = vertex;
        }
    }

    public class Graph
    {
        private List<GraphVertex> vertices;

        public Graph() 
        {
            vertices = new List<GraphVertex>();
        }

        public void AddVertex(Vector2Int pos)
        {
            vertices.Add(new GraphVertex(pos));
        }

        public void AddEdge(Vector2Int pos1,Vector2Int pos2,int weight)
        {
            GraphVertex v1 = FindVertex(pos1);
            GraphVertex v2 = FindVertex(pos2);

            if(v1 != null && v2 != null)
            {
                v1.AddEdge(new GraphEdge(weight, v2));
                v2.AddEdge(new GraphEdge(weight, v1));
            }
        }



        private GraphVertex FindVertex(Vector2Int pos)
        {
            foreach(GraphVertex vertex in vertices)
            {
                if(vertex.position == pos)
                {
                    return vertex;
                }
            }
            return null;
        }


        public void LoadFrom(BlockData[,] data,int mapSize)
        {
            
        }

        private int CalculateWeight(Vector2Int from, BlockData[,] data,int mapSize)
        {
            if (InSize(from.x-1,from.y,mapSize))
            {
                
            }
            return 0;
        }
        private bool InSize(int x, int y,int mapSize)
        {
            return (x >= 0 & x < mapSize & y >= 0 & y < mapSize);
        }
    }
}
