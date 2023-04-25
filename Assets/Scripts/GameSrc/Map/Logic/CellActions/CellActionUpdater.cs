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
        public void AddAction(IAction action, Cell cell)
        {
            action.Initialize(cell);
            actions.Add(action);
        }

        public void Update()
        {
            foreach (var action in actions)
            {
                if (action.Update() > 100f)
                {
                    action.End();
                    actions.Remove(action);
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
