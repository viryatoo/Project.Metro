using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameAssets
{
    public class GameMapImportSettings : ScriptableObject
    {
        [SerializeField] private string FolderWithMaps = "/GameContent/";
        
        public string GetDirectorySaves()
        {
            return Application.dataPath + FolderWithMaps;
        }
    }
}
