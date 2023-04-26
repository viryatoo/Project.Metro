using UnityEngine;

namespace MapEditor
{
    public interface IBlockFactory<T>
    {
        T Create(BlockType type);
        IBlockFactory<T> InPosition(Vector3 pos);
    }
}