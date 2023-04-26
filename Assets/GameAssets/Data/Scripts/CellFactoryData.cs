using MapEditor;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "BlockFactory", menuName = "Data/Game/CellFactoryData")]
    public class CellFactoryData
    {
        public CellView Line;
        public CellView Station;
    }
}