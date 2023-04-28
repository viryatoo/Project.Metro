using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLoop : IStartable, ITickable
    {
        private GameMapImporter mapImporter;
        private CameraMovement cameraMovement;
        private GameMap map;
        private GameMainPanelView mainPanel;
        private UICommandsStationBuilder commandsBuilder;

        public GameLoop(GameMapImporter gameMapImporter, CameraMovement movement,GameMainPanelView panelView)
        {
            mapImporter = gameMapImporter;
            cameraMovement = movement;
            mainPanel = panelView;
        }
        public void Start()
        {
            map = mapImporter.Import("Preview2");
            cameraMovement.UpdateArea(map.Size());
            commandsBuilder = new UICommandsStationBuilder(mainPanel, map.BlockTypeProvider, map.CellActionUpdater,map.Pool,map.GameMapUtility);
        }

        public void Tick()
        {
            cameraMovement.UpdateCamera();
            map.Update();
        }
    }
}
