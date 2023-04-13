using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using MapEditor.EditorStates;

namespace MapEditor
{
    //основной жизненый цикл редактора.
    public class EditorLoop : ITickable, IStartable
    {
        private StateMachine EditorStateMachine;
        private Map gameMap;
        private CameraMovement cameraMovement;

        public EditorLoop(StateMachine sm, Map map,CameraMovement cm,
            PanelBlockSelected selectedState, WaitPlayerInputState inputState)
        {
            EditorStateMachine = sm;
            gameMap = map;
            EditorStateMachine.AddState<PanelBlockSelected>(selectedState);
            EditorStateMachine.AddState<WaitPlayerInputState>(inputState);
            EditorStateMachine.ChangeState<WaitPlayerInputState>();
            cameraMovement = cm;
        }

        public void Start()
        {
            gameMap.CreateMap(32);
            cameraMovement.UpdateArea();
        }

        public void Tick()
        {
            EditorStateMachine.Update();
            cameraMovement.UpdateCamera();
        }
    }
}
