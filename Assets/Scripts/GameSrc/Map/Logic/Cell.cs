using MapEditor;
using UnityEngine;

namespace Game
{
    public class Cell
    {
        private CellPool pool;
        public int x;
        public int y;
        public Police police;
        public int Army;
        private CellView view;
        private Transform transform;

        public Cell(CellPool cellPool,CellView cellView)
        {
            pool = cellPool;
            view = cellView;
            transform = cellView.transform;
            
        }

        public void OnCliced()
        {
            pool.SetSelectedCell(this);
        }
    }
}