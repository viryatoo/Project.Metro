using System.Collections.Generic;

namespace Game
{
    public class CellUpdater
    {
        public List<Cell> cells;

        public CellUpdater()
        {
            cells = new List<Cell>();
        }

        public void AddCell(Cell cell)
        {
            cells.Add(cell);
        }
        public void RemoveCell(Cell cell) 
        {
            cells.Remove(cell);
        }

        public void Update()
        {
            foreach (Cell cell in cells)
            {
                
            }
        }
    }
}