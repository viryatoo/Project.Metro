using MapEditor.EditorStates;
using System.Collections;
using UnityEngine;
using MapEditor;
using System.Data;
using UnityEditor.Timeline;
using CustomStateMachine;

namespace MapEditor.EditorStates
{
    /*
    Состояние редактора когда был выбран блок в UI.
    */
    public class PanelBlockSelected : IState
    {
        private BlockProvider request;
        private UiEditor editor;
        private BlockView currentBlock;
        private Map gameMap;
        private StateMachine sm;

        public PanelBlockSelected(BlockProvider blockRequest, UiEditor uiEditor, Map map)
        {
            request = blockRequest;
            editor = uiEditor;
            gameMap = map;
        }
        public void Enter()
        {
            editor.LockedPanel(true);//блокируем панель.
            currentBlock = request.GetView();//получаем у провайдера на какой блок кликнули
        }


        public void Exit()
        {
            editor.LockedPanel(false);
            
        }


        public void Initialize(StateMachine stateMachine)
        {
            sm = stateMachine;
        }

        public void Update()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = Mathf.Round(mousePos.x);
            mousePos.y = Mathf.Round(mousePos.y);
            currentBlock.transform.position = mousePos;
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (gameMap.SetBlock(RequestBlock(mousePos), currentBlock))//ставим блок, если получилось, то берем новый.
                    {
                        currentBlock = request.GetView();
                    }

                }
                else
                {
                    if (gameMap.SetBlock(RequestBlock(mousePos), currentBlock))
                    {
                        sm.ChangeState<WaitPlayerInputState>();//меняем состояние на ожидание других действий от игрока.
                    }
                }

            }
        }

        private BlockData RequestBlock(Vector2 mousePos)
        {
            BlockData data = request.GetData();
            data.positon = new Positon((int)mousePos.x, (int)mousePos.y);
            return data;
        }
    }
}