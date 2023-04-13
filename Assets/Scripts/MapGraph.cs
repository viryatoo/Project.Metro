
using UnityEngine;

public class MapGraph : MonoBehaviour
{
    [SerializeField] private NodeStation[] nodes;

    [ContextMenu("Find all Stations on scenes")]
    public void FindAllNodes()
    {
        nodes = FindObjectsOfType<NodeStation>();
    }
}
