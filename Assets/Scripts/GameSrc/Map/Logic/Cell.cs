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

        public Cell(CellPool cellPool, CellView cellView,int xx,int yy)
        {
            pool = cellPool;
            view = cellView;
            transform = cellView.transform;
            cellView.OnCellClicked += OnCliced;
            x = xx;
            y = yy;
        }

        public void OnCliced()
        {
            pool.SetSelectedCell(this);
        }

        public virtual void UpdateView()
        {
            view.UpdateView(this);
        }
    }
}