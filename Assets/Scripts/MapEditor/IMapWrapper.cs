using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public interface IMapWrapperLoader
    {
        public void BeginLoadMap(GeometryMap geometryMap);
        public void UpdateCreatedBlock(BlockView blockView,BlockData data);
        public void EndLoadMap(GeometryMap geometryMap);
    }
}
