using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IAction
    {
        public void Initialize(Cell cell);
        public void Start();
        public float Update();
        public void End();
        public void Stoped();
    }
}
