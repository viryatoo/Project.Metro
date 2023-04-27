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
        public CActionMoveArmy(Cell from, Cell to,float timeInSeconds)
        {
            fromCell = from;
            toCell = to;
            totalTime = timeInSeconds;
            currentTime = 0;
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
            currentTime += Time.deltaTime;
            progress = currentTime / totalTime;
            fromCell.Army -= (int)(fromCell.Army * progress);
            toCell.Army += (int)(fromCell.Army * progress);
            return progress;
        }
    }
}
