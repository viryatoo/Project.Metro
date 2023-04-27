using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CellPool
    {
        private List<Cell> allCells;
        private Cell sellectedCell;

        public event Action<Cell> CellClicked;
        public CellPool(List<Cell> cells)
        {
            allCells = cells;
        }
        public Cell GetCellInPosition(int x,int y)
        {
            foreach (var cell in allCells)
            {
                if(cell.x == x && cell.y == y)
                {
                    return cell;
                }
            }
            return null;
        }
        public Cell GetSelectedCell()
        {
            return sellectedCell;
        }
        public void SetSelectedCell(Cell cell)
        {
            sellectedCell = cell;
            CellClicked?.Invoke(sellectedCell);
        }
    }
}
