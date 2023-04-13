using MapEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveSevice
{
    public void Save(BlockData[,] data,string directory,string name);
    public BlockData[,] Load(string path);
}
