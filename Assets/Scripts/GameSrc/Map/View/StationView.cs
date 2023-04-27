using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Game
{
    public class StationView : CellView
    {
        [SerializeField] private TMP_Text armyText;

        public override void UpdateView(Cell cell)
        {
            armyText.text = "Армия: " + cell.Army;
        }


    }
}
