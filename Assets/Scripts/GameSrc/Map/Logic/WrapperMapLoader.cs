using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapEditor;

namespace Game
{
    public class WrapperMapLoader : IMapWrapperLoader
    {
        private CellUpdater cellUpdater;
        private CellPool pool;
        public WrapperMapLoader(CellUpdater updater, CellPool cellPool)
        {
            cellUpdater = updater;
            pool = cellPool;
        }
        public void BeginLoadMap(GeometryMap geometryMap)
        {

        }

        public void EndLoadMap(GeometryMap geometryMap)
        {

        }

        public void UpdateCreatedBlock(BlockView blockView, BlockData data)
        {
            Cell cell = new Cell(pool, (CellView)blockView,data.positon.x,data.positon.y);
            cell.Army = UnityEngine.Random.Range(0, 200);
            cell.police = null;
            cell.UpdateView();
            cellUpdater.AddCell(cell);
        }
    }
}
