using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using MapEditor.EditorStates;

namespace MapEditor
{
    //Логика правой панели.
    public class MainPanelModel : IMapPanelModel
    {
        private StateMachine stateMachine;
        private ISaveSevice saveSevice;
        private Map gameMap;
        public MainPanelModel(StateMachine sm,Map map) 
        {
            stateMachine = sm;
            gameMap = map;
        }

        private BlockType currentBlockType;
        public void LineBlockClicked()
        {
            //если кликнули на блок, задаем тип и меняем текущее состояние на PanelBlockSelected
            currentBlockType = BlockType.Line;
            stateMachine.ChangeState<PanelBlockSelected>();
            
        }

        public void StationBlockClicked()
        {
            currentBlockType = BlockType.Staion;
            stateMachine.ChangeState<PanelBlockSelected>();
        }
        public BlockType GetSelectedBlock()
        {
            return currentBlockType;
        }

        public void SaveMap(string name)
        {
            gameMap.SaveMap(name + ".json");
        }
    }
}
