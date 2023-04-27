using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CellActionUpdater
    {
        private const int ACTIONS_COPACITY = 32;

        List<IAction> actions;
        public CellActionUpdater()
        {
            actions = new List<IAction>(ACTIONS_COPACITY);
        }
        public void AddAction(IAction action)
        { 
            actions.Add(action);
            action.Start();
        }

        public void Update()
        {
            for (int i =0;i<actions.Count;i++)
            {
                if (actions[i].Update() >= 100f)
                {
                    
                    actions[i].End();
                    actions.Remove(actions[i]);
                    i--;
                }
            }
        }
        public void StopAction(IAction action) 
        {
            actions.Remove(action);
            action.Stoped();
        }
    }
}
