using UnityEngine;

namespace MapEditor
{
    //фабрика для создания блока по типу.
    public class BlockFactory
    {
        private MapEditorContentProvider contentProvider;
        private Vector3 position;
        public BlockFactory(MapEditorContentProvider provider) 
        { 
            contentProvider = provider;
        }
        public BlockFactory InPosition(Vector3 pos)
        {
            position = pos;
            return this;
        }
        public BlockView Create(BlockType type)
        {
            switch (type)
            {
                case BlockType.Line:
                    var obj = Object.Instantiate(contentProvider.blockFactoryData.Line);
                    obj.Init();
                    obj.transform.position = position;
                    return obj;
                case BlockType.Staion:
                    obj = Object.Instantiate(contentProvider.blockFactoryData.Station);
                    obj.transform.position = position;
                    obj.Init();
                    return obj;
                case BlockType.Noone:
                    return null;
            }
            position = Vector3.zero;
            return null;
        }
    }
}