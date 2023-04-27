using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IBlockTypeProvider
    {
        public BlockType GetBlockTypeInPosition(int x, int y);
    }
}
