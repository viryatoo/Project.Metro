using System.Collections;
using UnityEngine;
using MapEditor;


[CreateAssetMenu(fileName = "BlockFactory", menuName = "Data/MapEditor/BlockFactoryData")]
public class BlockFactoryData : ScriptableObject
{
    public BlockView Line;
    public BlockView Station;
}
