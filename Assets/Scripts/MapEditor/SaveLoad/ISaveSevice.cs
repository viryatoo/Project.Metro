using MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MapEditor
{
    public interface ISaveSevice
    {
        public void Save(BlockData[,] data, string directory, string name,int sizeMap);
        public GeometryMap Load(string path);
    }
}

