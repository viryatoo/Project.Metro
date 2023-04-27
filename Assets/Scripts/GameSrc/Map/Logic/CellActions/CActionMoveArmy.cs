using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class CActionMoveArmy : IAction
    {
        private Cell fromCell;
        private Cell toCell;
        private float totalTime;
        private float currentTime;
        private float progress;
        private int secondStartArmy;
        private int firstStartArmy;
        public CActionMoveArmy(Cell from, Cell to,float timeInSeconds)
        {
            fromCell = from;
            toCell = to;
            totalTime = timeInSeconds;
            currentTime = 0;
            secondStartArmy = to.Army;
            firstStartArmy = from.Army;
        }
        public void End()
        {

        }

        public void Start()
        {
            
        }

        public void Stoped()
        {
            
        }

        public float Update()
        {
            Debug.Log(progress);
            Debug.Log(currentTime);
            currentTime += Time.deltaTime;
            progress = currentTime / totalTime;
            fromCell.Army = (int)(firstStartArmy * (1-progress));
            toCell.Army = secondStartArmy + (int)(firstStartArmy * progress);
            fromCell.UpdateView();
            toCell.UpdateView() ;
            return progress*100;
        }
    }
}
