using MapEditor;

namespace Game
{
    public class Cell
    {
        private CellPool pool;
        public int x;
        public int y;
        public Police police;
        public int Army;
        public BlockView view;

        public Cell(CellPool cellPool)
        {
            pool = cellPool;
        }

        public void OnCliced()
        {
            pool.SetSelectedCell(this);
        }
    }
}