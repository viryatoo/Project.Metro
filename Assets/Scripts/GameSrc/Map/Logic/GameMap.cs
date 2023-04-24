using MapEditor;

namespace Game
{
    public class GameMap
    {
        private Map geometryMap;
        private CellUpdater cellUpdater;

        public GameMap(Map gmap, CellUpdater updater)
        {
            geometryMap = gmap;
        }
    }
}