using System.Collections;
using CustomStateMachine;
using UnityEngine;

namespace MapEditor.EditorStates
{
    public class WaitPlayerInputState : IState
    {
        private Map gameMap;
        private StateMachine sm;

        //Прокидывес ссылку чтобы можно было менять состояние внутри стейта.
        public void Initialize(StateMachine stateMachine)
        {
            sm = stateMachine;
        }

        public WaitPlayerInputState(Map map)
        {
            gameMap = map;
        }
        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Update()
        {
            //проверяем мышь на нажатия, если нажали пытаемся убрать блок по координатам мыши в пространстве.
            if (Input.GetMouseButtonDown(1))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.x = Mathf.Round(mousePos.x);
                mousePos.y = Mathf.Round(mousePos.y);
                gameMap.RemoveBlock((int)mousePos.x, (int)mousePos.y);
            }
        }
    }
}