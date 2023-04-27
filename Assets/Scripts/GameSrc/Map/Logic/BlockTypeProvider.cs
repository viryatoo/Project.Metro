using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BlockTypeProvider : IBlockTypeProvider
    {
        private Map geometryMap;
        public BlockTypeProvider(Map map)
        {
            geometryMap = map;
        }
        public BlockType GetBlockTypeInPosition(int x, int y)
        {
           return geometryMap.GetBlockTypeInPosition(x, y);
        }
    }
}
