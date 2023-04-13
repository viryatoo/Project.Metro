using UnityEngine;

namespace MapEditor
{
    //фабрика для создания блока по типу.
    public class BlockFactory
    {
        private MapEditorContentProvider contentProvider;
        public BlockFactory(MapEditorContentProvider provider) 
        { 
            contentProvider = provider;
        }

        public BlockView Get(BlockType type)
        {
            switch (type)
            {
                case BlockType.Line:
                    var obj = Object.Instantiate(contentProvider.blockFactoryData.Line);
                    obj.Init();
                    return obj;
                case BlockType.Staion:
                    obj = Object.Instantiate(contentProvider.blockFactoryData.Station);
                    obj.Init();
                    return obj;
                case BlockType.Noone:
                    return null;
            }
            return null;
        }
    }
}