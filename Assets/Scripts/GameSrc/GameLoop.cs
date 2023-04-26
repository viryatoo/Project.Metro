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
        public GameLoop(GameMapImporter gameMapImporter, CameraMovement movement)
        {
            mapImporter = gameMapImporter;
            cameraMovement = movement;
        }
        public void Start()
        {
            GameMap map = mapImporter.Import("Preview2");
            cameraMovement.UpdateArea(map.Size());
        }

        public void Tick()
        {
            cameraMovement.UpdateCamera();
        }
    }
}
