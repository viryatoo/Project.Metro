using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using CustomStateMachine;
using MapEditor.EditorStates;
using MapEditor;

namespace MapEditor
{
    //основной жизненый цикл редактора.
    public class EditorLoop : ITickable, IStartable
    {
        private StateMachine EditorStateMachine;
        private Map gameMap;
        private CameraMovement cameraMovement;
        private ContentLoader contentLoader; 
        private BlockProvider provider;
        private MapEditorContentProvider contentProvider;

        public EditorLoop(StateMachine sm, Map map, CameraMovement cm, ContentLoader loader, BlockProvider blockProvider,MapEditorContentProvider settings)
        {
            EditorStateMachine = sm;
            cameraMovement = cm;
            contentLoader = loader;
            gameMap = map;
            provider = blockProvider;
            contentProvider = settings;
        }

        public void Start()
        {
            var uiEditor = contentLoader.LoadUI();
            EditorStateMachine.AddState<PanelBlockSelected>(new PanelBlockSelected(provider,uiEditor,gameMap));
            EditorStateMachine.AddState<WaitPlayerInputState>(new WaitPlayerInputState(gameMap));
            EditorStateMachine.ChangeState<WaitPlayerInputState>();

            gameMap.CreateMap(contentProvider.DefaultMapSize);
            cameraMovement.UpdateArea();
        }

        public void Tick()
        {
            EditorStateMachine.Update();
            cameraMovement.UpdateCamera();
        }
    }
}
