using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class MapUtility
    {
        private Map gmap;

        public MapUtility(Map map)
        {
            gmap = map;
        }

        public int CalculateDistance(Vector2Int pos1, Vector2Int pos2)
        {
            AStar.Position position1 = new AStar.Position(pos1.x,pos1.y);
            AStar.Position position2 = new AStar.Position(pos2.x,pos2.y);

            AStar.Position[] indexs = gmap.PathFinder.FindPath(position1, position2);

            return indexs.Length;
        }
    }
}
