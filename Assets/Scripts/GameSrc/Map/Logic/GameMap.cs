using MapEditor;

namespace Game
{
    public class GameMap
    {
        public IBlockTypeProvider BlockTypeProvider => blockTypeProvider;
        public CellActionUpdater CellActionUpdater => cellActionUpdater;

        public MapUtility GameMapUtility => mapUtility;

        public CellPool Pool { get { return cellUpdater.ResolvePool(); } }

        private Map geometryMap;
        private CellUpdater cellUpdater;
        private CellActionUpdater cellActionUpdater;
        private IBlockTypeProvider blockTypeProvider;
        private MapUtility mapUtility;
        public GameMap(Map gmap, CellUpdater updater,CellActionUpdater actionUpdater)
        {
            geometryMap = gmap;
            cellUpdater = updater;
            cellActionUpdater = actionUpdater;
            blockTypeProvider = new BlockTypeProvider(geometryMap);
            mapUtility = new MapUtility(geometryMap);
        }

        
        public int Size()
        {
            return geometryMap.Size;
        }
        public void Update()
        {
            cellUpdater.Update();
            cellActionUpdater.Update();
        }
    }
}